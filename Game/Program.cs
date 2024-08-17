using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game.States;
using Game.Model;
using Game.Abstract;

namespace Game
{
    public static class Program
    {
        public static Engine Engine { get; private set; }

        static void Main(string[] args)
        {
            // console window settings

            const int ZoneWidth = 50;
            const int ZoneHeight = 30;

            Console.BufferWidth = Console.WindowWidth = ZoneWidth;
            Console.BufferHeight = Console.WindowHeight = ZoneHeight;

            var sceneManager = new SceneManager();
            sceneManager.Initialize();

            var startingDialog = new Dialog(
                new DialogScreen("press space to start the game...", nextScreens: new Dictionary<string, IDialogScreen> 
                {
                    {"...", new DialogScreen("King 0: The evil 7 headed Hydra has kidnnaped     princcess 9 and plannes to eat her.", nextScreens: new Dictionary<string, IDialogScreen>
                    {
                        { "...", new DialogScreen("King 0: You are the 1 Hero, our only hope. You    must travel to the Hydra's lair and rescue her.") }
                    }) }
                }));

            // engine instantiations

            Engine = new Engine();
            Engine.PushState(new ZoneState(sceneManager.PlayerEntity, sceneManager.GetStartingZone()));
            Engine.PushState(new DialogState(sceneManager.PlayerEntity, startingDialog));

            while (Engine.IsRunning)
                Engine.ProcessInput(Console.ReadKey(true));
        }
    }
}
