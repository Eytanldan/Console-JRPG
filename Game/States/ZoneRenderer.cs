using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game.Abstract;
using Game.Model;
using Game.Model.Components;

namespace Game.States
{
    public class ZoneRenderer : IZoneListener
    {
        private readonly Zone _zone;
        private readonly SpriteComponent[, ,] _spriteBuffer;

        public bool IsActive { get; set; }

        public ZoneRenderer(Zone zone)
        {
            IsActive = true;
            _zone = zone;
            
            // instansiating a spriteBuffer and adding to it any entity in the zone that has a sprite component attached to it
            _spriteBuffer = new SpriteComponent[_zone.Size.X, _zone.Size.Y, _zone.Size.Z];
            foreach(var entity in _zone.Entities)
            {
                var component = entity.GetComponent<SpriteComponent>();
                if (component == null)
                    continue;

                _spriteBuffer[entity.Position.X, entity.Position.Y, entity.Position.Z] = component;
            }
        }

        public void RenderAll()
        {
            Console.Clear();
            Console.WriteLine("ZONE : {0}", _zone.Name.ToUpper());
            
            // loops through anything in the spriteBuffer that isn't null, and writes the sprite at it's position
            foreach(var sprite in _spriteBuffer)
            {
                if (sprite == null)
                    continue;

                WriteCharacter(sprite.Parent.Position, sprite.Sprite);
            }
        }

        public void EntityMoved(Entity entity, Vector3 newPosition)
        {
            // returns if the moved entity doesn't have a sprite component
            var sprite = entity.GetComponent<SpriteComponent>();
            if (sprite == null)
                return;

            // empties the sprite buffer at the position the sprite moved from
            _spriteBuffer[entity.Position.X, entity.Position.Y, entity.Position.Z] = null;
            
            var lastTopmostEntity = GetTopmostEntity(entity.Position);
            var nextTopmostEntity = GetTopmostEntity(newPosition);
            
            // updating the spriteBuffer
            _spriteBuffer[newPosition.X, newPosition.Y, newPosition.Z] = sprite;

            // if the ZoneRenderer is not active then return before rendering
            if (!IsActive)
                return;

            // checks to see if another entity exists at the vacant square. If there is write it, if not empty it
            if (lastTopmostEntity != null)
                WriteCharacter(entity.Position, lastTopmostEntity.Sprite);
            else
                WriteCharacter(entity.Position, ' ');

            // rendering the entity at it's new position
            if (nextTopmostEntity == null || nextTopmostEntity.Parent.Position.Z < newPosition.Z)
                WriteCharacter(newPosition, sprite.Sprite);
        }

        public void EntityAdded(Entity entity)
        {
            // returns if the entity dosen't have a sprite
            var sprite = entity.GetComponent<SpriteComponent>();
            if (sprite == null)
                return;

            // addes the sprite to the sprite buffer and renders it if it is the top most entity at that position
            _spriteBuffer[entity.Position.X, entity.Position.Y, entity.Position.Z] = sprite;

            // if the ZoneRenderer is not active then return before rendering
            if (!IsActive)
                return;

            // returning if the entity is the topmost entity
            var topmostEntity = GetTopmostEntity(entity.Position);
            if (topmostEntity != null && topmostEntity.Parent.Position.Z > entity.Position.Z)
                return;

            // rendering
            WriteCharacter(entity.Position, sprite.Sprite);
        }

        public void EntityRemoved(Entity entity)
        {
            // returns if the entity dosen't have a sprite
            var sprite = entity.GetComponent<SpriteComponent>();
            if (sprite == null)
                return;

            // empties the sprite buffer at the position the sprite was removed from
            _spriteBuffer[entity.Position.X, entity.Position.Y, entity.Position.Z] = null;

            // if the ZoneRenderer is not active then return before rendering
            if (!IsActive)
                return;

            // returns if there is no entity left at the position of the removed entity
            var topmostEntity = GetTopmostEntity(entity.Position);
            if (topmostEntity == null)
            {
                WriteCharacter(entity.Position, ' ');
                return;
            }

            // renders the current topmost entity at the position of the removed entity
            WriteCharacter(topmostEntity.Parent.Position, topmostEntity.Sprite);
        }

        private SpriteComponent GetTopmostEntity(Vector3 position)
        {
            for (var i = _zone.Size.Z - 1; i >= 0; i--)
            {
                var nextEntity = _spriteBuffer[position.X, position.Y, i];
                if (nextEntity == null)
                    continue;

                return nextEntity;
            }

            return null;
        }

        private void WriteCharacter(Vector3 position, char character)
        {
            SetCursorPosition(position);
            Console.Write(character);
        }

        private void SetCursorPosition(Vector3 position)
        {
            Console.SetCursorPosition(position.X, position.Y + 1);
        }
    }
}
