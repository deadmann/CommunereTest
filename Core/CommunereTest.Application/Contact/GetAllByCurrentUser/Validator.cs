using FluentValidation;

namespace CommunereTest.Application.Contact
{
    public sealed partial class ContactHandler
    {
        public sealed partial class GetAllByCurrentUser
        {
            public class Validator:AbstractValidator<Request>
            {
                public Validator()
                {
                }
            }
        }
    }
}