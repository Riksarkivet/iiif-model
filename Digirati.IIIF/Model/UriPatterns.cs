using System.Globalization;

namespace Digirati.IIIF.Model
{
    public static class UriPatterns
    {
        public const string IIIF2PreziContext = "http://iiif.io/api/presentation/2/context.json";
        public const string IIIF2ImageContext = "http://iiif.io/api/image/2/context.json";

        public const string ImageServiceProfile = "http://iiif.io/api/image/2/level1.json";
        public const string ImageServiceLevel0Profile = "http://iiif.io/api/image/2/level0.json";
        public const string LoginServiceProfile = "http://iiif.io/api/auth/0/login";
        public const string LogoutServiceProfile = "http://iiif.io/api/auth/0/logout";
        public const string AuthTokenServiceProfile = "http://iiif.io/api/auth/0/token";

        // recommended patterns
        public const string Collection = "{scheme}://{host}/{prefix}/collection/{name}";
        public const string Manifest = "{scheme}://{host}/{prefix}/{identifier}/manifest";
        public const string Sequence = "{scheme}://{host}/{prefix}/{identifier}/sequence/{name}";
        public const string Canvas = "{scheme}://{host}/{prefix}/{identifier}/canvas/{name}";
        public const string Annotation = "{scheme}://{host}/{prefix}/{identifier}/annotation/{name}";
        public const string AnnotationList = "{scheme}://{host}/{prefix}/{identifier}/list/{name}";
        public const string Range = "{scheme}://{host}/{prefix}/{identifier}/range/{name}";
        public const string Layer = "{scheme}://{host}/{prefix}/{identifier}/layer/{name}";
        public const string Content = "{scheme}://{host}/{prefix}/{identifier}/res/{name}.{format}";

        // Image service URI
        public const string ImageResource = "{scheme}://{host}/{prefix}/{identifier}-{seqIndex}/res/{name}";


        // Our extensions ss IIIF:                        {scheme}://{host}{/prefix}/{___________identifier___________}/{region}/{size}/{rotation}/{quality}.{format}
        public const string ImageService = "{scheme}://{host}/{prefix}-img/{identifier}-{seqIndex}/{name}";
        public const string ImageAnnotation = "{scheme}://{host}/{prefix}/{identifier}/imageanno/{name}";
        public const string OcrAltoContent = "{scheme}://{host}/{prefix}/{identifier}/contentAsText/{name}";
        public const string TextLineAnnotation = "{scheme}://{host}/{prefix}/{identifier}/annos/contentAsText/{name}";
        public const string SearchResultAnnotation = "{scheme}://{host}/{prefix}/{identifier}/annos/searchResults/{name}";

        // X extensions:
        public const string Element = "{scheme}://{host}/{prefix}/{identifier}/element/{name}";
        public const string TranscriptAnnotation = "{scheme}://{host}/{prefix}/{identifier}/transcript/{name}";
        
        public const string MediaElementService = "{scheme}://{host}/iiif-media/{identifier}-{seqIndex}/{name}";
        public const string MediaElementServiceProfile = "http://wellcomelibrary.org/ld/ixif/0/alpha.json";

        // Transition
        public const string WellcomeThumbs = "{scheme}://{host}";


        public static string WithIdentifier(this string s, string identifier)
        {
            return s.Replace("{identifier}", identifier);
        }

        public static string WithName(this string s, string name)
        {
            return s.Replace("{name}", name);
        }

        public static string WithNumericalName(this string s, string prefix, int index)
        {
            return s.Replace("{name}", prefix + index);
        }

        public static string WithSequenceIndex(this string s, int index)
        {
            return s.Replace("{seqIndex}", index.ToString(CultureInfo.InvariantCulture));
        }

        public static MetaDataValue AsMetaDataValue(this string s)
        {
            return new MetaDataValue(s);
        }
    }
}
