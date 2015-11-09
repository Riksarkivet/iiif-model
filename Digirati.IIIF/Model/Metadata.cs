using Newtonsoft.Json;

namespace Digirati.IIIF.Model
{
    public class Metadata
    {
        [JsonProperty(Order = 1, PropertyName = "label")]
        public MetaDataValue[] Label { get; set; }

        [JsonProperty(Order = 2, PropertyName = "value")]
        public MetaDataValue[] Value { get; set; }
    }
}
