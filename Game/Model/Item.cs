﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game.Abstract;

namespace Game.Model
{
    public class Item : IItem
    {
        private int _damageModifier;
        private int _totalDamage;

        public string Name { get; private set; }
        public bool CanEquip { get; private set; }
        public bool CanUse { get; private set; }

        public Item(string name, bool canEquip, bool canUse, int? damageModifier = null, int? totalDamage = null)
        {
            Name = name;
            CanEquip = canEquip;
            CanUse = canUse;
            _damageModifier = damageModifier ?? 0;
            _totalDamage = totalDamage ?? 0;
        }

        public Damage GetDamage(ICombatEntity entity)
        {
            return new Damage(Name, _totalDamage);
        }

        public Damage ModifyDamage(Damage damage)
        {
            return damage.ModifyAmount(_damageModifier);
        }
    }
}
