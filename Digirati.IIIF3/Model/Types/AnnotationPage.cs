using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Digirati.IIIF3.Model.JSONLD;
using Newtonsoft.Json;

namespace Digirati.IIIF3.Model.Types
{
    public class AnnotationPage : JSONLDBase
    {
        [JsonProperty(Order = 30)]
        public List<Annotation> Items { get; set; }
        public List<JSONLDString> Label { get; set; }
    }
}
