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
            var random = new Random();

            // console window settings

            const int ZoneWidth = 50;
            const int ZoneHeight = 30;

            Console.BufferWidth = Console.WindowWidth = ZoneWidth;
            Console.BufferHeight = Console.WindowHeight = ZoneHeight;

            // player instantiations

            var playerModel = new Player();
            playerModel.AddAbility(new Ability("Fireball", 10));
            playerModel.AddAbility(new Ability("Firestorm", 100));
            playerModel.AddItem(new Item("Axe", false, true, totalDamage: 30));
            playerModel.AddItem(new Item("Bow", false, true, totalDamage: 2));

            var player = new Entity();
            player.AddComponent(new SpriteComponent { Sprite = '$'});
            player.AddComponent(new PlayerComponent(playerModel));
            player.Position = new Vector3(2, 2, 1);

            // combat instantiations

            var tallGrass = new Entity();
            tallGrass.AddComponent(new SpriteComponent { Sprite = '#' });
            tallGrass.AddComponent(new CombatComponent(() => new Combat(playerModel, new BasicMob())));
            tallGrass.Position = new Vector3(3, 3, 0);

            // higher elevations instantiations

            var ceiling = new Entity();
            ceiling.AddComponent(new SpriteComponent { Sprite = '@' });
            ceiling.Position = new Vector3(4, 4, 2);

            // entance component instantiations

            var wall = new Entity();
            wall.AddComponent(new ConstantEntranceComponent(false));
            wall.AddComponent(new SpriteComponent { Sprite = '*' });
            wall.Position = new Vector3(5, 5, 0);

            // dialog instantiations

            var npc1 = new Entity();
            npc1.AddComponent(new DialogComponent(new Dialog
                (
                new DialogScreen("Have this item!", 
                e => e.GetComponent<PlayerComponent>().Player.AddItem(
                    new Item("Armor - " + random.Next(0,100), true, false, -5)))
                )));
            npc1.AddComponent(new SpriteComponent { Sprite = '!' });
            npc1.Position = new Vector3(1, 1, 0);

            // barter instantiations

            var shopBarter = new Barter();
            shopBarter.Stock.Add(new Item("Leather Boots", true, false, -1), 5);
            shopBarter.Stock.Add(new Item("Steel Longsword", false, true, totalDamage: 25), 10);
            shopBarter.Stock.Add(new Item("Firebomb", false, true, totalDamage: 50), 30);

            var shopKeep = new Entity();
            shopKeep.AddComponent(new BarterComponent(shopBarter, playerModel));
            shopKeep.AddComponent(new SpriteComponent { Sprite = '&' });
            shopKeep.Position = new Vector3(6, 6, 0);

            // zone instantiations

            var zone1 = new Zone("Zone 1", new Vector3(ZoneWidth, ZoneHeight, 3));
            zone1.AddEntity(player);
            zone1.AddEntity(tallGrass);
            zone1.AddEntity(ceiling);
            zone1.AddEntity(wall);
            zone1.AddEntity(npc1);
            zone1.AddEntity(shopKeep);

            // engine instantiations

            Engine = new Engine();
            Engine.PushState(new ZoneState(player, zone1));

            while (Engine.IsRunning)
                Engine.ProcessInput(Console.ReadKey(true));
        }
    }
}
