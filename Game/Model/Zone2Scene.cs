using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game.Abstract;

namespace Game.Model
{
    public class Zone2Scene : IScene
    {
        private readonly Player _playerModel;
        private readonly Entity _playerEntity;
        private readonly SceneManager _sceneManager;

        public Zone SceneZone { get; private set; }
        public Vector3 StartingPosition { get; private set; }

        public Zone2Scene(Player playerModel, Entity playerEntity, SceneManager sceneManager)
        {
            _playerModel = playerModel;
            _playerEntity = playerEntity;
            _sceneManager = sceneManager;
            StartingPosition = new Vector3(1, 1, 1);
        }

        public void PopulateZone()
        {
            SceneZone = new Zone("Zone 2", new Vector3(Console.WindowWidth, Console.WindowHeight, 3));
            SceneZone.AddEntity(_playerEntity);
        }
    }
}
