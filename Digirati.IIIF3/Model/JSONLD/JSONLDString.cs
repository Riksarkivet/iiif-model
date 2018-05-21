using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;

using LanguageMap = System.Collections.Generic.Dictionary<string, System.Collections.Generic.List<string>>;

namespace Digirati.IIIF3.Model.JSONLD
{
    public class JSONLDString
    {
        private readonly string singleValue;
        private LanguageMap languageMap;

        [JsonExtensionData]
        public Dictionary<string, object> Output
        {
            get
            {
                LanguageMap totalMap = new LanguageMap();
                if (languageMap != null)
                    totalMap = new LanguageMap(languageMap);
                if (singleValue != null)
                    totalMap.Add("@none", new List<string> { singleValue });
                return totalMap.ToDictionary(item => item.Key, item => item.Value as object);
            }
        }

        public JSONLDString(string value)
        {
            singleValue = value;
        }

        public JSONLDString(string language, string value)
        {
            languageMap = new LanguageMap
            {
                { language, new List<string>() { value } }
            };
        }


        public JSONLDString(LanguageMap languageMap)
        {
            this.languageMap = languageMap;
        }

        public static implicit operator string(JSONLDString js)
        {
            return js.ToString();
        }

        public static implicit operator JSONLDString(string s)
        {
            return new JSONLDString(s);
        }

        public List<string> this[string language]
        {
            get
            {
                if (languageMap != null && languageMap.ContainsKey(language))
                {
                    return languageMap[language];
                }
                if (language == "@none")
                {
                    return new List<string>() { singleValue };
                }
                return null;
            }
            set
            {
                if (languageMap == null)
                {
                    languageMap = new LanguageMap();
                }
                languageMap[language] = value;
            }
        }

        public override string ToString()
        {
            if (languageMap == null)
            {
                return singleValue;
            }
            return string.Join(";", Output.Select(x => x.Key + "=" + string.Join("|", x.Value as List<string>)));
        }

        public override bool Equals(object obj)
        {
            if (obj is string || obj is JSONLDString)
            {
                return ToString().Equals(obj.ToString());
            }
            return false;
        }
    }
}


