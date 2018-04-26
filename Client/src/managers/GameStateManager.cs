using System;
using System.Collections.Generic;
using SFML.Window;
using SFML.Graphics;
using SFML.System;

namespace GameStates
{
    /// <summary>
    /// Heart of a project. GameStateManager is as it's name suggest, manager of gamestates.
    /// </summary>
    public static class GameStateManager
    {
        private static String _current = null;
        /// <summary>
        /// List of all gamestates.
        /// </summary>
        public static Dictionary<String,IGameState> GameStates = new Dictionary<String,IGameState>();
        public static float DeltaTime;
        /// <summary>
        /// Current gamestate.
        /// </summary>
        public static String Current
        {
            get { return _current; }
            set
            {
                if(GameStates.ContainsKey(value)) _current = value;
            }
        } 
        /// <summary>
        /// Add new Gamestate to the list.
        /// </summary>
        /// <typeparam name="GameState">It's interface.</typeparam>
        /// <param name="name">New gamestate future name.</param>
        /// <param name="window">Yer window.</param>
        public static void Add<GameState>(String name, RenderWindow window) where GameState : IGameState, new()
        {
            GameState gameState = new GameState();
            gameState.Init(window);
            GameStates.Add(name,gameState);
        }
        /// <summary>
        /// Call it when you want to show the window(all frames).
        /// </summary>
        /// <param name="window"></param>
        public static void Show(RenderWindow window)
        {
            GameStates[Current].Show(window);
        }
        /// <summary>
        /// Call it when you want update things, do it quite often but no too much.
        /// </summary>
        /// <param name="window"></param>
        public static void Update(RenderWindow window)
        {
            GameStates[Current].Update(window);
        }
    }    
}