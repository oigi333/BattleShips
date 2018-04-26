using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML.Window;
using SFML.Graphics;
using SFML.System;
using SFML.Audio;

namespace GameStates
{
    public class Settings: IGameState
    {
        public Settings() { }
        
        public void Init(RenderWindow window)
        {
        }

        public void Show(RenderWindow window)
        {
            window.Clear(Color.Magenta);
        }

        public void Update(RenderWindow window)
        {

        }
    }
}
