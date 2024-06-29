using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game.Abstract;

namespace Game.Model
{
    public class Barter : IBarter
    {
        public Dictionary<IItem, int> Stock { get; private set; }

        public Barter()
        {
            Stock = new Dictionary<IItem, int>();
        }
    }
}
