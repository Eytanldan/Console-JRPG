using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game.Abstract;

namespace Game.States
{
    public class ZoneRenderer : IZoneListener
    {
        public void EntityMoved()
        {
            Console.WriteLine("ENTITY MOVED!");
        }
    }
}
