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
        static void Main()
        {
            RenderWindow window = new RenderWindow(new VideoMode(1000, 500), "BattleShips");
            window.Closed += (sender, eventArg) => window.Close();

            LanguageManager.Init("res/lang.json");
            LanguageManager.SetCurrent("pl");

            AssetManager.Add<Font >("Bungee",@"res/fonts/Bungee-Regular.ttf");
            AssetManager.Add<Texture>("SettingsIcon",@"res/img/settings.png");

            InitializeGameStates(window);

            Stopwatch deltaTimer = new Stopwatch();
            float deltaTime =  0;
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
