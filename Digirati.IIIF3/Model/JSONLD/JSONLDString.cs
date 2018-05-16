using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;

using LanguageMap = System.Collections.Generic.Dictionary<string, object>;

namespace Digirati.IIIF3.Model.JSONLD
{
    public class JSONLDString
    {
        private string singleValue;

        private LanguageMap languageMap;

        [JsonExtensionData]
        public LanguageMap LanguageMap => languageMap;

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
            singleValue = value;
        }


        public JSONLDString(LanguageMap languageMap)
        {
            this.languageMap = languageMap;
        }

        public static implicit operator string(JSONLDString js)
        {
            // string s = myJsonLDStringObject;
            return js.ToString();
        }

        public static implicit operator JSONLDString(string s)
        {
            // JSONLDstring js = "hello";
            return new JSONLDString(s);
        }

        public List<string> this[string language]
        {
            get
            {
                if (languageMap != null && languageMap.ContainsKey(language))
                {
                    return languageMap[language] as List<string>;
                }
                if (language == string.Empty)
                {
                    return new List<string>() { singleValue };
                }
                return null;
            }
            set
            {
                if (languageMap == null)
                {
                    languageMap = new LanguageMap
                    {
                        { string.Empty, new List<string> { singleValue } }
                    };
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
            if (languageMap.ContainsKey(string.Empty))
            {
                return languageMap[string.Empty].ToString();
            }
            return string.Join(";", languageMap.Select(x => x.Key + "=" + x.Value));
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


