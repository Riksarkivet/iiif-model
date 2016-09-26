using Newtonsoft.Json;

namespace Digirati.IIIF.Model.Types.Auth
{
    public class AccessCookieService : GenericService
    {
        private readonly string profile;

        AccessCookieService(string profile)
        {
            this.profile = profile;
        }

        public override dynamic Context
        {
            get { return UriPatterns.IIIFAuthContext; }
        }
        public override dynamic Profile
        {
            get { return profile; }
        }

        [JsonProperty(Order = 103, PropertyName = "confirmLabel")]
        public MetaDataValue ConfirmLabel { get; set; }

        [JsonProperty(Order = 111, PropertyName = "header")]
        public MetaDataValue Header { get; set; }

        [JsonProperty(Order = 121, PropertyName = "failureHeader")]
        public MetaDataValue FailureHeader { get; set; }

        [JsonProperty(Order = 122, PropertyName = "failureDescription")]
        public MetaDataValue FailureDescription { get; set; }


        public static AccessCookieService NewLoginInstance()
        {
            return new AccessCookieService(UriPatterns.LoginServiceProfile);
        }
        public static AccessCookieService NewClickthrough090Instance()
        {
            return new AccessCookieService(UriPatterns.LoginClickthroughServiceProfile090);
        }
        public static AccessCookieService NewClickthrough093Instance()
        {
            return new AccessCookieService(UriPatterns.LoginClickthroughServiceProfile093);
        }
        public static AccessCookieService NewExternal090Instance()
        {
            return new AccessCookieService(UriPatterns.LoginExternalServiceProfile090);
        }
        public static AccessCookieService NewExternal093Instance()
        {
            return new AccessCookieService(UriPatterns.LoginExternalServiceProfile093);
        }
    }
}
