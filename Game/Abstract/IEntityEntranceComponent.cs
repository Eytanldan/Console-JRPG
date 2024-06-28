using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game.Model;

namespace Game.Abstract
{
    public interface IEntityEntranceComponent : IComponent
    {
        bool CanEnter(Entity entity);
        void Enter(Entity entity);
    }
}
