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
        private int enemyCount;
        public Player Player { get; private set; }
        public IEnumerable<ICombatEntity> Enemies { get; private set; }

        public Combat(Player player, IEnumerable<ICombatEntity> enemies)
        {
            _listeners = new List<ICombatListener>();
            Player = player;
            Enemies = enemies;
            enemyCount = Enemies.Count();
        }

        public void UseItem(IItem item, ICombatEntity target)
        {
            if (!item.CanUse)
            {
                _listeners.ForEach(f => f.DisplayMessage("Can't use " + item.Name));
                return;
            }

            PerformAction(item.GetDamage(target), target);
            
        }

        public void UseAbility(IAbility ability, ICombatEntity target)
        {
            PerformAction(ability.GetDamage(target), target);
        }

        private void PerformAction(Damage damage, ICombatEntity target)
        {
            _listeners.ForEach(f => f.DisplayMessage(
                target.Name + " took " + damage.Amount + " damage from " + damage.Text));

            target.TakeDamage(damage);
            if (target.Hp <= 0)
            {
                _listeners.ForEach(f => f.DisplayMessage(target.Name + " died"));
                enemyCount--;
                
                if(enemyCount <= 0)
                {
                    //_listeners.ForEach(f => f.EndCombat()); // contiues to loop after disposing the combat state causing exception
                    _listeners.First().EndCombat(); // alterntive to commented line above, seems to work fine
                    return;
                }
            }

            foreach(var enemy in Enemies.Where(e => e.Hp > 0))
            {
                damage = enemy.GetDamage(Player);
                _listeners.ForEach(f => f.DisplayMessage("Player took " + damage.Amount + " damage from " + damage.Text));
                Player.TakeDamage(damage);

                if (Player.Hp <= 0)
                {
                    _listeners.ForEach(f => f.PlayerDied());
                }
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
