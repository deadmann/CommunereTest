using Newtonsoft.Json;

namespace CommunereTest.Domain.Models
{
    public class JwtPayload
    {
        [JsonProperty("iss")]
        public string Issuer { get; set; }

        [JsonProperty("aud")]
        public string Audience { get; set; }

        [JsonProperty("nbf")]
        public long ValidNotBefore { get; set; }

        [JsonProperty("exp")]
        public long ExpirationTime { get; set; }

        [JsonProperty("iat")]
        public long IssuedAt { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }
    }
}
