using System;
using SFML.Window;
using SFML.Graphics;
using SFML.System;
using System.Collections.Generic;

namespace GameStates
{
    public class Menu : IGameState
    {
        Font font;
        Text title;
        Sprite settingsIcon;

        public Menu() {}

        public void Init(RenderWindow window) 
        {
            title = new Text(LanguageManager.Current["title"],AssetManager.Fonts["Bungee"], 80);
            title.Position = new Vector2f((window.Size.X - title.GetGlobalBounds().Width) / 2, 80);
            settingsIcon = new Sprite();
        }
        

        public void Show(RenderWindow window) 
        {
            window.Clear(new Color(0, 0, 100));
            window.Draw(title);
        }

        public void Update(RenderWindow window) 
        {
            Vector2i mousePosition = Mouse.GetPosition(window); 

            // (new List<(Text Text, Action SthToDo)>(){( _playText, () => {Console.WriteLine("[Start the game]");} ), ( _exitText, () => {window.Close();} ) }).ForEach(button =>{if((button.Text.GetGlobalBounds().Contains(mousePosition.X, mousePosition.Y)? ( button.Text.Color = Color.Cyan) == Color.Cyan: ( button.Text.Color = Color.White) == Color.Cyan)&&Mouse.IsButtonPressed(Mouse.Button.Left)) button.SthToDo(); });
        }
        
    }
}