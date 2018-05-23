using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Digirati.IIIF3.Model.JSONLD;
using Newtonsoft.Json;

namespace Digirati.IIIF3.Model.Types
{
    public class Resource : ExternalResource
    {
        [JsonProperty(Order = 30)]
        public string Format { get; set; }
    }
}
