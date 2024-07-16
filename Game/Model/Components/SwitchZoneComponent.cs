using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game.Abstract;
using Game.States;

namespace Game.Model.Components
{
    public class SwitchZoneComponent : Component, IEntityTeleportComponent
    {
        private readonly IScene _nextScene;
        public Vector3 NewPosition { get; private set; }

        public SwitchZoneComponent(IScene nextScene, Vector3 otherEnterPos = null)
        {
            _nextScene = nextScene;
            NewPosition = otherEnterPos ?? _nextScene.StartingPosition;
        }


        public bool CanEnter(Entity entity)
        {
            return true;
        }

        public void Enter(Entity entity)
        {
            if (_nextScene != null)
            {
                entity.Position = NewPosition;
                Program.Engine.SwitchState(new ZoneState(entity, _nextScene.SceneZone));
            }
            else
                throw new ArgumentNullException("The Scene you are trying to switch to is null");
        }
    }
}
