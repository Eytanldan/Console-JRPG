using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game.Abstract;
using Game.Model.Components;

namespace Game.Model
{
    public class SceneManager
    {
        private Player _playerModel;
        private List<IScene> _scenes;

        public Entity PlayerEntity { get; private set; }

        public SceneManager()
        {
            _playerModel = new Player();
            _scenes = new List<IScene>();
            PlayerEntity = new Entity();
        }

        public IScene GetFirstScene()
        {
            return _scenes[0];
        }

        public void Initialize()
        {
            InstanstiatePlayer();
            PopulateSceneList();
        }


        private void InstanstiatePlayer()
        {
            
            _playerModel.AddAbility(new Ability("Fireball", 10));
            _playerModel.AddAbility(new Ability("Firestorm", 100));
            _playerModel.AddItem(new Item("Axe", false, true, totalDamage: 30));
            _playerModel.AddItem(new Item("Bow", false, true, totalDamage: 2));
            
            PlayerEntity.AddComponent(new SpriteComponent { Sprite = '$' });
            PlayerEntity.AddComponent(new PlayerComponent(_playerModel));
            PlayerEntity.Position = new Vector3(2, 2, 1);
        }

        private void PopulateSceneList()
        {
            var scene1 = new Zone1Scene(_playerModel, PlayerEntity);

            _scenes.Add(scene1);

            _scenes.ForEach(s => s.PopulateZone());
        }
    }
}
