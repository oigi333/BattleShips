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
            title = new Text(LanguageManager.Current["title"], AssetManager.Fonts["Bungee"], 80);
            title.Position = new Vector2f((window.Size.X - title.GetGlobalBounds().Width) / 2, 80);

            background = new Sprite(AssetManager.Textures["PortBackground"])
            {
                Scale = new Vector2f((float)window.Size.X / AssetManager.Textures["PortBackground"].Size.X, (float)window.Size.Y / AssetManager.Textures["PortBackground"].Size.Y),
                Color = new Color(170, 170, 170)
            };

            settingsButton = new GUI.Button(
                "SettingsIcon",
                new Vector2f(30, window.Size.Y - 90),
                new Vector2f(
                    60f / AssetManager.Textures["SettingsIcon"].Size.X,
                    60f / AssetManager.Textures["SettingsIcon"].Size.Y
                )
            );
            settingsButton.Clicked += (sender, args) => { Console.WriteLine("[Settings]"); };


            playButton = new GUI.Button(
                "PlayIcon",
                new Vector2f(window.Size.X / 2 - 40, window.Size.Y / 2 - 40),
                new Vector2f(
                    80f / AssetManager.Textures["PlayIcon"].Size.X,
                    80f / AssetManager.Textures["PlayIcon"].Size.Y
                )
            );
            playButton.Clicked += (sender, args) => { Console.WriteLine("[Play the Game]"); };

            blurShader = new Shader(@"res/shaders/basic.vert", @"res/shaders/blur.frag");
            blurShader.SetParameter("blurRadius", 2/3);
            blurShader.SetParameter("texture", Shader.CurrentTexture);
        }
        
        public void Show(RenderWindow window) 
        {
            window.Clear(new Color(0, 0, 100));

            window.Draw(background, new RenderStates(blurShader));
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