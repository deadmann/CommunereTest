using System;
using System.Collections.Generic;
using CommunereTest.Domain.Common;
using CommunereTest.Domain.Enums;

namespace CommunereTest.Domain.Entities
{
    public class User: BaseEntityFull
    {
        public User()
        {
            Contacts = new HashSet<Contact>();
        }

        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public bool VerifiedEmail { get; set; }
        public UserActivationStatus ActivationStatus { get; set; }
        public virtual ICollection<EmailVerificationCode> EmailVerificationCodes { get; }
            = new HashSet<EmailVerificationCode>();

        public ICollection<Contact> Contacts { get; set; }
    }
}