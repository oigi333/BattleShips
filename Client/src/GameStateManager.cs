using System;
using System.Collections.Generic;
using SFML.Window;
using SFML.Graphics;
using SFML.System;

namespace GameStates
{
    public static class GameStateManager
    {
        private static String _current = null;
        public static Dictionary<String,IGameState> GameStates = new Dictionary<String,IGameState>();
        public static float DeltaTime;

        public static String Current
        {
            get { return _current; }
            set
            {
                if(GameStates.ContainsKey(value)) _current = value;
            }
        } 

        public static void Add<GameState>(String name, RenderWindow window) where GameState : IGameState, new()
        {
            GameState gameState = new GameState();
            gameState.Init(window);
            GameStates.Add(name,gameState);
        }

        public static void Show(RenderWindow window)
        {
            GameStates[Current].Show(window);
        }

        public static void Update(RenderWindow window)
        {
            GameStates[Current].Update(window);
        }
    }    
}