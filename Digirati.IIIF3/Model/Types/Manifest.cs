using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace Digirati.IIIF3.Model.Types
{
    public class Manifest : PresentationBase
    {
        public string ViewingDirection { get; set; }

        public string NavDate { get; set; }

        public Canvas PosterCanvas { get; set; }

        public Resource Start { get; set; }

        public List<Canvas> Items { get; set; }

        public List<Range> Structures { get; set; }

        public List<AnnotationPage> Annotations { get; set; }

        public override string Type => "Manifest";
        
    }
}
