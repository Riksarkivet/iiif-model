using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Digirati.IIIF3.Model.JSONLD;
using Newtonsoft.Json;

namespace Digirati.IIIF3.Model.Types
{
    public abstract class PresentationBase : JSONLDBase, IPresentationResource
    {
        [JsonProperty(Order = -50)]
        public JSONLDString Label { get; set; }

        [JsonProperty(Order = -50)]
        public List<Metadata> Metadata { get; set; }

        [JsonProperty(Order = -50)]
        public JSONLDString Summary { get; set; }

        [JsonProperty(Order = -50)]
        public List<ImageResource> Thumbnail { get; set; }

        [JsonProperty(Order = -50)]
        public List<string> Behavior { get; set; }

        [JsonProperty(Order = -50)]
        public string Rights { get; set; }

        [JsonProperty(Order = -50)]
        public Metadata RequiredStatement { get; set; }

        [JsonProperty(Order = -50)]
        public List<ImageResource> Logo { get; set; }

        [JsonProperty(Order = -50)]
        public Resource Homepage { get; set; }

        [JsonProperty(Order = -50)]
        public List<Service> Service { get; set; }

        [JsonProperty(Order = -50)]
        public List<Resource> SeeAlso { get; set; }

        [JsonProperty(Order = -50)]
        public List<Resource> Rendering { get; set; }

        [JsonProperty(Order = -50)]
        public List<Resource> PartOf { get; set; }
    }
}
