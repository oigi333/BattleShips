using System;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;

public class LanguageManager
{
    public static Dictionary<string, Language> Languages;

    public static void Init(String fileName)
    {
        String json = File.ReadAllText(fileName);
        Languages = JsonConvert.DeserializeObject<Dictionary<string, Language>>(json);
    }


    public class Language
    {
        public String Name;

        [JsonProperty(PropertyName = "lang")]
        public Dictionary<String,String> Strings;

        public String this[String key]
        {
            get{ return Strings[key];}
        }
    }
}