using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game.Abstract;
using Game.Externsions;
using Game.Model.Components;
using Game.Model.Images;

namespace Game.Model
{
    public class CaveScene : IScene
    {
        private readonly Player _playerModel;
        private readonly Entity _playerEntity;
        private readonly SceneManager _sceneManager;

        public Zone SceneZone { get; private set; }
        public Vector3 StartingPosition { get; private set; }

        public CaveScene(Player playerModel, Entity playerEntity, SceneManager sceneManager)
        {
            _playerModel = playerModel;
            _playerEntity = playerEntity;
            _sceneManager = sceneManager;
            StartingPosition = new Vector3(10, 25, 1);
        }

        public void PopulateZone()
        {
            SceneZone = new Zone("Probability Cave", new Vector3(Console.WindowWidth, Console.WindowHeight, 3));

            SetupImages();

            SceneZone.Entities.Where(p => p.Position.X >= 12 && p.Position.X <= 14 && p.Position.Y == 27)
                .ForEach(e => e.AddComponent(new SwitchZoneComponent(_sceneManager.GetPreviousScene(this), new Vector3(25, 24, 1))));

            SceneZone.Entities.Where(p => p.Position.X == 37 && p.Position.Y == 4)
                .ForEach(e => e.AddComponent(new SwitchZoneComponent(_sceneManager.GetNextScene(this))));

            SceneZone.AddEntity(_playerEntity);
        }

        private void SetupImages()
        {
            var backgroundImage = new CaveBackgroundImage();
            ConstructSpriteImage(new Vector3(0, 0, 0), backgroundImage.ImageStrings);

            AddEntranceComponent(new Vector3(28, 3, 0), new Vector3(50, 3, 0));
            AddEntranceComponent(new Vector3(0, 8, 0), new Vector3(19, 8, 0));
            AddEntranceComponent(new Vector3(2, 9, 0), new Vector3(2, 9, 0));
            AddEntranceComponent(new Vector3(16, 9, 0), new Vector3(16, 9, 0));

            AddEntranceComponent(new Vector3(27, 3, 0), new Vector3(50, 3, 0));
            AddEntranceComponent(new Vector3(27, 4, 0), new Vector3(29, 10, 0));
            AddEntranceComponent(new Vector3(48, 4, 0), new Vector3(50, 10, 0));

            SceneZone.Entities.Where(p => 
            p.Position.X >= 0 && p.Position.X <= 50 &&
            p.Position.Y >= 10 && p.Position.Y <= 22)
                .Where(e => e.GetComponent<SpriteComponent>().Sprite != ' ' &&
                e.GetComponent<SpriteComponent>().Sprite != '_')
                .ForEach(e => e.AddComponent(new ConstantEntranceComponent(false)));

            AddEntranceComponent(new Vector3(22, 18, 0), new Vector3(22, 18, 0));
            AddEntranceComponent(new Vector3(26, 20, 0), new Vector3(26, 20, 0));
            AddEntranceComponent(new Vector3(31, 22, 0), new Vector3(38, 22, 0));

            AddEntranceComponent(new Vector3(0, 23, 0), new Vector3(7, 25, 0));
            AddEntranceComponent(new Vector3(1, 25, 0), new Vector3(1, 27, 0));
            AddEntranceComponent(new Vector3(0, 27, 0), new Vector3(12, 27, 0));

            AddEntranceComponent(new Vector3(11, 23, 0), new Vector3(24, 23, 0));
            AddEntranceComponent(new Vector3(16, 24, 0), new Vector3(24, 24, 0));
            AddEntranceComponent(new Vector3(16, 25, 0), new Vector3(24, 27, 0));
            AddEntranceComponent(new Vector3(15, 27, 0), new Vector3(17, 27, 0));

            SceneZone.Entities.Where(p =>
            p.Position.X >= 24 && p.Position.X <= 50 &&
            p.Position.Y >= 24 && p.Position.Y <= 28)
                .Where(e => e.GetComponent<SpriteComponent>().Sprite != ' ' &&
                e.GetComponent<SpriteComponent>().Sprite != '_')
                .ForEach(e => e.AddComponent(new ConstantEntranceComponent(false)));

            AddEntranceComponent(new Vector3(47, 23, 0), new Vector3(50, 23, 0));
        }

        private void ConstructSpriteImage(Vector3 topRightPosition, IEnumerable<string> imageStrings)
        {
            int y = 0;

            foreach (var line in imageStrings)
            {
                int x = 0;

                foreach (char character in line)
                {
                    var imageChar = new Entity();
                    imageChar.AddComponent(new SpriteComponent { Sprite = character });
                    imageChar.Position = new Vector3(topRightPosition.X + x, topRightPosition.Y + y, topRightPosition.Z);
                    SceneZone.AddEntity(imageChar);

                    x++;
                }
                y++;
            }
        }

        private void AddEntranceComponent(Vector3 leftEdge, Vector3 rightEdge, IEntityEntranceComponent component = null)
        {
            int XStart = leftEdge.X;
            int XEnd = rightEdge.X;
            int YStart = leftEdge.Y;
            int YEnd = rightEdge.Y;

            if (XStart > XEnd || YStart > YEnd)
                throw new ArgumentException("The X and Y values of the end vector cannot be smaller then the start vector");

            IEnumerable<Entity> wallEntities;

            if (XStart == XEnd && YStart == YEnd)
            {
                wallEntities = SceneZone.Entities.Where(p => p.Position.X == XStart && p.Position.Y == YStart);
            }
            else if (XStart == XEnd)
            {
                wallEntities = SceneZone.Entities.Where(p =>
                p.Position.X == XStart &&
                p.Position.Y >= YStart &&
                p.Position.Y < YEnd);
            }
            else if (YStart == YEnd)
            {
                wallEntities = SceneZone.Entities.Where(p =>
                p.Position.X >= XStart &&
                p.Position.X < XEnd &&
                p.Position.Y == YStart);
            }
            else
            {
                wallEntities = SceneZone.Entities.Where(p =>
                p.Position.X >= XStart &&
                p.Position.X < XEnd &&
                p.Position.Y >= YStart &&
                p.Position.Y < YEnd);
            }

            wallEntities.ForEach(e => e.AddComponent(component ?? new ConstantEntranceComponent(false)));
        }
    }
}
