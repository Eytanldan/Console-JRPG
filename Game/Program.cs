using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game.States;
using Game.Model;

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

            // engine instantiations

            Engine = new Engine();
            Engine.PushState(new ZoneState(sceneManager.PlayerEntity, sceneManager.GetStartingZone()));

            while (Engine.IsRunning)
                Engine.ProcessInput(Console.ReadKey(true));
        }
    }
}
