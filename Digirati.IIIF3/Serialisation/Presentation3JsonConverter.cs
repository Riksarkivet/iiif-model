using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Digirati.IIIF3.Model.JSONLD;
using Digirati.IIIF3.Model.Types;
using Newtonsoft.Json.Linq;

namespace Digirati.IIIF3.Serialisation
{
    public class Presentation3JsonConverter : IPresentationJsonConverter
    {
        public JObject Convert(IPresentationResource resource)
        {
            var manifest = resource as Manifest;
            if (manifest == null)
            {
                throw new Exception("Only manifests supported for now! No collections yet!");
            }
            var jManifest = new JObject();
            jManifest["type"] = "Manifest";
            PopulateBase(manifest, jManifest);
            //AddSequences(manifest, jManifest);
            return jManifest;
        }

        //private void AddSequences(Manifest manifest, JObject jManifest)
        //{
        //    var sequences = new JArray();
        //    foreach (var sequence in manifest.Sequences)
        //    {
        //        sequences.Add(ConvertSequence(sequence));
        //    }
        //    jManifest["sequences"] = sequences;
        //}

        private JToken ConvertSequence(Sequence sequence)
        {
            var jSequence = new JObject();
            jSequence["type"] = "Sequence";
            PopulateBase(sequence, jSequence);
            if (sequence.StartCanvas.HasContent())
            {
                jSequence["startCanvas"] = sequence.StartCanvas;
            }
            if (sequence.ViewingDirection.HasContent())
            {
                jSequence["viewingDirection"] = sequence.ViewingDirection;
            }
            AddCanvases(sequence, jSequence);
            return jSequence;
        }

        private void AddCanvases(Sequence sequence, JObject jSequence)
        {
            var canvases = new JArray();
            foreach (var canvas in sequence.Canvases)
            {
                canvases.Add(ConvertCanvas(canvas));
            }
            jSequence["canvases"] = canvases;
        }

        private JToken ConvertCanvas(Canvas canvas)
        {
            var jCanvas = new JObject();
            jCanvas["type"] = "Canvas";
            PopulateBase(canvas, jCanvas);
            if (canvas.Width > 0)
            {
                jCanvas["width"] = canvas.Width;
            }
            if (canvas.Height > 0)
            {
                jCanvas["height"] = canvas.Height;
            }
            if (canvas.Duration > 0)
            {
                jCanvas["duration"] = canvas.Duration;
            }
            return jCanvas;
        }


        private void PopulateBase(IPresentationResource iiifResource, JObject jResource)
        {
            jResource["id"] = iiifResource.Id;
            //if (iiifResource.Label.HasContent())
            //{
            //    jResource["label"] = ConvertList(iiifResource.Label);
            //}
            if (iiifResource.Description.HasContent())
            {
                jResource["description"] = ConvertList(iiifResource.Description);
            }
            if (iiifResource.Thumbnail.HasContent())
            {
                jResource["thumbnail"] = ConvertList(iiifResource.Thumbnail);
            }
            if (iiifResource.Attribution.HasContent())
            {
                jResource["attribution"] = ConvertList(iiifResource.Attribution);
            }
            if (iiifResource.Metadata.HasContent())
            {
                jResource["metadata"] = ConvertList(iiifResource.Metadata);
            }
            if (iiifResource.License.HasContent())
            {
                jResource["license"] = ConvertList(iiifResource.License);
            }
            if (iiifResource.Logo.HasContent())
            {
                jResource["logo"] = ConvertList(iiifResource.Logo);
            }
            if (iiifResource.Rendering.HasContent())
            {
                jResource["rendering"] = ConvertList(iiifResource.Rendering);
            }
            if (iiifResource.Related.HasContent())
            {
                jResource["related"] = ConvertList(iiifResource.Related);
            }
            if (iiifResource.SeeAlso.HasContent())
            {
                jResource["related"] = ConvertList(iiifResource.SeeAlso);
            }
            if (iiifResource.Service.HasContent())
            {
                jResource["service"] = ConvertList(iiifResource.Service);
            }
            if (iiifResource.ViewingHint.HasContent())
            {
                jResource["viewingHint"] = iiifResource.ViewingHint;
            }
            if (iiifResource.NavDate.HasContent())
            {
                jResource["navDate"] = iiifResource.NavDate;
            }
            if (iiifResource.OtherContent.HasContent())
            {
                jResource["otherContent"] = ConvertList(iiifResource.OtherContent);
            }
            if (iiifResource.Within.HasContent())
            {
                jResource["within"] = ConvertList(iiifResource.Within);
            }
        }

        private JArray ConvertList(List<IPresentationResource> withins)
        {
            return null; // TODO
        }

        private JArray ConvertList(List<Resource> resources)
        {
            var ja = new JArray();
            foreach (var resource in resources)
            {
                if (IsUriOnly(resource))
                {
                    ja.Add(resource.Id);
                }
                else
                {
                    ja.Add(ConvertResource(resource));
                }
            }
            return ja;
        }

        private JObject ConvertResource(Resource resource)
        {
            var jObject = new JObject();
            PopulateResource(jObject, resource);
            return jObject;
        }

        private JArray ConvertList(List<ImageResource> imageResources)
        {
            var ja = new JArray();
            foreach (var imageResource in imageResources)
            {
                ja.Add(GetImageResource(imageResource));
            }
            return ja;
        }

        private JToken GetImageResource(ImageResource imageResource)
        {
            if (IsUriOnly(imageResource))
            {
                return imageResource.Id;
            }
            var jObject = new JObject();
            PopulateResource(jObject, imageResource);
            if (imageResource.Height > 0)
            {
                jObject["height"] = imageResource.Height;
            }
            if (imageResource.Width > 0)
            {
                jObject["width"] = imageResource.Width;
            }
            return jObject;
        }

        private void PopulateResource(JObject jResource, Resource iiifResource)
        {
            PopulateExternalResource(jResource, iiifResource);
            if (iiifResource.Format.HasContent())
            {
                jResource["format"] = iiifResource.Format;
            }
        }
        private void PopulateExternalResource(JObject jResource, ExternalResource iiifResource)
        {
            PopulateBaseJsonLdBase(jResource, iiifResource);
            if (iiifResource.Label.HasContent())
            {
                jResource["label"] = ConvertList(iiifResource.Label);
            }
            if (iiifResource.Profile.HasContent())
            {
                jResource["profile"] = ConvertList(iiifResource.Profile);
            }
            if (iiifResource.Service.HasContent())
            {
                jResource["service"] = ConvertList(iiifResource.Service);
            }
        }

        private void PopulateBaseJsonLdBase(JObject jResource, JSONLDBase jsonldBase)
        {
            if (jsonldBase.Id.HasContent())
            {
                jResource["id"] = jsonldBase.Id;
            }
            if (jsonldBase.Type.HasContent())
            {
                jResource["type"] = jsonldBase.Type;
            }
            // TODO - Context
        }


        private JArray ConvertList(List<Service> services)
        {
            return null; // TODO - convert by type...
        }

        private JArray ConvertList(List<Profile> profiles)
        {
            return null;
        }

        private bool IsUriOnly(ExternalResource externalResource)
        {
            Type t = externalResource.GetType();
            foreach (var f in t.GetFields().Where(f => f.IsPublic))
            {
                var value = f.GetValue(externalResource);
                if (f.Name != "Id" && value.HasContent())
                {
                    return false;
                }
            }
            return true;
        }

        private JArray ConvertList(List<string> strings)
        {
            var ja = new JArray();
            foreach (var s in strings)
            {
                ja.Add(GetToken(s));
            }
            return ja;
        }

        private JArray ConvertList(List<Metadata> metadata)
        {
            var ja = new JArray();
            foreach (var m in metadata)
            {
                var jm = new JObject
                {
                    ["label"] = GetToken(m.Label),
                    ["value"] = GetToken(m.Value)
                };
                ja.Add(jm);
            }
            return ja;
        }


        public static JArray ConvertList(List<JSONLDString> jldStrings)
        {
            var ja = new JArray();
            foreach (var jsonldString in jldStrings)
            {
                ja.Add(GetToken(jsonldString));
            }
            return ja;
        }

        private static JToken GetToken(JSONLDString jsonldString)
        {
            // TODO - multi lang strings
            return jsonldString.ToString();
        }
    }

}
