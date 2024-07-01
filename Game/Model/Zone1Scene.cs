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
        public Player PlayerModel { get; private set; }
        public Entity PlayerEntity { get; private set; }
        public Zone SceneZone { get; private set; }

        public Zone1Scene(Player playerModel, Entity playerEntity)
        {
            PlayerModel = playerModel;
            PlayerEntity = playerEntity;
        }

        public void PopulateZone()
        {
            var random = new Random();

            PlayerEntity.Position = new Vector3(2, 2, 1);

            // combat instantiations

            var tallGrass = new Entity();
            tallGrass.AddComponent(new SpriteComponent { Sprite = '#' });
            tallGrass.AddComponent(new CombatComponent(() => new Combat(PlayerModel, new BasicMob())));
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
            shopKeep.AddComponent(new BarterComponent(shopBarter, PlayerModel));
            shopKeep.AddComponent(new SpriteComponent { Sprite = '&' });
            shopKeep.Position = new Vector3(6, 6, 0);

            SceneZone = new Zone("Zone 1", new Vector3(Console.WindowWidth, Console.WindowHeight, 3));
            SceneZone.AddEntity(PlayerEntity);
            SceneZone.AddEntity(tallGrass);
            SceneZone.AddEntity(ceiling);
            SceneZone.AddEntity(wall);
            SceneZone.AddEntity(npc1);
            SceneZone.AddEntity(shopKeep);
        }
    }
}
