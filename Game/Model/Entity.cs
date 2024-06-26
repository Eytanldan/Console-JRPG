﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game.Abstract;

namespace Game.Model
{
    public class Entity
    {
        private readonly List<IComponent> _components;

        public Vector3 Position { get; set; }

        public Entity()
        {
            _components = new List<IComponent>();
            Position = new Vector3(0, 0, 0);
        }

        public void AddComponent(IComponent component)
        {
            component.Parent = this;
            _components.Add(component);
        }

        public void RemoveComponent(IComponent component)
        {
            if (component.Parent != this)
                throw new ArgumentException();

            _components.Remove(component);
        }

        public TComponent GetComponent<TComponent>()
            where TComponent : class, IComponent
        {
            return _components.OfType<TComponent>().FirstOrDefault();
        }

        public IEnumerable<TComponent> GetComponents<TComponent>()
            where TComponent : class, IComponent
        {
            return _components.OfType<TComponent>().ToList();
        }
    }
}
