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
        public event EventHandler Down;  //Znaczy tu się eventy proszą o użycie, błagają, mówią: "Po to tu jesteśmy!"
        public event EventHandler Up; //Eventy dają też dodatkowe możliwości
        public event EventHandler Clicked; // Z których nie wiem czy skorzystamy

        public Color Color {
            get
            {
                return color;
            }
            set
            {
                buttonSprite.Color = color;
                color = value;
            }
        }
        public String Texture {
            get
            {
                return texture;
            }
            set
            {
                buttonSprite.Texture = AssetManager.Textures[value];
                texture = value;
            }
        }
        public IntRect TextureRect
        {
            get
            {
                return textureRect;
            }
            set
            {
                buttonSprite.TextureRect = textureRect;
                textureRect = value;
            }
        }

        private bool lastPressed = false;
        private bool lastDown = false;
        private Sprite buttonSprite;
        private String texture;
        private IntRect textureRect;
        private Color color = Color.White;

        public Button(String texture)
        {
            buttonSprite = new Sprite(AssetManager.Textures[texture]);
            Texture = texture;
        }

        public Button(String texture, Vector2f position, Vector2f scale)
        {
            buttonSprite = new Sprite(AssetManager.Textures[texture]);
            Texture = texture;
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
                    Down?.Invoke(window, new EventArgs()); // cośtam? to skrót od cośtam==null?null:cośtam
                }
                lastPressed = true;
            }
            else if (lastPressed && !pressed)
            {
                lastPressed = false;
                if (GetGlobalBounds().Contains(mousePosition.X, mousePosition.Y))
                {
                    Up?.Invoke(window, new EventArgs());
                    if (lastDown) Clicked?.Invoke(window, new EventArgs());
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
