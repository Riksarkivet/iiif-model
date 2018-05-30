using Newtonsoft.Json;
using System.Collections.Generic;

namespace Digirati.IIIF3.Model.JSONLD
{
    public abstract class JSONLDBase
    {
        /// <summary>
        /// Only support external contexts for now; allow more than one
        /// </summary>
        [JsonProperty(Order = 1, PropertyName = "@context")]
        public virtual List<string> Context { get; set; }
        [JsonProperty(Order = 2)]
        public string Id { get; set; }
        [JsonProperty(Order = 3)]
        public virtual string Type { get; set; }
    }
}
