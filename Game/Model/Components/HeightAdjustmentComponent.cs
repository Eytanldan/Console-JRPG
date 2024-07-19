using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game.Abstract;

namespace Game.Model.Components
{
    public class HeightAdjustmentComponent : Component, IEntityHeightComponent
    {
        private readonly int _height;

        public HeightAdjustmentComponent(int height)
        {
            _height = height;
        }

        public bool CanEnter(Entity entity)
        {
            return true;
        }

        public Vector3 ChangeHeight(Entity entity, Vector3 newPosition)
        {
            if (entity.Position.Z != _height)
                return new Vector3(newPosition.X, newPosition.Y, _height);

            return newPosition;
        }

        public void Enter(Entity entity)
        {
            
        }
    }
}
