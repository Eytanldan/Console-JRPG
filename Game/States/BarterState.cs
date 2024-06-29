using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game.Abstract;
using Game.Model;

namespace Game.States
{
    public class BarterState : IEngineState
    {
        private readonly IBarter _barter;
        private readonly Player _player;
        private readonly List<Tuple<IItem, int>> _optionList;
        
        private int _selectedItem;
        private string _transactionName;
        private int _transactionPrice;
        private bool _transactionMade;
        private bool isAffordable;

        public BarterState(IBarter barter, Player player)
        {
            _barter = barter;
            _player = player;
            _optionList = _barter.Stock.Select(kv => Tuple.Create(kv.Key, kv.Value)).ToList();
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
            
        }

        public void ProcessInput(ConsoleKeyInfo key)
        {
            if (key.Key == ConsoleKey.W)
            {
                if (_selectedItem > 0)
                    _selectedItem--;
            }
            else if (key.Key == ConsoleKey.S)
            {
                if (_selectedItem < _optionList.Count)
                    _selectedItem++;
            }
            else if (key.Key == ConsoleKey.Spacebar && _selectedItem <= _optionList.Count - 1)
            {
                var item = _optionList[_selectedItem].Item1;
                var price = _optionList[_selectedItem].Item2;

                ConfirmTransaction(item, price);
            }
            else if (key.Key == ConsoleKey.Spacebar && _selectedItem == _optionList.Count)
            {
                Program.Engine.PopState(this);
                return;
            }

                Render();
        }

        private void RenderTransaction()
        {
            Console.WriteLine("You bought {0} for {1} !", _transactionName, _transactionPrice);
        }

        private void Render()
        {
            Console.Clear();
            Console.WriteLine("Purchasable Stock");
            Console.WriteLine("--------------------------");
            Console.WriteLine("Player Gold: {0}", _player.Gold);
            Console.WriteLine("--------------------------");

            var itemIndex = 0;

            foreach (var item in _barter.Stock)
            {
                if (itemIndex == _selectedItem)
                    ColorConsole(true);

                Console.WriteLine("{0} - {1} Gold", item.Key.Name, item.Value);
                ColorConsole(false);

                itemIndex++;
            }
            
            if (itemIndex == _selectedItem)
                ColorConsole(true);

            Console.WriteLine("Exit");
            ColorConsole(false);

            Console.WriteLine("--------------------------");

            if (_transactionMade)
                if (isAffordable)
                    RenderTransaction();
                else
                    Console.WriteLine("You don't have enough gold for that !");
        }

        private void ConfirmTransaction(IItem item, int price)
        {
            _transactionMade = true;
            
            if(_player.Gold < price)
            {
                isAffordable = false;
                return;
            }

            isAffordable = true;

            _player.DecreaseGold(price);
            _player.AddItem(item);

            _transactionName = item.Name;
            _transactionPrice = price;
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
