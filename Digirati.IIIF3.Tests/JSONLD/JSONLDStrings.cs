using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Digirati.IIIF3.Model.JSONLD;
using NUnit.Framework;

using LanguageMap = System.Collections.Generic.Dictionary<string, System.Collections.Generic.List<string>>;

namespace Digirati.IIIF3.Tests.JSONLD
{
    [TestFixture]
    public class JSONLDStrings
    {
        [Test]
        public void TestSingleString()
        {
            JSONLDString jss = "no language string";
            Assert.IsTrue("no language string" == jss);
            Assert.AreEqual("no language string", (jss.Output["@none"] as List<string>).First());
        }

        [Test]
        public void TestIndexingProperty()
        {
            JSONLDString jss = "no language string";
            jss["fr"] = new List<string> { "sans langue" };
            Assert.AreEqual("fr=sans langue;@none=no language string", jss.ToString());
            Assert.AreEqual("sans langue", jss["fr"].First());
            Assert.AreEqual("no language string", jss["@none"].First());
        }

        [Test]
        public void TestLanguageMapOutput()
        {
            JSONLDString jss = new JSONLDString(new LanguageMap
            {
                { "en", new List<string>() { "english-test" } },
                { "sv", new List<string>() { "svenska-test" } },
            });
            var englishList = jss.Output["en"] as List<string>;
            Assert.AreEqual(1, englishList.Count);
            Assert.AreEqual("english-test", englishList.First());

            var swedishList = jss.Output["sv"] as List<string>;
            Assert.AreEqual(1, swedishList.Count);
            Assert.AreEqual("svenska-test", swedishList.First());
        }

    }
}
