using System;
using SFML.Window;
using SFML.Graphics;
using SFML.System;
using System.Windows.Forms;

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
            _title = new Text("BattleShips", _font, 80);
            _title.Position = new Vector2f((window.Size.X - _title.GetGlobalBounds().Width) / 2, 80); 
            _playText = new Text("Graj", _font, 50);
            _playText.Position = new Vector2f(
                (window.Size.X - _playText.GetGlobalBounds().Width) / 2, 
                _title.Position.Y + _title.GetGlobalBounds().Height + 60); 
            _exitText = new Text("Wyjscie", _font, 50);
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
            if (_playText.GetGlobalBounds().Contains(mousePosition.X, mousePosition.Y)) 
            {
                _playText.Color = Color.Cyan; 
                if (Mouse.IsButtonPressed(Mouse.Button.Left))
                    Console.WriteLine("[Start the game]"); 
            }
            else
                _playText.Color = Color.White; 

            if (_exitText.GetGlobalBounds().Contains(mousePosition.X, mousePosition.Y)) 
            {
                _exitText.Color = Color.Cyan; 
                if (Mouse.IsButtonPressed(Mouse.Button.Left))
                    window.Close(); 
            }
            else
                _exitText.Color = Color.White;
        }
    }
}