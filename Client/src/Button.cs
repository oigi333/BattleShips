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
    //polecam zamykać summary(taki minusik po lewej)

    /// <summary>
    /// Button, currently only with Sprite though.
    /// </summary>
    class Button : Transformable, Drawable
    {
        /// <summary>
        /// Occur when button is clicked. It occur one time in a row.
        /// </summary>
        public event EventHandler Clicked;
        /// <summary>
        /// Occur when button is pressed. By that, I mean mouse is over button and is pressed. It occur continous.
        /// </summary>
        public event EventHandler Pressed;
        /// <summary>
        /// Occur when mouse is over button. 
        /// </summary>
        public event EventHandler Hover;
        /// <summary>
        /// Occur when mouse is over button, but in the previous frame it was somewhere else. 
        /// </summary>
        public event EventHandler MouseEntered;
        /// <summary>
        /// Occur when mouse in previous frame was over button, but now it's somewhere else. 
        /// </summary>
        public event EventHandler MouseLeave;


        public Color Color {
            get
            {
                return color;
            }
            set
            {
                buttonSprite.Color = value;
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
                buttonSprite.TextureRect = value;
                textureRect = value;
            }
        }

        private Sprite buttonSprite;
        private String texture;
        private IntRect textureRect;
        private Color color = Color.White;
        private bool lastHover = false;
        private bool lastPressed = false;


        /// <summary>
        /// Basic constructor.
        /// </summary>
        /// <param name="texture">Yer AssetManager texture ID.</param>
        public Button(String texture)
        {
            buttonSprite = new Sprite(AssetManager.Textures[texture]);
            Texture = texture;
        }
        /// <summary>
        /// Basic Constructor with some more options.
        /// </summary>
        /// <param name="texture">Yer AssetManager texture ID.</param>
        /// <param name="position">Wherever you want it to be</param>
        /// <param name="scale">TODO Change Scale to size</param>
        public Button(String texture, Vector2f position, Vector2f scale)
        {
            buttonSprite = new Sprite(AssetManager.Textures[texture]);
            Texture = texture;
            Position = position;
            Scale = scale;
        }

        /// <summary>
        /// It's heart of button, so call it every time you're updating if you want it to works.
        /// </summary>
        /// <param name="window">Yer window.</param>
        public void Update(RenderWindow window)
        {
            Vector2i mousePosition = Mouse.GetPosition(window);

            if (GetGlobalBounds().Contains(mousePosition.X, mousePosition.Y))
            {
                if (!lastHover)
                    MouseEntered?.Invoke(this, new EventArgs());
                Hover?.Invoke(this, new EventArgs());
                lastHover = true;

                if (Mouse.IsButtonPressed(Mouse.Button.Left))
                {
                    if (!lastPressed)
                        Clicked?.Invoke(this, new EventArgs());
                    Pressed?.Invoke(this, new EventArgs());
                    lastPressed = true;
                }
                else
                    lastPressed = false;
            }
            else if (lastHover)
            {
                MouseLeave?.Invoke(this, new EventArgs());
                lastHover = false;
            }
         
        }

        public void Draw(RenderTarget target, RenderStates states)
        {
            states.Transform *= Transform;
            target.Draw(buttonSprite, states);
        }

        /// <summary>
        /// You can think of it as a rectangle covering all your button.
        /// </summary>
        /// <returns></returns>
        public FloatRect GetGlobalBounds()
        {
            return new FloatRect(Position,new Vector2f(Scale.X*buttonSprite.Texture.Size.X, Scale.Y * buttonSprite.Texture.Size.Y));
        }
    }
}
