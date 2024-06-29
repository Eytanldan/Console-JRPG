using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game.Abstract;
using Game.States;

namespace Game.Model.Components
{
    public class BarterComponent : Component, IEntityEntranceComponent
    {
        private readonly IBarter _barter;
        private readonly Player _player;

        public BarterComponent(IBarter barter, Player player)
        {
            _barter = barter;
            _player = player;
        }

        public bool CanEnter(Entity entity)
        {
            return true;
        }

        public void Enter(Entity entity)
        {
            Program.Engine.PushState(new BarterState(_barter, _player));
        }
    }
}
