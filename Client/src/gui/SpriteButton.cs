using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML.Graphics;
using SFML.System;
using SFML.Window;

namespace Gui
{
    class SpriteButton : Button, Drawable
    {
        /// <summary>
        /// AssetManager Texture ID
        /// </summary>
        public String Texture
        {
            get { return texture; }
            set
            {
                buttonSprite.Texture = AssetManager.Textures[value];
                texture = value;
            }
        }
        /// <summary>
        /// Nwm jak to opisać do końca
        /// </summary>
        public IntRect TextureRect
        {
            get { return textureRect; }
            set
            {
                buttonSprite.TextureRect = value;
                textureRect = value;
            }
        }
        ///<inheritDoc/>
        public override Color Color
        {
            get { return color; }
            set
            {
                buttonSprite.Color = value;
                color = value;
            }
        }
        /// <inheritDoc/>
        public override Vector2f Size
        {
            get
            {
                return size;
            }
            set
            {
                size = value;
                Scale = new Vector2f(value.X / buttonSprite.TextureRect.Width, value.Y / buttonSprite.TextureRect.Height);
            }
        }

        private Sprite buttonSprite;
        private String texture;
        private IntRect textureRect;

        /// <summary>
        /// Constructs a button using a sprite with the given texture.
        /// </summary>
        /// <param name="texture">The texture ID used by the AssetManager</param>
        public SpriteButton(String texture)
        {
            buttonSprite = new Sprite(AssetManager.Textures[texture]);
            TextureRect = new IntRect(new Vector2i(0, 0), new Vector2i((int)buttonSprite.Texture.Size.X, (int)buttonSprite.Texture.Size.Y));
            Texture = texture;
        }
        /// <summary>
        /// Constructs a button using a sprite with the given texture
        /// and transformation parameters.
        /// </summary>
        /// <param name="texture">The texture ID used by the AssetManager</param>
        /// <param name="position">The position of the button</param>
        /// <param name="size">The size of the button</param>
        public SpriteButton(String texture, Vector2f position, Vector2f size, IntRect? textureRect = null)
        {
            buttonSprite = new Sprite(AssetManager.Textures[texture]);
            Texture = texture;

            if (textureRect == null) TextureRect = new IntRect(new Vector2i(0, 0), new Vector2i((int)buttonSprite.Texture.Size.X, (int)buttonSprite.Texture.Size.Y));
            else TextureRect = (IntRect)textureRect;

            Position = position;
            Size = size;
        }

        /// <summary>
        /// Don't call it on your own.
        /// </summary>
        /// <param name="target"></param>
        /// <param name="states"></param>
        public override void Draw(RenderTarget target, RenderStates states)
        {
            states.Transform *= Transform;
            target.Draw(buttonSprite, states);
        }

        /// <summary>
        /// The axis-aligned bounding box containing this button.
        /// </summary>
        /// <returns>The bounding box as a rectangle</returns>
        public override FloatRect GetGlobalBounds()
        {
            return new FloatRect(Position, Size);
        }

    }
}
