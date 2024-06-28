using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Abstract
{
    public interface IItem
    {
        string Name { get; }
        bool CanEquip { get; }
        bool CanUse { get; }

        Damage GetDamage(ICombatEntity entity);
        Damage ModifyDamage(Damage damage);
    }
}
