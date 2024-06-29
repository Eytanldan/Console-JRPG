using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game.Abstract;

namespace Game.Model
{
    public class Player
    {
        private readonly List<IItem> _equippedItems;
        private readonly List<IItem> _inventory;
        private readonly List<IAbility> _abilities;

        public IEnumerable<IItem> EquippedItems { get { return _equippedItems; } }
        public IEnumerable<IItem> Inventory { get { return _inventory; } }
        public IEnumerable<IAbility> Abilities { get { return _abilities; } }
        public int Hp { get; private set; }
        public int Gold { get; private set; }

        public Player()
        {
            Hp = 200;
            Gold = 50;

            _equippedItems = new List<IItem>();
            _inventory = new List<IItem>();
            _abilities = new List<IAbility>();
        }

        public void TakeDamage(Damage damage)
        {
            damage = _equippedItems.Aggregate(damage, (a, i) => i.ModifyDamage(a));
            Hp -= Math.Max(0, damage.Amount);
        }

        public void AddGold(int amount)
        {
            Gold += amount;
        }

        public void DecreaseGold(int amount)
        {
            Gold -= Math.Max(0, amount);
            if (Gold < 0)
                Gold = 0;
        }

        public void AddAbility(IAbility ability)
        {
            _abilities.Add(ability);
        }

        public void AddItem(IItem item)
        {
            _inventory.Add(item);
        }

        public void EquipItem(IItem item)
        {
            _inventory.Remove(item);
            _equippedItems.Add(item);
        }

        public void UnequipItem(IItem item)
        {
            _equippedItems.Remove(item);
            _inventory.Add(item);
        }
    }
}
