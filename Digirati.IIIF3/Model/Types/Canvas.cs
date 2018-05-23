using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using Digirati.IIIF3.Model.Types;
using Newtonsoft.Json;

namespace Digirati.IIIF3.Model.Types
{
    public class Canvas : PresentationBase
    {
        [JsonProperty(Order = 11)]
        public int Width { get; set; }
        [JsonProperty(Order = 12)]
        public int Height { get; set; }
        [JsonProperty(Order = 13)]
        public float Duration { get; set; }
        [JsonProperty(Order = 30)]
        public List<AnnotationPage> Content { get; set; } 
    }
}
