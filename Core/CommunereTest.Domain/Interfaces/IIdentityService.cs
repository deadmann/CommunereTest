using System;
using System.Threading;
using System.Threading.Tasks;
using CommunereTest.Domain.Entities;
using CommunereTest.Domain.Enums;

namespace CommunereTest.Domain.Interfaces
{
    public interface IIdentityService
    {
        public User CurrentUser { get; }
        public bool IsCurrentUserAuthenticated { get; }

        User AddUser(string email, string password);
        User UpdateUser(User user);
        Task<bool> UsernameIsAlreadyTakenAsync(string username, CancellationToken cancellationToken = default);
        Task<bool> EmailIsAlreadyRegisteredAsync(string email, CancellationToken cancellationToken = default);
        string EncryptPassword(string password);
        string DecryptPassword(string encryptedPassword);
        Task<User> GetUserByIdAsync(Guid id, CancellationToken cancellationToken = default);
        Task<User> GetUserByEmailAsync(string email, CancellationToken cancellationToken = default);
        Task<EmailVerificationCode> GetEmailVerificationCodeAsync(string email, EmailVerificationAction action,
            CancellationToken cancellationToken = default);
        EmailVerificationCode UpdateEmailVerificationCode(EmailVerificationCode emailVerificationCode);
        Task<User> GetUserByUsernameOrEmailAsync(string usernameOrEmail, CancellationToken cancellationToken = default);
        Task SendEmailVerificationCodeAsync(User user, string code, CancellationToken cancellationToken = default);
        Task SendPasswordRecoveryEmailAsync(User user, string code, string token, CancellationToken cancellationToken = default);
        EmailVerificationCode CreateEmailVerificationCode(User user, EmailVerificationAction action);
        bool VerificationCodeIsUnexpired(EmailVerificationCode verification);
        bool VerificationCodeIsConfirmed(EmailVerificationCode verification);
    }
}
