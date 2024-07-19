using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game.Model;

namespace Game.Abstract
{
    interface IEntityHeightComponent : IEntityEntranceComponent
    {
        Vector3 ChangeHeight(Entity entity, Vector3 newPosition);
    }
}
