using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game.Model;

namespace Game.Abstract
{
    public interface ICombatEntity
    {
        string Name { get; }
        int Hp { get; }

        Damage GetDamage(Player player);
        void TakeDamage(Damage damage);
    }
}
