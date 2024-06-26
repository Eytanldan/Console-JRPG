using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game.Model;

namespace Game.Abstract
{
    public interface IZoneListener
    {
        void EntityMoved(Entity entity, Vector3 newPosition);
        void EntityAdded(Entity entity);
        void EntityRemoved(Entity entity);
    }
}
