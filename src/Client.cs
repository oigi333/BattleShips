using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML.Window;
using SFML.Graphics;
using SFML.System;
using System.Diagnostics;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace Client
{
    class Client
    {
        // For hiding the console
        [DllImport("kernel32.dll")]
        private static extern IntPtr GetConsoleWindow();
        [DllImport("user32.dll")]
        private static extern bool ShowWindow(IntPtr hWnd, int cmdShow);

        static void Main()
        {
            // Hide the console
            IntPtr hWnd = GetConsoleWindow();
            if(hWnd != IntPtr.Zero) ShowWindow(hWnd, 0);

            RenderWindow window = new RenderWindow(new VideoMode(1000,500),"BattleShips");
            window.Closed += (sender, eventArg) => window.Close();

            InitializeGameStates(window);

            Stopwatch deltaTimer = new Stopwatch();
            float deltaTime = 0;
            while (window.IsOpen) 
            {
                deltaTime += deltaTimer.ElapsedMilliseconds;
                deltaTimer.Restart();
                if (deltaTime > 1000 / 60)
                {
                    deltaTime /= 1000;
                    GameStates.GameStateManager.Update(window);
                    deltaTime = 0;
                }
                window.DispatchEvents();

                GameStates.GameStateManager.Show(window);
                window.Display();

                deltaTimer.Stop();
            }
        }

        static void InitializeGameStates(RenderWindow window)
        {
            GameStates.GameStateManager.Current = "Menu";
            GameStates.GameStateManager.Add<GameStates.Menu>("Menu", window);
        }
    }
}
