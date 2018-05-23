using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Digirati.IIIF3.Model.Types
{
    public class Sequence : PresentationBase
    {
        public string StartCanvas { get; set; }

        public string ViewingDirection { get; set; }
        [JsonProperty(Order = 30)]
        public List<Canvas> Canvases { get; set; }
    }
}
