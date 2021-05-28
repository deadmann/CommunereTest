namespace CommunereTest.Application.UserIdentity
{
    public sealed partial class UserIdentity
    {
        public sealed partial class RecoverPassword
        {
            public sealed class Response
            {
                public string Name { get; set; }
                public string Email { get; set; }
                public bool IsEmailVerified { get; set; }
                public string Token { get; set; }
            }
        }
    }
}
