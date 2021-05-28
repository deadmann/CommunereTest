using System;
using CommunereTest.Domain.Common;
using CommunereTest.Domain.Enums;

namespace CommunereTest.Domain.Entities
{
    public class EmailVerificationCode : BaseEntityFull
    {
        public string Email { get; set; }
        public string Code { get; set; }
        public bool Confirmed { get; set; }
        public EmailVerificationAction Action { get; set; }
        public Guid UserId { get; set; }
        public User User { get; set; }
    }
}
