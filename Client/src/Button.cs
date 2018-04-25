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
    /// <summary>
    /// A drawable, clickable button.
	/// Currently only supports sprites.
    /// </summary>
    class Button : Transformable, Drawable
    {
        /// <summary>
        /// Occures when the button is clicked, once.
        /// </summary>
        public event EventHandler Clicked;
        /// <summary>
        /// Called continuously (each update) when the button is pressed.
        /// </summary>
        public event EventHandler Pressed;
        /// <summary>
        /// Called continuously (each update) when the mouse cursor hovers over the button.
        /// </summary>
        public event EventHandler Hover;
        /// <summary>
        /// Occures once when the mouse cursor enters the bounds of the button.
        /// </summary>
        public event EventHandler MouseEntered;
        /// <summary>
        /// Occures once when the mouse cursor leaves the bounds of the button.
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
        /// Constructs a button using a sprite with the given texture.
        /// </summary>
        /// <param name="texture">The texture ID used by the AssetManager</param>
        public Button(String texture)
        {
            buttonSprite = new Sprite(AssetManager.Textures[texture]);
            Texture = texture;
        }
		/// <summary>
		/// Constructs a button using a sprite with the given texture
		/// and transformation parameters.
		/// </summary>
		/// <param name="texture">The texture ID used by the AssetManager</param>
		/// <param name="position">The position of the button</param>
		/// <param name="size">The size of the button</param>
		public Button(String texture, Vector2f position, Vector2f size)
        {
            buttonSprite = new Sprite(AssetManager.Textures[texture]);
            Texture = texture;
            Position = position;
            Scale = new Vector2f(size.X / buttonSprite.Texture.Size.X, size.Y / buttonSprite.Texture.Size.Y);
        }

        /// <summary>
        /// Updates the button calling all the appropriate events.
        /// </summary>
        /// <param name="window">The render window the button is located in</param>
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
        /// The axis-aligned bounding box containing this button.
        /// </summary>
        /// <returns>The bounding box as a rectangle</returns>
        public FloatRect GetGlobalBounds()
        {
            return new FloatRect(Position,new Vector2f(Scale.X*buttonSprite.Texture.Size.X, Scale.Y * buttonSprite.Texture.Size.Y));
        }
    }
}
