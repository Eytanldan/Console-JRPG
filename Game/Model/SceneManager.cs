using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game.Abstract;
using Game.Model.Components;
using Game.States;

namespace Game.Model
{
    public class SceneManager
    {
        private readonly Player _playerModel;
        private readonly List<IScene> _scenes;

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

        public IScene GetNextScene(IScene CurrentScene)
        {
            for(int i = 0; i < _scenes.Count; i++)
            {
                if (_scenes[i] == CurrentScene)
                    if(_scenes[i + 1] != null)
                        return _scenes[i + 1];
            }

            return null;
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
            PlayerEntity.Position = new Vector3(24, 20, 1);
        }

        private void PopulateSceneList()
        {
            var scene1 = new Zone1Scene(_playerModel, PlayerEntity, this);
            var scene2 = new Zone2Scene(_playerModel, PlayerEntity, this);
            var kindomScene = new KingdomScene(_playerModel, PlayerEntity, this);

            _scenes.Add(kindomScene);
            _scenes.Add(scene1);
            _scenes.Add(scene2);

            _scenes.ForEach(s => s.PopulateZone());
        }
    }
}
