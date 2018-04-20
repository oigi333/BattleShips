using System;
using SFML.Window;
using SFML.Graphics;
using SFML.System;
using System.Windows.Forms;

namespace GameStates
{
    public class Menu : IGameState
    {
        public Menu() {}

        public void Init(RenderWindow window) 
        {
            _font = new Font(@"res/fonts/Bungee-Regular.ttf"); // Tworze se _font co znalazłem gdzieś na dysku; "@" pomija \n itp
            _title = new Text("BattleSheeps",_font,80); // W zasadzie mogłem sobie ustawić właściwości nie przez konstruktor, ale jak pozwalają tak to czm nie
            _title.Position = new Vector2f((window.Size.X - _title.GetGlobalBounds().Width) / 2, 80); // Mówi raczej samo za siebie ustawiam tekst na środku poziomo 10px od góry
            _playText = new Text("Graj", _font, 50);
            _playText.Position = new Vector2f(
                (window.Size.X - _playText.GetGlobalBounds().Width) / 2, // jak wyżej 
                _title.Position.Y + _title.GetGlobalBounds().Height+60); // relatywnie do poprzedniego o 50 px w dół
            _exitText = new Text("Wyjscie", _font, 50);
            _exitText.Position = new Vector2f(
                (window.Size.X - _exitText.GetGlobalBounds().Width) / 2, // jak wyżej 
                _playText.Position.Y + _playText.GetGlobalBounds().Height + 30); // relatywnie do poprzedniego o 50 px w dół
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
            Vector2i mousePosition = Mouse.GetPosition(window); //Pozycja myszki relatywnie do okna
            if (_playText.GetGlobalBounds().Contains(mousePosition.X, mousePosition.Y)) // jeżeli prostokąt tworzony przez playText zawiera w sobie pozycję myszki to:
            {
                _playText.Color = Color.Cyan; // jestem leniwy
                if (Mouse.IsButtonPressed(Mouse.Button.Left)) // jeżeli kliknięto
                    ; // jak już będzie co robić dalej to tu
            }
            else
                _playText.Color = Color.White; // Znów biały

            if (_exitText.GetGlobalBounds().Contains(mousePosition.X, mousePosition.Y)) // jak wcześniej troche
            {
                _exitText.Color = Color.Cyan; // same
                if (Mouse.IsButtonPressed(Mouse.Button.Left))
                    window.Close(); // zamykamy okno
            }
            else
                _exitText.Color = Color.White;
        }

        Font _font;
        Text _title;
        Text _playText;
        Text _exitText; 
    
    }
}