using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game.Abstract;

namespace Game.Model.Components
{
    public class EncounterChanceEntranceComponent : Component, IEntityEntranceComponent
    {
        private readonly CombatComponent _combatEncounter;
        private readonly int _encounterRate;

        public EncounterChanceEntranceComponent(CombatComponent combatEncounter, int encounterRate)
        {
            _combatEncounter = combatEncounter;
            _encounterRate = encounterRate;
        }

        public bool CanEnter(Entity entity)
        {
            return true;
        }

        public void Enter(Entity entity)
        {
            var random = new Random();
            if (random.Next(0, _encounterRate + 1) == _encounterRate)
                _combatEncounter.Enter(entity);
        }
    }
}
