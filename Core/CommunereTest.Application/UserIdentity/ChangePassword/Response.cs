namespace CommunereTest.Application.UserIdentity
{
    public sealed partial class UserIdentity
    {
        public sealed partial class ChangePassword
        {
            public sealed class Response
            {
                public bool Succeeded { get; set; }
                public string Token { get; set; }
            }
        }
    }
}
