using FluentValidation;

namespace CommunereTest.Application.Contact
{
    public sealed partial class ContactHandler
    {
        public sealed partial class Create
        {
            public class Validator:AbstractValidator<Request>
            {
                public Validator()
                {
                    RuleFor(m => m.FirstName).NotEmpty().Unless(m => !string.IsNullOrEmpty(m.LastName));
                    RuleFor(r => r.MiddleName).MaximumLength(30);
                    RuleFor(m => m.LastName).NotEmpty().Unless(m => !string.IsNullOrEmpty(m.FirstName));
                    
                    // RuleFor(r => r.BirthDate);
                    
                    RuleForEach(r=>r.ContactDetails).SetValidator(new ContactDetailsValidator());
                }
            }
            
            public class ContactDetailsValidator:AbstractValidator<RequestContactDetails>
            {
                public ContactDetailsValidator()
                {
                    RuleFor(r => r.Type).NotNull();
                    RuleFor(r => r.Description).NotEmpty().MaximumLength(200);
                }
            }
        }
    }
}