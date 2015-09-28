using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Digirati.IIIF.Model.Types;
using Newtonsoft.Json;
using Digirati.IxIF;

namespace Digirati.IIIF.Model
{
    public class AcceptTermsService : GenericService
    {
        public override dynamic Context
        {
            get { return ExtensionUriPatterns.UVContext; }
        }
        public override dynamic Profile
        {
            get { return "http://wellcomelibrary.org/ld/iiif-ext/0/accept-terms-click-through"; }
        }
        
        // do we need an extra setting to tell a viewer whether it can "pull through" (import into interface)?
        [JsonProperty(Order = 102, PropertyName = "fullTerms")]
        public string FullTerms { get; set; }

        [JsonProperty(Order = 102, PropertyName = "fullTermsSimple")]
        public string FullTermsSimple { get; set; }

        [JsonProperty(Order = 103, PropertyName = "actionLabel")]
        public MetaDataValue ActionLabel { get; set; }

        //[JsonProperty(Order = 103, PropertyName = "autoClosingVersionOfId")]
        //public string AutoClosingVersionOfId { get; set; }

    }
}
