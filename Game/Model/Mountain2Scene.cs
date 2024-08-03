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
    public class Mountain2Scene : IScene
    {
        private readonly Player _playerModel;
        private readonly Entity _playerEntity;
        private readonly SceneManager _sceneManager;

        public Zone SceneZone { get; private set; }
        public Vector3 StartingPosition { get; private set; }

        public Mountain2Scene(Player playerModel, Entity playerEntity, SceneManager sceneManager)
        {
            _playerModel = playerModel;
            _playerEntity = playerEntity;
            _sceneManager = sceneManager;
            StartingPosition = new Vector3(16, 25, 1);
        }

        public void PopulateZone()
        {
            SceneZone = new Zone("Algebra Mountain", new Vector3(Console.WindowWidth, Console.WindowHeight, 3));

            SetupImages();

            SceneZone.Entities.Where(p => p.Position.X == 0 && p.Position.Y == 21)
                .ForEach(e => e.AddComponent(new SwitchZoneComponent(_sceneManager.GetPreviousScene(this), new Vector3(49, 3, 1))));

            SceneZone.AddEntity(_playerEntity);
        }

        private void SetupImages()
        {
            var backgroundImage = new LairEntranceBackgroundImage();
            ConstructSpriteImage(new Vector3(0, 0, 0), backgroundImage.ImageStrings);

            AddEntranceComponent(new Vector3(0, 3, 0), new Vector3(50, 3, 0));
            AddEntranceComponent(new Vector3(0, 4, 0), new Vector3(6, 4, 0));
            AddEntranceComponent(new Vector3(3, 5, 0), new Vector3(5, 5, 0));
            AddEntranceComponent(new Vector3(48, 5, 0), new Vector3(50, 5, 0));
            AddEntranceComponent(new Vector3(3, 6, 0), new Vector3(6, 6, 0));
            AddEntranceComponent(new Vector3(47, 6, 0), new Vector3(50, 6, 0));
            AddEntranceComponent(new Vector3(5, 7, 0), new Vector3(15, 7, 0));
            AddEntranceComponent(new Vector3(47, 7, 0), new Vector3(50, 7, 0));
            AddEntranceComponent(new Vector3(14, 8, 0), new Vector3(19, 8, 0));
            AddEntranceComponent(new Vector3(22, 8, 0), new Vector3(26, 8, 0));
            AddEntranceComponent(new Vector3(29, 8, 0), new Vector3(33, 8, 0));
            AddEntranceComponent(new Vector3(46, 8, 0), new Vector3(50, 8, 0));
            AddEntranceComponent(new Vector3(9, 9, 0), new Vector3(26, 9, 0));
            AddEntranceComponent(new Vector3(29, 9, 0), new Vector3(36, 9, 0));
            AddEntranceComponent(new Vector3(44, 9, 0), new Vector3(50, 9, 0));
            AddEntranceComponent(new Vector3(10, 10, 0), new Vector3(11, 10, 0));
            AddEntranceComponent(new Vector3(15, 10, 0), new Vector3(26, 10, 0));
            AddEntranceComponent(new Vector3(29, 10, 0), new Vector3(39, 10, 0));
            AddEntranceComponent(new Vector3(41, 10, 0), new Vector3(50, 10, 0));
            AddEntranceComponent(new Vector3(10, 11, 0), new Vector3(11, 11, 0));
            AddEntranceComponent(new Vector3(35, 11, 0), new Vector3(44, 11, 0));
            AddEntranceComponent(new Vector3(46, 11, 0), new Vector3(50, 11, 0));
            AddEntranceComponent(new Vector3(10, 12, 0), new Vector3(11, 12, 0));
            AddEntranceComponent(new Vector3(49, 12, 0), new Vector3(49, 21, 0));
            AddEntranceComponent(new Vector3(11, 13, 0), new Vector3(12, 13, 0));
            AddEntranceComponent(new Vector3(11, 14, 0), new Vector3(13, 14, 0));
            AddEntranceComponent(new Vector3(19, 14, 0), new Vector3(24, 14, 0));
            AddEntranceComponent(new Vector3(11, 15, 0), new Vector3(32, 15, 0));
            AddEntranceComponent(new Vector3(36, 15, 0), new Vector3(39, 15, 0));
            AddEntranceComponent(new Vector3(42, 15, 0), new Vector3(45, 15, 0));
            AddEntranceComponent(new Vector3(48, 15, 0), new Vector3(50, 15, 0));
            AddEntranceComponent(new Vector3(31, 16, 0), new Vector3(33, 16, 0));
            AddEntranceComponent(new Vector3(35, 16, 0), new Vector3(39, 16, 0));
            AddEntranceComponent(new Vector3(42, 16, 0), new Vector3(49, 16, 0));
            AddEntranceComponent(new Vector3(30, 17, 0), new Vector3(39, 17, 0));
            AddEntranceComponent(new Vector3(42, 17, 0), new Vector3(50, 17, 0));
            AddEntranceComponent(new Vector3(29, 18, 0), new Vector3(30, 18, 0));
            AddEntranceComponent(new Vector3(45, 18, 0), new Vector3(50, 18, 0));
            AddEntranceComponent(new Vector3(26, 19, 0), new Vector3(29, 19, 0));
            AddEntranceComponent(new Vector3(0, 20, 0), new Vector3(28, 20, 0));
            AddEntranceComponent(new Vector3(48, 20, 0), new Vector3(49, 20, 0));
            AddEntranceComponent(new Vector3(45, 21, 0), new Vector3(49, 21, 0));
            AddEntranceComponent(new Vector3(0, 22, 0), new Vector3(29, 22, 0));
            AddEntranceComponent(new Vector3(44, 22, 0), new Vector3(46, 24, 0));
            AddEntranceComponent(new Vector3(28, 23, 0), new Vector3(31, 23, 0));
            AddEntranceComponent(new Vector3(30, 24, 0), new Vector3(32, 24, 0));
            AddEntranceComponent(new Vector3(45, 24, 0), new Vector3(47, 24, 0));
            AddEntranceComponent(new Vector3(31, 25, 0), new Vector3(34, 25, 0));
            AddEntranceComponent(new Vector3(43, 25, 0), new Vector3(50, 25, 0));
            AddEntranceComponent(new Vector3(34, 26, 0), new Vector3(37, 26, 0));
            AddEntranceComponent(new Vector3(40, 26, 0), new Vector3(50, 26, 0));
            AddEntranceComponent(new Vector3(36, 27, 0), new Vector3(41, 27, 0));

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
