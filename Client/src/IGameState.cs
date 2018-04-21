using System;
using SFML.Window;
using SFML.Graphics;
using SFML.System;

namespace GameStates
{
    public interface IGameState
    {
        void Show(RenderWindow window);
        void Update(RenderWindow window);
        void Init(RenderWindow window);
    }
}