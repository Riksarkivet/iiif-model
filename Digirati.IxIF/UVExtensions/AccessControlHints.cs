using Digirati.IIIF.Model.Types;
using Digirati.IIIF.Serialisation;
using Digirati.IxIF;
using Newtonsoft.Json;

namespace Digirati.IIIF.UVExtensions
{
    /// <summary>
    /// Bespoke service to assist client applications. This is not used by the UV, it's more
    /// for very simple JavaScript apps that can detect whether any auth is likely to be required
    /// in the manifest on which the service is asserted and if so what kind of auth.
    /// 
    /// Specific use case: https://wellcome-sandbox.herokuapp.com/
    /// </summary>
    public class AccessControlHints : GenericService
    {
        public override dynamic Context
        {
            get { return ExtensionUriPatterns.WdlExtensionsContext; }
        }
        public override dynamic Profile
        {
            get { return "http://wellcomelibrary.org/ld/iiif-ext/access-control-hints"; }
        }
        
        [JsonProperty(Order = 120, PropertyName = "accessHint")]
        public string AccessHint { get; set; }


        [JsonProperty(Order = 130, PropertyName = "authService")]
        [JsonConverter(typeof(ServiceSerialiser))]
        public dynamic AuthService { get; set; } // object or array of objects
    }
}
