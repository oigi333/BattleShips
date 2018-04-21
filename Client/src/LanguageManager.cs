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

    public static Language Current
    {
        get;
        private set;
    }
    
    public static void SetCurrent(String lang)
    {
        Current = Languages[lang];

        Console.WriteLine("Language: {0} enabled.", Current.Name);
        foreach (var pair in Current.Strings)
        {
            Console.WriteLine("{0}: {1}", pair.Key, pair.Value);
        }
    }

    public class Language
    {
        [JsonProperty(PropertyName = "name")]
        public String Name;
        [JsonProperty(PropertyName = "lang")]
        public Dictionary<String,String> Strings;

        public String this[String key]
        {
            get{ return Strings[key];}
        }
    }
}