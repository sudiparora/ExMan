using Newtonsoft.Json;

namespace PerFin.Entities.Authentication
{
    public class BearerTokenInfo
    {
        [JsonProperty("access_token")]
        public string AccessToken { get; set; }
        [JsonProperty("token_type")]
        public string TokenType { get; set; }
        [JsonProperty("expires_in")]
        public int ExpiresIn { get; set; }
        [JsonProperty("userName")]
        public string Username { get; set; }
        [JsonProperty("error")]
        public string Error { get; set; }
    }
}
