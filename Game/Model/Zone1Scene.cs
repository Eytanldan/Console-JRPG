using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game.Abstract;
using Game.Model.Components;

namespace Game.Model
{
    public class Zone1Scene : IScene
    {
        private readonly Player _playerModel;
        private readonly Entity _playerEntity;
        private readonly SceneManager _sceneManager;

        public Zone SceneZone { get; private set; }
        public Vector3 StartingPosition { get; private set; }

        public Zone1Scene(Player playerModel, Entity playerEntity, SceneManager sceneManager)
        {
            _playerModel = playerModel;
            _playerEntity = playerEntity;
            _sceneManager = sceneManager;
            StartingPosition = new Vector3(2, 2, 1);
        }

        public void PopulateZone()
        {
            var random = new Random();

            // combat instantiations

            var tallGrass = new Entity();
            tallGrass.AddComponent(new SpriteComponent { Sprite = '#' });
            tallGrass.AddComponent(new CombatComponent(() => new Combat(_playerModel, new BasicMob())));
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
                    new Item("Armor - " + random.Next(0, 100), true, false, -5)))
                )));
            npc1.AddComponent(new SpriteComponent { Sprite = '!' });
            npc1.Position = new Vector3(1, 1, 0);

            // barter instantiations

            var shopBarter = new Barter();
            shopBarter.Stock.Add(new Item("Leather Boots", true, false, -1), 5);
            shopBarter.Stock.Add(new Item("Steel Longsword", false, true, totalDamage: 25), 10);
            shopBarter.Stock.Add(new Item("Firebomb", false, true, totalDamage: 50), 30);

            var shopKeep = new Entity();
            shopKeep.AddComponent(new BarterComponent(shopBarter, _playerModel));
            shopKeep.AddComponent(new SpriteComponent { Sprite = '&' });
            shopKeep.Position = new Vector3(6, 6, 0);

            var exit = new Entity();
            exit.AddComponent(new SwitchZoneComponent(_sceneManager.GetNextScene(this)));
            exit.AddComponent(new SpriteComponent { Sprite = '&' });
            exit.Position = new Vector3(6, 2, 0);

            SceneZone = new Zone("Zone 1", new Vector3(Console.WindowWidth, Console.WindowHeight, 3));
            SceneZone.AddEntity(_playerEntity);
            SceneZone.AddEntity(tallGrass);
            SceneZone.AddEntity(ceiling);
            SceneZone.AddEntity(wall);
            SceneZone.AddEntity(npc1);
            SceneZone.AddEntity(shopKeep);
            SceneZone.AddEntity(exit);
        }
    }
}
