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
    class Button : Transformable, Drawable
    {
        public Action OnDown { private get; set; } = () => { };
        public Action OnUp { private get; set; } = () => { };
        public Action OnClick { private get; set; } = () => { };
        private bool lastPressed = false;
        private bool lastDown = false;
        private Sprite buttonSprite;


        public Button(String texture)
        {
            buttonSprite = new Sprite(AssetManager.Textures[texture]); 
        }

        public Button(String texture, Vector2f position, Vector2f scale)
        {
            buttonSprite = new Sprite(AssetManager.Textures[texture]);
            Position = position;
            Scale = scale;
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

        public void Draw(RenderTarget target, RenderStates states)
        {
            states.Transform *= Transform;
            target.Draw(buttonSprite, states);
        }

        public FloatRect GetGlobalBounds()
        {
            return new FloatRect(Position,new Vector2f(Scale.X*buttonSprite.Texture.Size.X, Scale.Y * buttonSprite.Texture.Size.Y));
        }
    }
}
