using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Digirati.IIIF3.Model.JSONLD;
using Newtonsoft.Json;

namespace Digirati.IIIF3.Model.Types
{
    public class Annotation : JSONLDBase
    {

        public List<JSONLDString> Label { get; set; }
        [JsonProperty(Order = 11)]
        public string Motivation { get; set; }
        [JsonProperty(Order = 30)]
        public Resource Body { get; set; }
        [JsonProperty(Order = 12)]
        public string Target { get; set; }
        public override string Type => "Annotation";

    }
}
