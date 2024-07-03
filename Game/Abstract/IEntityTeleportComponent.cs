using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Abstract
{
    interface IEntityTeleportComponent : IEntityEntranceComponent
    {
        Vector3 NewPosition { get; }
    }
}
