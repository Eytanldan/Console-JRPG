﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Abstract
{
    public interface IAbility
    {
        string Name { get;  }

        Damage GetDamage(ICombatEntity entity);
    }
}
