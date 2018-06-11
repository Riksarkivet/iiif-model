namespace Digirati.IIIF3
{
    public abstract class UriPatterns
    {
        public const string JsonLdContext = "http://www.w3.org/ns/anno.jsonld";

        public const string Presentation2Context = "http://iiif.io/api/presentation/2/context.json";
        public const string Presentation3Context = "http://iiif.io/api/presentation/3/context.json";

        public const string Image2Context = "http://iiif.io/api/image/2/context.json";
        public const string Image2ServiceProfileLevel0 = "http://iiif.io/api/image/2/level0.json";
        public const string Image2ServiceProfileLevel1 = "http://iiif.io/api/image/2/level1.json";
        public const string Image2ServiceProfileLevel2 = "http://iiif.io/api/image/2/level2.json";

        public const string Auth0Context = "http://iiif.io/api/auth/0/context.json";
        public const string Auth0LoginServiceProfile = "http://iiif.io/api/auth/0/login";
        public const string Auth090LoginClickthroughServiceProfile = "http://iiif.io/api/auth/0/login/clickthrough";
        public const string Auth093LoginClickthroughServiceProfile = "http://iiif.io/api/auth/0/clickthrough";
        public const string Auth090LoginExternalServiceProfile = "http://iiif.io/api/auth/0/login/restricted";
        public const string Auth093LoginExternalServiceProfile = "http://iiif.io/api/auth/0/external";
        public const string Auth0LogoutServiceProfile = "http://iiif.io/api/auth/0/logout";
        public const string Auth0TokenServiceProfile = "http://iiif.io/api/auth/0/token";
        
        public const string Auth1Context = "http://iiif.io/api/auth/1/context.json";

        public const string Search0Context = "http://iiif.io/api/search/0/context.json";
        public const string Search1Context = "http://iiif.io/api/search/1/context.json";
        

        // recommended patterns
        public virtual string Collection
        {
            get { return "{scheme}://{host}/{prefix}/collection/{name}"; }
        }

        public virtual string Manifest
        {
            get { return "{scheme}://{host}/{prefix}/{identifier}/manifest"; }
        }

        public virtual string Sequence
        {
            get { return "{scheme}://{host}/{prefix}/{identifier}/sequence/{name}"; }
        }

        public virtual string Canvas
        {
            get { return "{scheme}://{host}/{prefix}/{identifier}/canvas/{name}"; }
        }

        public virtual string Annotation
        {
            get { return "{scheme}://{host}/{prefix}/{identifier}/annotation/{name}"; }
        }

        public virtual string AnnotationList
        {
            get { return "{scheme}://{host}/{prefix}/{identifier}/list/{name}"; }
        }

        public virtual string Range
        {
            get { return "{scheme}://{host}/{prefix}/{identifier}/range/{name}"; }
        }

        public virtual string Layer
        {
            get { return "{scheme}://{host}/{prefix}/{identifier}/layer/{name}"; }
        }

        public virtual string Content
        {
            get { return "{scheme}://{host}/{prefix}/{identifier}/res/{name}.{format}"; }
        }

    }
}
