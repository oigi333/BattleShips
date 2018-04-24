using System;
using System.Collections.Generic;
using System.IO;
using SFML.Window;
using SFML.Graphics;
using SFML.System;

public class AssetManager
{
    public static Dictionary<String,Font> Fonts = new Dictionary<String,Font>();
    public static Dictionary<String,Texture> Textures = new Dictionary<String,Texture>();
    
    public static void Add<T>(String key, String fileName) 
    {
        if(typeof(T) == typeof(Font))
            Fonts.Add(key,new Font(fileName));
        if(typeof(T) == typeof(Texture))
            Textures.Add(key,new Texture(fileName));
    }

}