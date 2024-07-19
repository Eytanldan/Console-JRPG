using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game.Abstract;

namespace Game.Model.Components
{
    public class ElevationBasedEntranceComponent : Component, IEntityEntranceComponent
    {
        private readonly bool _canEnterBelow;
        private readonly bool _canEnterAbove;

        public ElevationBasedEntranceComponent(bool canEnterBelow, bool canEnterAbove)
        {
            _canEnterBelow = canEnterBelow;
            _canEnterAbove = canEnterAbove;
        }

        public bool CanEnter(Entity entity)
        {
            if (entity.Position.Z == this.Parent.Position.Z)
                throw new InvalidOperationException("Entity cannot be at the same elevation as entering entity");

            if(Math.Abs(entity.Position.Z - this.Parent.Position.Z) == 1)
                if (entity.Position.Z > this.Parent.Position.Z)
                    return _canEnterAbove;
                else return _canEnterBelow;

            return false;
        }

        public void Enter(Entity entity)
        {

        }
    }
}
