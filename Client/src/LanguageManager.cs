using System;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;

/// <summary>
/// This class allows us to add some multilinguistic features.
/// </summary>
public class LanguageManager
{
    public static Dictionary<String,Language> Languages;

    /// <summary>
    /// Initialization function. It loads language file
    /// </summary>
    /// <param name="fileName">Filename of language file.</param>
    public static void Init(String fileName)
    {
        String json = File.ReadAllText(fileName);
        Languages = JsonConvert.DeserializeObject<Dictionary<String,Language>>(json);
    }
    /// <summary>
    /// Current language
    /// </summary>
    public static Language Current
    {
        get;
        private set;
    }
    /// <summary>
    /// In this function you set current language.
    /// </summary>
    /// <param name="lang">Language ID.</param>
    public static void SetCurrent(String lang)
    {
        Current = Languages[lang];

        Console.WriteLine("Language: {0} enabled:", Current.Name);
        foreach (var pair in Current.Strings)
        {
            Console.WriteLine("  {0}: {1}", pair.Key, pair.Value);
        }
    }

    public class Language
    {
        [JsonProperty(PropertyName="name")]
        public String Name;
        [JsonProperty(PropertyName="lang")]
        public Dictionary<String,String> Strings;

        public String this[String key]
        {
            get { return Strings[key]; }
        }
    }
}