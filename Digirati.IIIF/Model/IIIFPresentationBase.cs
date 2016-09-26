using Digirati.IIIF.Model.JsonLD;
using Digirati.IIIF.Model.Types;
using Digirati.IIIF.Serialisation;
using Newtonsoft.Json;

namespace Digirati.IIIF.Model
{
    public abstract class IIIFPresentationBase : JSONLDBase
    {
        [JsonProperty(Order = 11, PropertyName = "label")]
        public MetaDataValue[] Label { get; set; }

        [JsonProperty(Order = 12, PropertyName = "metadata")]
        public Metadata[] Metadata { get; set; }

        [JsonProperty(Order = 14, PropertyName = "description")]
        public MetaDataValue[] Description { get; set; }

        [JsonProperty(Order = 15, PropertyName = "thumbnail")]
        public dynamic Thumbnail { get; set; }

        [JsonProperty(Order = 16, PropertyName = "attribution")]
        public MetaDataValue Attribution { get; set; }

        [JsonProperty(Order = 17, PropertyName = "license")]
        public string License { get; set; }

        [JsonProperty(Order = 18, PropertyName = "logo")]
        public string Logo { get; set; }

        [JsonProperty(Order = 24, PropertyName = "rendering")]
        public dynamic Rendering { get; set; }

        [JsonProperty(Order = 25, PropertyName = "related")]
        public Resource Related { get; set; }

        [JsonProperty(Order = 26, PropertyName = "seeAlso")]
        public Resource SeeAlso { get; set; }

        [JsonProperty(Order = 27, PropertyName = "service")]
        [JsonConverter(typeof(ServiceSerialiser))]
        public dynamic Service { get; set; } // object or array of objects


        [JsonProperty(Order = 30, PropertyName = "viewingHint")]
        public string ViewingHint { get; set; }
        
        [JsonProperty(Order = 32, PropertyName = "navDate")]
        public string NavDate { get; set; }

        [JsonProperty(Order = 60, PropertyName = "otherContent")]
        public IAnnotationListReference[] OtherContent { get; set; }

        [JsonProperty(Order = 70, PropertyName = "within")]
        public string Within { get; set; }

    }
}
