using System;
using SFML.Window;
using SFML.Graphics;
using SFML.System;
using System.Windows.Forms;
using System.Collections.Generic;

namespace GameStates
{
    public class Menu : IGameState
    {
        Font _font;
        Text _title;
        Text _playText;
        Text _exitText;

        public Menu() {}

        public void Init(RenderWindow window) 
        {
            _font = new Font(@"res/fonts/Bungee-Regular.ttf");
            _title = new Text(LanguageManager.Current["title"], _font, 80);
            _title.Position = new Vector2f((window.Size.X - _title.GetGlobalBounds().Width) / 2, 80); 
            _playText = new Text(LanguageManager.Current["play"], _font, 50);
            _playText.Position = new Vector2f(
                (window.Size.X - _playText.GetGlobalBounds().Width) / 2, 
                _title.Position.Y + _title.GetGlobalBounds().Height + 60); 
            _exitText = new Text(LanguageManager.Current["quit"], _font, 50);
            _exitText.Position = new Vector2f(
                (window.Size.X - _exitText.GetGlobalBounds().Width) / 2, 
                _playText.Position.Y + _playText.GetGlobalBounds().Height + 30); 
        }

        public void Show(RenderWindow window) 
        {
            window.Clear(new Color(0, 0, 100));
            window.Draw(_title);
            window.Draw(_playText);
            window.Draw(_exitText);
        }

        public void Update(RenderWindow window) 
        {
            Vector2i mousePosition = Mouse.GetPosition(window); 
            (Text Text, Action SthToDo)[] buttons = {
                (_playText, () => { GameStateManager.Current = "BeforeGame"; }),
                (_exitText, () => { window.Close(); })
            };
            
            foreach (var button in buttons)
            {
                if(button.Text.GetGlobalBounds().Contains(mousePosition.X, mousePosition.Y))
                {
                    button.Text.Color = Color.Cyan;
                    if (Mouse.IsButtonPressed(Mouse.Button.Left))
                        button.SthToDo();
                }
                else button.Text.Color = Color.White;
            } 

            // Funny One-liner:
            // (new List<(Text Text, Action SthToDo)>(){( _playText, () => {Console.WriteLine("[Start the game]");} ), ( _exitText, () => {window.Close();} ) }).ForEach(button =>{if((button.Text.GetGlobalBounds().Contains(mousePosition.X, mousePosition.Y)? ( button.Text.Color = Color.Cyan) == Color.Cyan: ( button.Text.Color = Color.White) == Color.Cyan)&&Mouse.IsButtonPressed(Mouse.Button.Left)) button.SthToDo(); });
        }
        
    }
}