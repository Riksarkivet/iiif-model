using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Digirati.IIIF3.Model.JSONLD;
using Digirati.IIIF3.Model.Types;

namespace Digirati.IIIF3
{
    public interface IPresentationResource
    {
        JSONLDString Label { get; set; }
        List<Metadata> Metadata { get; set; }
        JSONLDString Summary { get; set; }
        List<ImageResource> Thumbnail { get; set; }
        Metadata RequiredStatement { get; set; }
        string Rights { get; set; }
        List<string> Behavior { get; set; }
        List<ImageResource> Logo { get; set; }
        Resource Homepage { get; set; }
        List<Resource> Rendering { get; set; }
        List<Service> Service { get; set; }
        List<Resource> SeeAlso { get; set; }
        List<Resource> PartOf { get; set; }

        /// <summary>
        /// Only support external contexts for now; allow more than one
        /// </summary>
        List<string> Context { get; set; }

        string Id { get; set; }
        string Type { get; set; }
    }
}
