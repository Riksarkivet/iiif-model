using System;
using Digirati.IIIF.Model;
using Digirati.IIIF.Model.Types;
using Digirati.IIIF.Model.Types.ImageApi;
using Newtonsoft.Json;

namespace Harness.Test
{
    class Program
    {
        static void Main(string[] args)
        {
            CreateTestManifest();


        }

        static void CreateTestManifest()
        {
            Manifest manifest = new Manifest
            {
                Context = "http://iiif.io/api/presentation/2/context.json",
                Id = "2ceafb89-8d6a-409e-9ff7-f57fe1866f3a",
                Label = new MetaDataValue[] { new MetaDataValue("Monsters") },
                Metadata = new Metadata[]
                {
                    new Metadata
                    {
                        Label = new MetaDataValue[] { new MetaDataValue("label") },
                        Value = new MetaDataValue[] { new MetaDataValue("hello") }
                    },
                },
                Sequences = new Sequence[]
                {
                    new Sequence
                    {
                        Id = "http://www.fractos.com/iiif/monster/2ceafb89-8d6a-409e-9ff7-f57fe1866f3a/sequence/s0",
                        Label = new MetaDataValue[] { new MetaDataValue("Sequence s0") } ,
                        ViewingHint = "paged",
                        Canvases = new Canvas[]
                        {
                            new Canvas
                            {
                                Id =
                                    "http://www.fractos.com/iiif/monster/2ceafb89-8d6a-409e-9ff7-f57fe1866f3a/canvas/c0",
                                Label = new MetaDataValue[] { new MetaDataValue(" - ") },
                                Thumbnail =
                                    "http://www.fractos.com/iiif/monster/thumbnails/bookofmonsters00smfair_0000.jpg",
                                Height = 4368,
                                Width = 2912,
                                Images = new ImageAnnotation[]
                                {
                                    new ImageAnnotation
                                    {
                                        Id = "http://www.fractos.com/iiif/monster/2ceafb89-8d6a-409e-9ff7-f57fe1866f3a/imageanno/edc5eb71-8559-4f42-a848-70b4590172da",
                                        On = "http://www.fractos.com/iiif/monster/2ceafb89-8d6a-409e-9ff7-f57fe1866f3a/canvas/c0",
                                        Resource = new ImageResource
                                        {
                                            Id =
                                                "http://www.fractos.com/iiif/monster/2ceafb89-8d6a-409e-9ff7-f57fe1866f3a-0/res/edc5eb71-8559-4f42-a848-70b4590172da",
                                            Height = 4368,
                                            Width = 2912,
                                            Service = new ImageService
                                            {
                                                Id =
                                                    "http://dlcs.io/iiif-img/monster/edc5eb71-8559-4f42-a848-70b4590172da",
                                                Profile = "http://iiif.io/api/image/2/level1.json"
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                },
                Structures = new Range[]
                {
                    new Range
                    {
                        Id = "http://www.fractos.com/iiif/monster/2ceafb89-8d6a-409e-9ff7-f57fe1866f3a/range/r-0",
                        Label = new MetaDataValue[] { new MetaDataValue("Front Cover") },
                        Canvases = new string[]
                        {
                            "http://www.fractos.com/iiif/monster/2ceafb89-8d6a-409e-9ff7-f57fe1866f3a/canvas/c0"
                        }
                    }
                }
            };

            string json = JsonConvert.SerializeObject(manifest, Formatting.Indented, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });

            Console.WriteLine(json);
        }
    }
}
