using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game.Abstract;

namespace Game.Model
{
    public class Combat
    {
        private readonly List<ICombatListener> _listeners;
        public Player Player { get; private set; }
        public ICombatEntity Entity { get; private set; }

        public Combat(Player player, ICombatEntity entity)
        {
            _listeners = new List<ICombatListener>();
            Player = player;
            Entity = entity;
        }

        public void UseItem(IItem item)
        {
            if (!item.CanUse)
            {
                _listeners.ForEach(f => f.DisplayMessage("Can't use " + item.Name));
                return;
            }

            PerformAction(item.GetDamage(Entity));
            
        }

        public void UseAbility(IAbility ability)
        {
            PerformAction(ability.GetDamage(Entity));
        }

        private void PerformAction(Damage damage)
        {
            _listeners.ForEach(f => f.DisplayMessage(
                Entity.Name + " took " + damage.Amount + " damage from " + damage.Text));

            Entity.TakeDamage(damage);
            if (Entity.Hp <= 0)
            {
                _listeners.ForEach(f => f.DisplayMessage(Entity.Name + " died"));
                //_listeners.ForEach(f => f.EndCombat()); // contiues to loop after disposing the combat state causing exception
                _listeners.First().EndCombat(); // alterntive to commented line above, seems to work fine
                return;
            }

            damage = Entity.GetDamage(Player);
            _listeners.ForEach(f => f.DisplayMessage("Player took " + damage.Amount + " damage from " + damage.Text));
            Player.TakeDamage(damage);

            if (Player.Hp <= 0)
            {
                _listeners.ForEach(f => f.PlayerDied());
            }
        }

        public void AddListener(ICombatListener listener)
        {
            _listeners.Add(listener);
        }

        public void RemoveListener(ICombatListener listener)
        {
            _listeners.Remove(listener);
        }
    }
}
