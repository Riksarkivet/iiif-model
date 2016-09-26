using Newtonsoft.Json;

namespace Digirati.IIIF.Model.Types.Auth
{
    public class Token : ITokenResponse
    {
        public string MessageId { get; set; }

        [JsonProperty(Order = 1, PropertyName = "accessToken")]
        public string AccessToken { get; set;}

        [JsonProperty(Order = 2, PropertyName = "tokenType")]
        public const string TokenType = "Bearer";

        [JsonProperty(Order = 3, PropertyName = "expiresIn")]
        public int ExpiresIn { get; set;}

    }
}
