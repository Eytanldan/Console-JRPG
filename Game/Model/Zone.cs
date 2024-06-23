using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game.Abstract;
using Game.Externsions;

namespace Game.Model
{
    public class Zone
    {
        private readonly HashSet<IZoneListener> _listeners;

        public Zone()
        {
            _listeners = new HashSet<IZoneListener>();
        }

        public void MoveEntity()
        {
            _listeners.ForEach(l => l.EntityMoved());
        }

        public void AddListener(IZoneListener listener)
        {
            if (!_listeners.Add(listener))
                throw new ArgumentException();
        }
        public void RemoveListener(IZoneListener listener)
        {
            if (!_listeners.Remove(listener))
                throw new ArgumentException();
        }
    }
}
