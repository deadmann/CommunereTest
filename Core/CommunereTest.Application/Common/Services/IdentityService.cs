using System;
using System.Threading;
using System.Threading.Tasks;
using CommunereTest.Domain.Entities;
using CommunereTest.Domain.Enums;
using CommunereTest.Domain.Interfaces;

namespace CommunereTest.Application.Common.Services
{
    public class IdentityService : IIdentityService
    {
        private readonly IUnitOfWork _uow;
        private readonly IEmailService _email;

        public User CurrentUser { get; }
        public bool IsCurrentUserAuthenticated { get; }

        public IdentityService(IUnitOfWork uow, IEmailService email, ICurrentUserService currentUser)
        {
            _uow = uow;
            _email = email;

            CurrentUser = currentUser.IsAuthenticated ?
                GetUserByEmailAsync(currentUser.Email).Result : null;

            IsCurrentUserAuthenticated = CurrentUser != null;
        }

        public User AddUser(string email, string password)
        {
            var now = DateTime.Now;

            var user = new User
            {
                Email = email,
                Password = password,
                ActivationStatus = UserActivationStatus.Active,
                VerifiedEmail = false,
                IsActive = true,
                CreatedAt = now,
                UpdatedAt = now
            };

            var result = _uow.UserRepository.Create(user);
            return result;
        }

        public async Task<bool> EmailIsAlreadyRegisteredAsync(string email, CancellationToken cancellationToken = default)
        {
            return await _uow.UserRepository.IsExistsByEmailAsync(email, cancellationToken);
        }

        public string EncryptPassword(string password)
        {
            //TODO: EncryptPassword
            return password;
        }

        public async Task<User> GetUserByIdAsync(Guid id, CancellationToken cancellationToken = default)
        {
            return await _uow.UserRepository.GetByIdAsync(id, cancellationToken);
        }

        public async Task<User> GetUserByUsernameOrEmailAsync(string usernameOrEmail, CancellationToken cancellationToken = default)
        {
            return await _uow.UserRepository.GetUserByUsernameOrEmailAsync(usernameOrEmail, cancellationToken);
        }

        public async Task<User> GetUserByEmailAsync(string email, CancellationToken cancellationToken = default)
        {
            return await _uow.UserRepository.GetUserByEmailAsync(email, cancellationToken);
        }

        public EmailVerificationCode CreateEmailVerificationCode(User user, EmailVerificationAction action)
        {
            string code = GenerateVerificationCode();

            var now = DateTime.Now;

            var verification = new EmailVerificationCode
            {
                Code = code,
                Confirmed = false,
                UserId = user.Id,
                Email = user.Email,
                Action = action,
                IsActive = true,
                CreatedAt = now,
                CreatedById = user.Id,
                UpdatedAt = now,
                UpdatedById = user.Id
            };

            _uow.EmailVerificationCodes.Create(verification);
            return verification;
        }

        public async Task SendEmailVerificationCodeAsync(User user, string code,CancellationToken cancellationToken = default)
        {
            await _email.SendAsync(user.Username, user.Email,
                "Commuenere Verification", $"Verification Code: {code}", cancellationToken);
        }

        private string GenerateVerificationCode()
        {
            var generator = new Random();
            var code = generator.Next(0, 99999).ToString("D5");
            return code;
        }

        public async Task<bool> UsernameIsAlreadyTakenAsync(string username, CancellationToken cancellationToken = default)
        {
            return await _uow.UserRepository.IsExistsByUsernameAsync(username, cancellationToken);
        }

        public User UpdateUser(User user)
        {
            _uow.UserRepository.Update(user);
            return user;
        }

        public EmailVerificationCode UpdateEmailVerificationCode(EmailVerificationCode emailVerificationCode)
        {
            _uow.EmailVerificationCodes.Update(emailVerificationCode);
            return emailVerificationCode;
        }

        public string DecryptPassword(string encryptedPassword)
        {
            //TODO DecryptPassword
            return encryptedPassword;
        }

        public async Task<EmailVerificationCode> GetEmailVerificationCodeAsync(string email, EmailVerificationAction action,
            CancellationToken cancellationToken = default)
        {
            return await _uow.EmailVerificationCodes.GetLastByEmailAndVerificationActionAsync(email, action, cancellationToken);
        }

        public bool VerificationCodeIsUnexpired(EmailVerificationCode verification)
        {
            if (verification == null)
                return false;

            var now = DateTime.Now;
            var expirationTime = verification.CreatedAt.Value.AddMinutes(10);

            if (now >= expirationTime)
                return false;

            return true;
        }

        public bool VerificationCodeIsConfirmed(EmailVerificationCode verification)
        {
            if (verification == null)
                return false;

            if (!verification.Confirmed)
                return false;

            return true;
        }

        public async Task SendPasswordRecoveryEmailAsync(User user, string code,
            string token, CancellationToken cancellationToken = default)
        {
            await _email.SendAsync(user.Username, user.Email,
                "Communere password recovery",
                "Code: " + code + " Token:" + token,
                cancellationToken);
        }
    }
}
