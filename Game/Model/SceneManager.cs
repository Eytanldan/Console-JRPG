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

        // Temp debug feature
        private readonly int debugZoneIndex = 0;

        public Entity PlayerEntity { get; private set; }

        public SceneManager()
        {
            _playerModel = new Player();
            _scenes = new List<IScene>();
            PlayerEntity = new Entity();
        }

        public Zone GetStartingZone()
        {
            return _scenes[debugZoneIndex].SceneZone;
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

        public IScene GetPreviousScene(IScene CurrentScene)
        {
            for (int i = 0; i < _scenes.Count; i++)
            {
                if (_scenes[i] == CurrentScene)
                    if (i > 0)
                        return _scenes[i - 1];
            }

            return null;
        }

        public IScene GetSceneByIndex(int index)
        {
            return _scenes[index];
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
            
            PlayerEntity.AddComponent(new SpriteComponent { Sprite = '1' });
            PlayerEntity.AddComponent(new PlayerComponent(_playerModel));
            PlayerEntity.Position = new Vector3(24, 20, 1);
        }

        private void PopulateSceneList()
        {
            var kindomScene = new KingdomScene(_playerModel, PlayerEntity, this);
            var overWorld1Scene = new Overworld1Scene(_playerModel, PlayerEntity, this);
            var overWorld2Scene = new Overworld2Scene(_playerModel, PlayerEntity, this);
            var forestScene = new ForestScene(_playerModel, PlayerEntity, this);
            var overWorld3Scene = new Overworld3Scene(_playerModel, PlayerEntity, this);
            var caveScene = new CaveScene(_playerModel, PlayerEntity, this);
            var mountain1Scene = new Mountain1Scene(_playerModel, PlayerEntity, this);
            var mountain2Scene = new Mountain2Scene(_playerModel, PlayerEntity, this);
            var lairScene = new LairScene(_playerModel, PlayerEntity, this);

            _scenes.Add(kindomScene);
            _scenes.Add(overWorld1Scene);
            _scenes.Add(overWorld2Scene);
            _scenes.Add(forestScene);
            _scenes.Add(overWorld3Scene);
            _scenes.Add(caveScene);
            _scenes.Add(mountain1Scene);
            _scenes.Add(mountain2Scene);
            _scenes.Add(lairScene);

            _scenes.ForEach(s => s.PopulateZone());
        }
    }
}
