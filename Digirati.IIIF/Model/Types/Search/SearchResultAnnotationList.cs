using Digirati.IIIF.Model.Types;
using Digirati.IIIF.Model.Types.Search;
using Newtonsoft.Json;

namespace Digirati.IIIF.Model.Extension
{
    public class SearchResultAnnotationList : AnnotationList
    {
        public override dynamic Context
        {
            get { return "http://iiif.io/api/search/0/context.json"; }
        }

        [JsonProperty(Order = 10, PropertyName = "within")]
        public SearchResultsLayer Within { get; set; }

        [JsonProperty(Order = 12, PropertyName = "previous")]
        public string Previous { get; set; }

        [JsonProperty(Order = 13, PropertyName = "next")]
        public string Next { get; set; }
        
        [JsonProperty(Order = 16, PropertyName = "startIndex")]
        public int StartIndex { get; set; }

        [JsonProperty(Order = 30, PropertyName = "hits")]
        public Hit[] Hits { get; set; }
    }
}
