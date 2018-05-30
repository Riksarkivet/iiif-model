using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace Digirati.IIIF3.Model.Types
{
    public class Manifest : PresentationBase
    {
        [JsonProperty(Order = 31)]
        public string ViewingDirection { get; set; }

        [JsonProperty(Order = 40)]
        public List<Canvas> Items { get; set; }

        //[JsonProperty(Order = 40)]
        //public List<Sequence> Sequences { get; set; }

        [JsonProperty(Order = 50)]
        public List<Range> Structures { get; set; }

        public override string Type => "Manifest";
        
    }
}
