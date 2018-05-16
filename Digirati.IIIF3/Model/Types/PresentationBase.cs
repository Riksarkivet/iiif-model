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
        [JsonProperty(Order = 11)]
        public JSONLDString Label { get; set; }

        [JsonProperty(Order = 12)]
        public List<Metadata> Metadata { get; set; }
        
        public List<JSONLDString> Description { get; set; }

        public List<ImageResource> Thumbnail { get; set; }

        public List<JSONLDString> Attribution { get; set; }

        public List<string> License { get; set; }

        public List<ImageResource> Logo { get; set; }

        public List<Resource> Rendering { get; set; }

        public List<Resource> Related { get; set; }

        public List<Resource> SeeAlso { get; set; }

        public List<Service> Service { get; set; }
        
        public string ViewingHint { get; set; }

        public string NavDate { get; set; }

        public List<Resource> OtherContent { get; set; }

        public List<IPresentationResource> Within { get; set; }
    }
}
