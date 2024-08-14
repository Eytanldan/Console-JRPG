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
    public class LairScene : IScene
    {
        private readonly Player _playerModel;
        private readonly Entity _playerEntity;
        private readonly SceneManager _sceneManager;

        public Zone SceneZone { get; private set; }
        public Vector3 StartingPosition { get; private set; }

        public LairScene(Player playerModel, Entity playerEntity, SceneManager sceneManager)
        {
            _playerModel = playerModel;
            _playerEntity = playerEntity;
            _sceneManager = sceneManager;
            StartingPosition = new Vector3(24, 27, 1);
        }

        public void PopulateZone()
        {
            SceneZone = new Zone("The Lair", new Vector3(Console.WindowWidth, Console.WindowHeight, 3));

            SetupImages();

            SceneZone.Entities.Where(p => p.Position.X >= 23 && p.Position.X <= 26 && p.Position.Y == 27)
                .ForEach(e => e.AddComponent(new SwitchZoneComponent(_sceneManager.GetPreviousScene(this), new Vector3(27, 4, 1))));

            SceneZone.AddEntity(_playerEntity);
        }

        private void SetupImages()
        {
            var backgroundImage = new LairBackgroundImage();
            ConstructSpriteImage(new Vector3(0, 0, 0), backgroundImage.ImageStrings);

            AddEntranceComponent(new Vector3(18, 10, 0), new Vector3(31, 10, 0));
            AddEntranceComponent(new Vector3(18, 10, 0), new Vector3(18, 16, 0));
            AddEntranceComponent(new Vector3(30, 10, 0), new Vector3(30, 16, 0));

            AddEntranceComponent(new Vector3(16, 16, 0), new Vector3(18, 16, 0));
            AddEntranceComponent(new Vector3(15, 17, 0), new Vector3(17, 17, 0));
            AddEntranceComponent(new Vector3(14, 18, 0), new Vector3(16, 18, 0));
            AddEntranceComponent(new Vector3(13, 19, 0), new Vector3(15, 19, 0));
            AddEntranceComponent(new Vector3(12, 20, 0), new Vector3(14, 20, 0));
            AddEntranceComponent(new Vector3(11, 21, 0), new Vector3(13, 21, 0));

            AddEntranceComponent(new Vector3(31, 16, 0), new Vector3(32, 16, 0));
            AddEntranceComponent(new Vector3(32, 17, 0), new Vector3(33, 17, 0));
            AddEntranceComponent(new Vector3(33, 18, 0), new Vector3(34, 18, 0));
            AddEntranceComponent(new Vector3(34, 19, 0), new Vector3(35, 19, 0));
            AddEntranceComponent(new Vector3(35, 20, 0), new Vector3(36, 20, 0));
            AddEntranceComponent(new Vector3(36, 21, 0), new Vector3(37, 21, 0));

            AddEntranceComponent(new Vector3(0, 22, 0), new Vector3(12, 22, 0));
            AddEntranceComponent(new Vector3(1, 23, 0), new Vector3(1, 26, 0));
            AddEntranceComponent(new Vector3(0, 26, 0), new Vector3(1, 26, 0));

            AddEntranceComponent(new Vector3(37, 22, 0), new Vector3(50, 22, 0));
            AddEntranceComponent(new Vector3(48, 23, 0), new Vector3(48, 26, 0));
            AddEntranceComponent(new Vector3(49, 26, 0), new Vector3(50, 26, 0));

            AddEntranceComponent(new Vector3(0, 27, 0), new Vector3(23, 27, 0));
            AddEntranceComponent(new Vector3(26, 27, 0), new Vector3(50, 27, 0));
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
