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
        List<JSONLDString> Description { get; set; }
        List<ImageResource> Thumbnail { get; set; }
        List<JSONLDString> Attribution { get; set; }
        List<string> License { get; set; }
        List<ImageResource> Logo { get; set; }
        List<Resource> Rendering { get; set; }
        List<Resource> Related { get; set; }
        List<Resource> SeeAlso { get; set; }
        List<Service> Service { get; set; }
        string ViewingHint { get; set; }
        string NavDate { get; set; }
        List<Resource> OtherContent { get; set; }
        List<IPresentationResource> Within { get; set; }

        /// <summary>
        /// Only support external contexts for now; allow more than one
        /// </summary>
        List<string> Context { get; set; }

        string Id { get; set; }
        string Type { get; set; }
    }
}
