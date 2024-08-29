using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game.Abstract;
using Game.Model;

namespace Game.States
{
    public class CombatState : IEngineState, ICombatListener
    {
        private readonly Combat _combat;
        private int _selectedOption;
        private int _lastSelectedAttack;
        private bool _combatEnded;
        private bool isSelectingTarget;

        public CombatState(Combat combat)
        {
            _combat = combat;
            _combat.AddListener(this);
        }

        public void ProcessInput(ConsoleKeyInfo key)
        {
            var abilityCount = _combat.Player.Abilities.Count();
            int totalCount;

            if(isSelectingTarget)
            {
                totalCount = _combat.Enemies.Where(e => e.Hp > 0).Count();
            }
            else
            {
                var itemCount = _combat.Player.Inventory.Where(i => i.CanUse).Count();
                totalCount = abilityCount + itemCount;
            }

            if (key.Key == ConsoleKey.W)
            {
                if (_selectedOption > 0)
                    _selectedOption--;
            }
            else if (key.Key == ConsoleKey.S)
            {
                if (_selectedOption < totalCount - 1)
                    _selectedOption++;
            }
            else if (key.Key == ConsoleKey.Spacebar)
            {
                SelectOption(isSelectingTarget);
            }

            if(!_combatEnded)
                RenderMode(isSelectingTarget);
        }

        public void DisplayMessage(string message)
        {
            RenderHeader();
            Console.WriteLine(message);
            Console.WriteLine("Press any key...");
            Console.ReadKey();
        }

        public void EndCombat()
        {
            _combatEnded = true;
            Program.Engine.PopState(this);
        }

        public void PlayerDied()
        {
            Console.WriteLine("YOU DIED!");
            Console.ReadKey();
            Program.Engine.Quit();
        }

        public void Activate()
        {
            Render();
        }

        public void Deactivate()
        {
            
        }

        public void Dispose()
        {
            _combat.RemoveListener(this);
        }

        private void SelectOption(bool onTargetSelect)
        {
            if(onTargetSelect)
            {
                SelectTarget();
                _selectedOption = 0;
            }
            else
            {
                _lastSelectedAttack = _selectedOption;
                _selectedOption = 0;
            }

            isSelectingTarget = !isSelectingTarget;
        }

        private void SelectTarget()
        {
            var abilityCount = _combat.Player.Abilities.Count();

            if (_lastSelectedAttack < abilityCount)
                _combat.UseAbility(_combat.Player.Abilities.ElementAt(_lastSelectedAttack), _combat.Enemies.Where(e => e.Hp > 0)
                    .ElementAt(_selectedOption));
            else
                _combat.UseItem(_combat.Player.Inventory.Where(i => i.CanUse).ElementAt(_lastSelectedAttack - abilityCount),
                    _combat.Enemies.Where(e => e.Hp > 0).ElementAt(_selectedOption));
        }

        private void RenderMode(bool isRenderingTargts)
        {
            if(isRenderingTargts)
            {
                RenderTargets();
            }
            else
            {
                Render();
            }
        }

        private void Render()
        {
            RenderHeader();

            var index = 0;

            foreach (var ability in _combat.Player.Abilities)
            {
                if (_selectedOption == index)
                    ColorConsole(true);

                Console.WriteLine(ability.Name);
                index++;
                ColorConsole(false);
            }

            Console.WriteLine("----------------------");
            foreach (var item in _combat.Player.Inventory.Where(i => i.CanUse))
            {
                if (_selectedOption == index)
                    ColorConsole(true);

                Console.WriteLine(item.Name);
                index++;
                ColorConsole(false);
            }
        }

        private void RenderTargets()
        {
            RenderHeader();

            var index = 0;

            foreach (var enemy in _combat.Enemies.Where(e => e.Hp > 0))
            {
                if (_selectedOption == index)
                    ColorConsole(true);

                Console.WriteLine(enemy.Name);
                index++;
                ColorConsole(false);
            }
            
        }

        private void RenderHeader()
        {
            Console.Clear();
            Console.WriteLine("You (hp: {0}) vs {1} (hp: {2})", _combat.Player.Hp, _combat.Enemies.First().Name, _combat.Enemies.First().Hp);

            if(_combat.Enemies.Count() > 1)
                foreach (var enemy in _combat.Enemies.Skip(1))
                {
                    Console.WriteLine("                 {0} (hp: {1})", enemy.Name, enemy.Hp);
                }

            Console.WriteLine("----------------------");
        }

        private void ColorConsole(bool selected)
        {
            if (selected)
            {
                Console.ForegroundColor = ConsoleColor.Black;
                Console.BackgroundColor = ConsoleColor.Gray;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.BackgroundColor = ConsoleColor.Black;
            }
        }
    }
}
