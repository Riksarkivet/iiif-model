using Newtonsoft.Json;

namespace Digirati.IIIF.Model.Types.ImageApi
{
    public class ImageServiceProfile : IProfile
    {
        [JsonProperty(Order = 1, PropertyName = "formats")]
        public string[] Formats { get; set; }

        [JsonProperty(Order = 2, PropertyName = "qualities")]
        public string[] Qualities { get; set; }

        [JsonProperty(Order = 3, PropertyName = "supports")]
        public string[] Supports { get; set; }

        // 2.1
        [JsonProperty(Order = 4, PropertyName = "maxWidth")]
        public int MaxWidth { get; set; }
    }
}
