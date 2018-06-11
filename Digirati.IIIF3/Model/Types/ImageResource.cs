using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Digirati.IIIF3.Model.Types
{
    public class ImageResource : Resource
    {
        public int? Width { get; set; }
        public int? Height { get; set; }

        public ImageResource(string imageUrl)
        {
            Id = imageUrl;
        }

        public override string Type => "Image";
    }
}
