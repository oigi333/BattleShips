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

namespace Client
{
    class Client
    {
        static void Main()
        {

            RenderWindow window = new RenderWindow(new VideoMode(1000,500),"BattleShips"); //Tu se tworze okienko
            window.Closed += (sender, eventArg) => window.Close(); // tu se ustalam co się stanie jak okienko będzie zamykane; to jest lambda jak coś

            InitializeGameStates(window);

            Stopwatch deltaTimer = new Stopwatch(); // Do pętli stałokrokowej
            float deltaTime = 0;  //-||-
            while (window.IsOpen) 
            {
                deltaTime += deltaTimer.ElapsedMilliseconds; //-||-
                deltaTimer.Restart(); //-||-
                if (deltaTime > 1000 / 60) //Pętla stałokrokowa
                {
                    deltaTime /= 1000;
                    GameStates.GameStateManager.Update(window);
                    deltaTime = 0; // do pętli znów
                }
                window.DispatchEvents(); //Bo tak lubi c# trudno

                GameStates.GameStateManager.Show(window);
                window.Display(); //wyświetl się

                deltaTimer.Stop(); // znów do pętli
            }
        }

        static void InitializeGameStates(RenderWindow window)
        {
            GameStates.GameStateManager.Current = "Menu";
            GameStates.GameStateManager.Add<GameStates.Menu>("Menu",window);
        }
    }
}
