﻿using Digirati.IIIF.Model.JsonLD;
using Newtonsoft.Json;

namespace Digirati.IIIF.Model.Types
{
    public class Annotation : JSONLDBase, IAnnotation
    {
        [JsonProperty(Order = 10, PropertyName = "motivation")]
        public virtual string Motivation { get; set; }

        public override string Type
        {
            get { return "oa:Annotation"; }
        }

        [JsonProperty(Order = 40, PropertyName = "resource")]
        public JSONLDBase Resource { get; set; }

        // TODO - on can be an object with an @id and a "within" as well as a URI
        // "on" : {
        //  "@id": "http://example.org/identifier/canvas1#xywh=100,100,250,20",
        //  "within": {
        //    "@id": "http://example.org/identifier/manifest",
        //    "type": "sc:Manifest",
        //    "label": "Example Manifest"
        //  }
        // }
        [JsonProperty(Order = 50, PropertyName = "on")]
        public string On { get; set; }
    }
}
