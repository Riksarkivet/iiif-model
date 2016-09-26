using Newtonsoft.Json;

namespace Digirati.IIIF.Model.Types
{
    public class ImageResource : Resource
    {
        public override string Type
        {
            get { return "dctypes:Image"; }
        }

        [JsonProperty(Order = 35, PropertyName = "height")]
        public int? Height { get; set; }

        [JsonProperty(Order = 36, PropertyName = "width")]
        public int? Width { get; set; }
    }
}
