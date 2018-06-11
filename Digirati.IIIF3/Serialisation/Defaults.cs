using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Digirati.IIIF3.Serialisation
{
    public static class Defaults
    {
        public static List<string> Context => new List<string>
        {
            UriPatterns.JsonLdContext,
            UriPatterns.Presentation3Context
        };

        public static JsonSerializerSettings JsonSerializerSettings => new JsonSerializerSettings
        {
            ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
            Formatting = Formatting.Indented,
            NullValueHandling = NullValueHandling.Ignore,
            ContractResolver = new CamelCasePropertyNamesContractResolver()
        };

    }
}
