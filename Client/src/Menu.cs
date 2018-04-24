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
        Sprite settingsButton;
        Sprite playButton;
        Sprite portBackground;
        Shader blurShader;

        public Menu() {}

        public void Init(RenderWindow window) 
        {
            title = new Text(LanguageManager.Current["title"],AssetManager.Fonts["Bungee"], 80);
            title.Position = new Vector2f((window.Size.X - title.GetGlobalBounds().Width) / 2, 80);

            portBackground = new Sprite(AssetManager.Textures["PortBackground"])
            {
                Scale = new Vector2f((float)window.Size.X / AssetManager.Textures["PortBackground"].Size.X, (float)window.Size.Y / AssetManager.Textures["PortBackground"].Size.Y)
            };

            settingsButton = new Sprite(AssetManager.Textures["SettingsIcon"])
            {
                Scale = new Vector2f(60f / AssetManager.Textures["SettingsIcon"].Size.X, 60f / AssetManager.Textures["SettingsIcon"].Size.Y),
                Position = new Vector2f(30, window.Size.Y - 60 - 30)
            };

            playButton = new Sprite(AssetManager.Textures["PlayIcon"])
            {
                Scale = new Vector2f(80f / AssetManager.Textures["PlayIcon"].Size.X, 80f / AssetManager.Textures["PlayIcon"].Size.Y),
                Position = new Vector2f((window.Size.X - 80) / 2, (window.Size.Y - 80) / 2)
            };



            blurShader = new Shader(@"res/shaders/basic.vert", @"res/shaders/blur.frag");
            blurShader.SetParameter("blurRadius", 1000);
            blurShader.SetParameter("texture", Shader.CurrentTexture);
        }
        
        public void Show(RenderWindow window) 
        {
            window.Clear(new Color(0, 0, 100));

            window.Draw(portBackground/*, new RenderStates(blur)*/);
            window.Draw(title);
            window.Draw(settingsButton);
            window.Draw(playButton);
          
        }

        public void Update(RenderWindow window) 
        {
            Vector2i mousePosition = Mouse.GetPosition(window);
            // (new List<(Text Text, Action SthToDo)>(){( _playText, () => {Console.WriteLine("[Start the game]");} ), ( _exitText, () => {window.Close();} ) }).ForEach(button =>{if((button.Text.GetGlobalBounds().Contains(mousePosition.X, mousePosition.Y)? ( button.Text.Color = Color.Cyan) == Color.Cyan: ( button.Text.Color = Color.White) == Color.Cyan)&&Mouse.IsButtonPressed(Mouse.Button.Left)) button.SthToDo(); });
        }
        
    }
}