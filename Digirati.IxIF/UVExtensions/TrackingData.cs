using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Digirati.IIIF.Model.Types;
using Digirati.IxIF;
using Newtonsoft.Json;

namespace Digirati.IIIF.UVExtensions
{
    public class TrackingData : GenericService
    {
        public override dynamic Context
        {
            get { return ExtensionUriPatterns.UVContext; }
        }
        public override dynamic Profile
        {
            get { return "http://universalviewer.io/tracking-extensions-profile"; }
        }
        
        [JsonProperty(Order = 102, PropertyName = "trackingLabel")]
        public string TrackingLabel { get; set; }

    }
}
