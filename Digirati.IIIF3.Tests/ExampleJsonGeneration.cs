using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Digirati.IIIF3.Model;
using Digirati.IIIF3.Model.JSONLD;
using Digirati.IIIF3.Model.Types;
using Digirati.IIIF3.Serialisation;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using NUnit.Framework;

namespace Digirati.IIIF3.Tests
{
    [TestFixture]
    public class ExampleJsonGeneration
    {
        [Test]
        public void TestIiif3SpecExample()
        {
            Manifest manifest = new Manifest();
            manifest.Label = new JSONLDString("en", "Book 1");
            manifest.Context = Defaults.Context;
            manifest.Id = "https://example.org/iiif/book1/manifest";
            manifest.Metadata = new List<Metadata>
            {
                new Metadata
                {
                    Label = new JSONLDString("en", "Author"),
                    Value = new JSONLDString("Anne Author")
                },
                new Metadata
                {
                    Label = new JSONLDString("en", "Published"),
                    Value = new JSONLDString(new Dictionary<string, List<string>>
                    {
                        { "en",  new List<string> { "Paris, circa 1400" } },
                        { "fr",  new List<string> { "Paris, environ 1400" } },
                    })
                },
                new Metadata
                {
                    Label = new JSONLDString("en", "Notes"),
                    Value = new JSONLDString(new Dictionary<string, List<string>>
                    {
                        { "en", new List<string> { "Text of note 1", "Text of note 2" } }
                    }),
                },
                new Metadata
                {
                    Label = new JSONLDString("en", "Source"),
                    Value = new JSONLDString("<span>From: <a href=\"https://example.org/db/1.html\">Some Collection</a></span>")
                },

            };

            manifest.Summary = new JSONLDString("en", "Book 1, written be Anne Author, published in Paris around 1400.");
            manifest.Thumbnail = new List<ImageResource>
            {
                new ImageResource("https://example.org/images/book1-page1/full/80,100/0/default.jpg")
                {
                    Service = new List<Service>
                    {
                        new Service
                        {
                            Id = "https://example.org/images/book1-page1",
                            Type = "ImageService3",
                            Profile = "level1"
                        }
                    }
                }
            };

            manifest.ViewingDirection = "right-to-left";
            manifest.Behavior = new List<string>() { "paged" };
            manifest.NavDate = "1856-01-01T00:00:00Z";
            manifest.Rights = "https://creativecommons.org/licenses/by/4.0/";
            manifest.RequiredStatement = new Metadata
            {
                Label = new JSONLDString("en", "Attribution"),
                Value = new JSONLDString("en", "Provided by Example Organization")
            };

            manifest.Logo = new List<ImageResource>
            {
                new ImageResource("https://example.org/logos/institution1.jpg")
                {
                    Service = new List<Service>
                    {
                        new Service
                        {
                            Id = "https://example.org/service/inst1",
                            Type = "ImageService3",
                            Profile = "level2"
                        }
                    }
                }
            };

            manifest.Homepage = new Resource
            {
                Id = "https://example.org/info/book1/",
                Type = "Text",
                Label = new JSONLDString("en", "Home page for Book 1"),
                Format = "text/html"
            };

            manifest.Service = new List<Service> {
                new Service
                {
                    Id = "https://example.org/service/example",
                    Type = "Service",
                    Profile = "https://example.org/docs/example-service.html"
                }
            };

            manifest.SeeAlso = new List<Resource> {
                new Resource
                {
                    Id = "https://example.org/library/catalog/book1.xml",
                    Type = "Dataset",
                    Format = "text/xml",
                    Profile = "https://example.org/profiles/bibliographic"
                }
            };

            manifest.Rendering = new List<Resource> {
                new Resource
                {
                    Id = "https://example.org/iiif/book1.pdf",
                    Type = "Text",
                    Label = new JSONLDString("en", "Download as PDF"),
                    Format = "application/pdf",
                }
            };

            manifest.PartOf = new List<Resource> {
                new Resource
                {
                    Id = "https://example.org/collections/books/",
                    Type = "Collection"
                }
            };

            manifest.Start = new Resource
            {
                Id = "https://example.org/iiif/book1/canvas/p2",
                Type = "Canvas"
            };

            manifest.Items = new List<Canvas>
            {
                new Canvas
                {
                    Id = "https://example.org/iiif/book1/canvas/p1",
                    Label = "p. 1",
                    Height = 1000,
                    Width = 750,
                    Items = new List<AnnotationPage>
                    {
                        new AnnotationPage
                        {
                            Id = "https://example.org/iiif/book1/page/p1/1",
                            Items = new List<Annotation>
                            {
                                new Annotation
                                {
                                    Id = "https://example.org/iiif/book1/annotation/p0001-image",
                                    Motivation = "painting",
                                    Body = new ImageResource("https://example.org/iiif/book1/res/page1.jpg")
                                    {
                                        Format = "image/jpeg",
                                        Service = new List<Service>
                                        {
                                            new Service
                                            {
                                                Id = "https://example.org/images/book1-page1",
                                                Type = "ImageService3",
                                                Profile = "level2"
                                            }
                                        },
                                        Width = 1500,
                                        Height = 2000
                                    },
                                    Target = "https://example.org/iiif/book1/canvas/p1"
                                }
                            }
                        }
                    }
                },
                new Canvas
                {
                    Id = "https://example.org/iiif/book1/canvas/p2",
                    Label = "p. 2",
                    Height = 1000,
                    Width = 750,
                    Items = new List<AnnotationPage>
                    {
                        new AnnotationPage
                        {
                            Id = "https://example.org/iiif/book1/page/p2/1",
                            Items = new List<Annotation>
                            {
                                new Annotation
                                {
                                    Id = "https://example.org/iiif/book1/annotation/p0002-image",
                                    Motivation = "painting",
                                    Body = new ImageResource("https://example.org/iiif/book1/res/page1.jpg")
                                    {
                                        Format = "image/jpeg",
                                        Service = new List<Service>
                                        {
                                            new Service
                                            {
                                                Id = "https://example.org/images/book1-page2",
                                                Type = "ImageService3",
                                                Profile = "level2"
                                            }
                                        },
                                        Width = 1500,
                                        Height = 2000
                                    },
                                    Target = "https://example.org/iiif/book1/canvas/p2"
                                }
                            }
                        }
                    }
                }
            };

            manifest.Annotations = new List<AnnotationPage>
            {
                new AnnotationPage
                {
                    Id = "https://example.org/iiif/book1/page/manifest/1",
                    Items = new List<Annotation>
                    {
                        new Annotation
                        {
                            Id = "https://example.org/iiif/book1/page/manifest/a1",
                            Motivation = "commenting",
                            Body = new Resource
                            {
                                Type = "TextualBody",
                                // This part looks really strange in the IIIF3 example with a language and value property
                                // I think Label probably replaces this construct? /MW
                                Label = new JSONLDString("en", "I love this manifest!")
                            },
                            Target = "https://example.org/iiif/book1/manifest"
                        }
                    }
                }
            };

            using (var sw = new StringWriter())
            {
                JsonSerializer.Create(Defaults.JsonSerializerSettings).Serialize(sw, manifest);
                Console.Write(sw.ToString());
            }

        }


        [Test]
        public void TestIiif3RangeExample()
        {
            Manifest manifest = new Manifest();
            manifest.Label = new JSONLDString("en", "Book 1");
            manifest.Context = Defaults.Context;
            manifest.Id = "https://example.org/iiif/book1/manifest";
            manifest.ViewingDirection = "right-to-left";
            manifest.Behavior = new List<string>() { "paged" };
            manifest.NavDate = "1856-01-01T00:00:00Z";
            manifest.Rights = "https://creativecommons.org/licenses/by/4.0/";
            manifest.RequiredStatement = new Metadata
            {
                Label = new JSONLDString("en", "Attribution"),
                Value = new JSONLDString("en", "Provided by Example Organization")
            };

            manifest.Items = new List<Canvas>
            {
                new Canvas
                {
                    Id = "https://example.org/iiif/book1/canvas/p1",
                    Label = "p. 1",
                    Height = 1000,
                    Width = 750,
                    Items = new List<AnnotationPage>
                    {
                        new AnnotationPage
                        {
                            Id = "https://example.org/iiif/book1/page/p1/1",
                            Items = new List<Annotation>
                            {
                                new Annotation
                                {
                                    Id = "https://example.org/iiif/book1/annotation/p0001-image",
                                    Motivation = "painting",
                                    Body = new ImageResource("https://example.org/iiif/book1/res/page1.jpg")
                                    {
                                        Format = "image/jpeg",
                                        Service = new List<Service>
                                        {
                                            new Service
                                            {
                                                Id = "https://example.org/images/book1-page1",
                                                Type = "ImageService3",
                                                Profile = "level2"
                                            }
                                        },
                                        Width = 1500,
                                        Height = 2000
                                    },
                                    Target = "https://example.org/iiif/book1/canvas/p1"
                                }
                            }
                        }
                    }
                },
                new Canvas
                {
                    Id = "https://example.org/iiif/book1/canvas/p2",
                    Label = "p. 2",
                    Height = 1000,
                    Width = 750,
                    Items = new List<AnnotationPage>
                    {
                        new AnnotationPage
                        {
                            Id = "https://example.org/iiif/book1/page/p2/1",
                            Items = new List<Annotation>
                            {
                                new Annotation
                                {
                                    Id = "https://example.org/iiif/book1/annotation/p0002-image",
                                    Motivation = "painting",
                                    Body = new ImageResource("https://example.org/iiif/book1/res/page1.jpg")
                                    {
                                        Format = "image/jpeg",
                                        Service = new List<Service>
                                        {
                                            new Service
                                            {
                                                Id = "https://example.org/images/book1-page2",
                                                Type = "ImageService3",
                                                Profile = "level2"
                                            }
                                        },
                                        Width = 1500,
                                        Height = 2000
                                    },
                                    Target = "https://example.org/iiif/book1/canvas/p2"
                                }
                            }
                        }
                    }
                }
            };

            var rangeLabelEnglishSwedish = new JSONLDString(new Dictionary<string, List<string>>
            {
                { "en", new List<string> { "Table of Content" } },
                { "sv", new List<string> { "Innehållsförteckning"} }
            });
            manifest.Structures = new List<Range>
            {
                new Range
                {
                    Id = "https://example.org/iiif/book1/range/r0",
                    Type = "Range",
                    Label = rangeLabelEnglishSwedish,
                    Items = new List<Range>
                    {
                        new Range {
                            Id ="https://example.org/iiif/book1/range/r1",
                            Type = "Range",
                            Label = new JSONLDString("bild1"),
                            Items = new List<Range>
                            {
                                new Range
                                {
                                    Id = "https://example.org/iiif/book1/canvas/p1",
                                    Type = "Canvas",
                                }
                            }
                        },
                        new Range
                        {
                            Id ="https://example.org/iiif/book1/range/r2",
                            Type = "Range",
                            Label = new JSONLDString("bild2"),
                            Items = new List<Range>
                            {
                                new Range
                                {
                                    Id = "https://example.org/iiif/book1/canvas/p2",
                                    Type = "Canvas",
                                }
                            }
                        }
                    }
                }
            };

            using (var sw = new StringWriter())
            {
                JsonSerializer.Create(Defaults.JsonSerializerSettings).Serialize(sw, manifest);
                Console.Write(sw.ToString());
            }

        }


    }
}
