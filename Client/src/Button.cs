using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML.Graphics;
using SFML.System;
using SFML.Window;

namespace GUI
{
    class Button : Sprite
    {
        public Action OnDown { private get; set; } = () => { };
        public Action OnUp { private get; set; } = () => { };
        public Action OnClick { private get; set; } = () => { };
        private bool lastPressed = false;
        private bool lastDown = false;

        public Button(Texture texture) : base(texture) { }

        public Button(Texture texture, float x, float y, float w, float h) : base(texture)
        {
            Position = new Vector2f(x, y);
            Scale = new Vector2f(w, h);
        }

        public void Update(RenderWindow window)
        {
            Vector2i mousePosition = Mouse.GetPosition(window);
            bool pressed = Mouse.IsButtonPressed(Mouse.Button.Left);
            if (!lastPressed && pressed)
            {
                if (GetGlobalBounds().Contains(mousePosition.X, mousePosition.Y))
                {
                    lastDown = true;
                    OnDown();
                }
                lastPressed = true;
            }
            else if (lastPressed && !pressed)
            {
                lastPressed = false;
                if (GetGlobalBounds().Contains(mousePosition.X, mousePosition.Y))
                {
                    OnUp();
                    if(lastDown) OnClick();
                }
                lastDown = false;
            }
        }
    }
}
