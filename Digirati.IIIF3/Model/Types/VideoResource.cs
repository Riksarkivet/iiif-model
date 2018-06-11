using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Digirati.IIIF3.Model.Types
{
    public class VideoResource : Resource
    {
        public int? Width { get; set; }
        public int? Height { get; set; }
        public float? Duration { get; set; }
    }
}
