using System;
using SFML.Window;
using SFML.Graphics;
using SFML.System;
using System.Collections.Generic;

namespace GameStates
{
    public class Menu : IGameState
    {
        Text title;
        GUI.Button settingsButton;
        GUI.Button playButton;
        Sprite background;
        Shader blurShader;

        public Menu() {}

        public void Init(RenderWindow window) 
        {
            title = new Text(LanguageManager.Current["title"],AssetManager.Fonts["Bungee"], 80);
            title.Position = new Vector2f((window.Size.X - title.GetGlobalBounds().Width) / 2, 80);

            background = new Sprite(AssetManager.Textures["PortBackground"])
            {
                Scale = new Vector2f((float)window.Size.X / AssetManager.Textures["PortBackground"].Size.X, (float)window.Size.Y / AssetManager.Textures["PortBackground"].Size.Y)
            };

            settingsButton = new GUI.Button(
                AssetManager.Textures["SettingsIcon"],
                30,
                window.Size.Y - 90,
                60f / AssetManager.Textures["SettingsIcon"].Size.X,
                60f / AssetManager.Textures["SettingsIcon"].Size.Y
            ) {
                OnClick = () => Console.WriteLine("[Open settings]")
            };

            playButton = new GUI.Button(
                AssetManager.Textures["PlayIcon"],
                (window.Size.X - 80) / 2,
                (window.Size.Y - 80) / 2,
                80f / AssetManager.Textures["PlayIcon"].Size.X,
                80f / AssetManager.Textures["PlayIcon"].Size.Y
            ) {
                OnClick = () => Console.WriteLine("[Start the game]")
            };

            blurShader = new Shader(@"res/shaders/basic.vert", @"res/shaders/blur.frag");
            blurShader.SetParameter("blurRadius", 1000);
            blurShader.SetParameter("texture", Shader.CurrentTexture);
        }
        
        public void Show(RenderWindow window) 
        {
            window.Clear(new Color(0, 0, 100));

            window.Draw(background/*, new RenderStates(blur)*/);
            window.Draw(title);
            window.Draw(settingsButton);
            window.Draw(playButton);
          
        }

        public void Update(RenderWindow window) 
        {
            playButton.Update(window);
            settingsButton.Update(window);
        }
        
    }
}