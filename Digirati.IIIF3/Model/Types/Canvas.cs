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
        public string NavDate { get; set; }

        public int Width { get; set; }

        public int Height { get; set; }

        public float? Duration { get; set; }

        public Canvas PosterCanvas { get; set; }

        public List<AnnotationPage> Items { get; set; }

        public List<AnnotationPage> Annotations { get; set; }

        public override string Type => "Canvas";
    }
}
