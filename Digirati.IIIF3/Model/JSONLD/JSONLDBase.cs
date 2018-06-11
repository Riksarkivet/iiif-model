using Newtonsoft.Json;
using System.Collections.Generic;

namespace Digirati.IIIF3.Model.JSONLD
{
    public abstract class JSONLDBase
    {
        /// <summary>
        /// Only support external contexts for now; allow more than one
        /// </summary>
        [JsonProperty(Order = -100, PropertyName = "@context")]
        public virtual List<string> Context { get; set; }
        [JsonProperty(Order = -100)]
        public string Id { get; set; }
        [JsonProperty(Order = -99)]
        public virtual string Type { get; set; }
    }
}
