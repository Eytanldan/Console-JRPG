using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game.States;
using Game.Model;
using Game.Model.Components;

namespace Game
{
    public static class Program
    {
        public static Engine Engine { get; private set; }

        static void Main(string[] args)
        {
            const int ZoneWidth = 50;
            const int ZoneHeight = 30;

            Console.BufferWidth = Console.WindowWidth = ZoneWidth;
            Console.BufferHeight = Console.WindowHeight = ZoneHeight;

            var player = new Entity();
            player.AddComponent(new SpriteComponent { Sprite = '$'});
            player.Position = new Vector3(2, 2, 1);

            var tallGrass = new Entity();
            tallGrass.AddComponent(new SpriteComponent { Sprite = '#' });
            tallGrass.Position = new Vector3(3, 3, 0);

            var ceiling = new Entity();
            ceiling.AddComponent(new SpriteComponent { Sprite = '@' });
            ceiling.Position = new Vector3(4, 4, 2);

            var zone1 = new Zone("Zone 1", new Vector3(ZoneWidth, ZoneHeight, 3));
            zone1.AddEntity(player);
            zone1.AddEntity(tallGrass);
            zone1.AddEntity(ceiling);

            Engine = new Engine();
            Engine.PushState(new ZoneState(player, zone1));

            while (Engine.IsRunning)
                Engine.ProcessInput(Console.ReadKey(true));
        }
    }
}
