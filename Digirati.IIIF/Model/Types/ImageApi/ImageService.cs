using Digirati.IIIF.Model.JsonLD;
using Digirati.IIIF.Serialisation;
using Newtonsoft.Json;

namespace Digirati.IIIF.Model.Types.ImageApi
{
    // Also known as an "info.json"
    public class ImageService : JSONLDBase, IImageService, IHasService
    {
        // Allow additional context
        //public override dynamic Context
        //{
        //    get { return "http://iiif.io/api/image/2/context.json"; }
        //}

        [JsonProperty(Order = 4, PropertyName = "protocol")]
        public string Protocol
        {
            get { return "http://iiif.io/api/image"; }
        }

        [JsonProperty(Order = 35, PropertyName = "height")]
        public int Height { get; set; }

        [JsonProperty(Order = 36, PropertyName = "width")]
        public int Width { get; set; }


        [JsonProperty(Order = 37, PropertyName = "sizes")]
        public Size[] Sizes { get; set; }

        [JsonProperty(Order = 38, PropertyName = "tiles")]
        public TileSource[] Tiles { get; set; }

        // IProfile or IProfile[]
        [JsonProperty(Order = 39, PropertyName = "profile")]
        [JsonConverter(typeof(ProfileSerialiser))]
        public dynamic Profile { get; set; }

        // Service or Service[] - not currently an interface
        [JsonProperty(Order = 99, PropertyName = "service")]
        [JsonConverter(typeof(ServiceSerialiser))]
        public dynamic Service { get; set; }
    }
}
