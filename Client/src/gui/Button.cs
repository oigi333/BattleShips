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
    /// <summary>
    /// A drawable, clickable button.
	/// Currently only supports sprites.
    /// </summary>
    
    abstract class Button : Transformable, Drawable
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
        
        /// <summary>
        /// Color of the button.
        /// </summary>
        public virtual Color Color {get; set;}
        /// <summary>
        /// Size of the button.
        /// </summary>
        public virtual Vector2f Size { get; set; }

        protected Vector2f size;
        protected Color color = Color.White;
        private bool lastHover = false;
        private bool lastMousePressed = false;

        

        /// <summary>
        /// Updates the button calling all the appropriate events.
        /// </summary>
        /// <param name="window">The render window the button is located in</param>
        public void Update(RenderWindow window)
        {
            Vector2i mousePosition = Mouse.GetPosition(window);

			bool hovered = false;
			if (GetGlobalBounds().Contains(mousePosition.X, mousePosition.Y))
			{
				if (!lastHover)
				{
					MouseEntered?.Invoke(this, new EventArgs());
				}
				Hover?.Invoke(this, new EventArgs());
				hovered = lastHover = true;
			}
			else if (lastHover)
			{
				MouseLeave?.Invoke(this, new EventArgs());
				lastHover = false;
			}

			if (Mouse.IsButtonPressed(Mouse.Button.Left))
			{
				if (hovered)
				{
					if (!lastMousePressed)
					{
						Clicked?.Invoke(this, new EventArgs());
					}
					Pressed?.Invoke(this, new EventArgs());
				}
				lastMousePressed = true;
			}
			else
			{
				lastMousePressed = false;
			}
            
        }

        public abstract void Draw(RenderTarget target, RenderStates states);
        public abstract FloatRect GetGlobalBounds();
    }
}
