namespace CommunereTest.Domain.Models
{
    public class JwtConfig
    {
        public string JwtIssuer { get; set; }
        public string JwtAudience { get; set; }
        public string JwtExp { get; set; }
        public string JwtKey { get; set; }
    }
}
