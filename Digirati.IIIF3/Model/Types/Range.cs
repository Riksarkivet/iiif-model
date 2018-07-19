using Digirati.IIIF3.Model.JSONLD;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Digirati.IIIF3.Model.Types
{
    public class Range : PresentationBase
    {
        public List<Range> Items { get; set; }
    }
}
