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
    public class Mountain1Scene : IScene
    {
        private readonly Player _playerModel;
        private readonly Entity _playerEntity;
        private readonly SceneManager _sceneManager;

        public Zone SceneZone { get; private set; }
        public Vector3 StartingPosition { get; private set; }

        public Mountain1Scene(Player playerModel, Entity playerEntity, SceneManager sceneManager)
        {
            _playerModel = playerModel;
            _playerEntity = playerEntity;
            _sceneManager = sceneManager;
            StartingPosition = new Vector3(17, 24, 1);
        }

        public void PopulateZone()
        {
            SceneZone = new Zone("Algebra Mountain", new Vector3(Console.WindowWidth, Console.WindowHeight, 3));

            SetupImages();

            SceneZone.Entities.Where(p => p.Position.X == 17 && p.Position.Y == 24)
                .ForEach(e => e.AddComponent(new SwitchZoneComponent(_sceneManager.GetPreviousScene(this), new Vector3(37, 4, 1))));

            SceneZone.Entities.Where(p => p.Position.X == 49 && p.Position.Y == 3)
                .ForEach(e => e.AddComponent(new SwitchZoneComponent(_sceneManager.GetNextScene(this), new Vector3(0, 21, 1))));

            SceneZone.AddEntity(_playerEntity);
        }

        private void SetupImages()
        {
            var backgroundImage = new MountainBackgroundImage();
            ConstructSpriteImage(new Vector3(0, 0, 0), backgroundImage.ImageStrings);

            AddEntranceComponent(new Vector3(10, 0, 0), new Vector3(50, 0, 0));
            AddEntranceComponent(new Vector3(9, 1, 0), new Vector3(12, 1, 0));
            AddEntranceComponent(new Vector3(18, 1, 0), new Vector3(32, 1, 0));
            AddEntranceComponent(new Vector3(40, 1, 0), new Vector3(50, 1, 0));
            AddEntranceComponent(new Vector3(5, 2, 0), new Vector3(9, 2, 0));
            AddEntranceComponent(new Vector3(20, 2, 0), new Vector3(28, 2, 0));
            AddEntranceComponent(new Vector3(44, 2, 0), new Vector3(50, 2, 0));
            AddEntranceComponent(new Vector3(5, 3, 0), new Vector3(5, 3, 0));
            AddEntranceComponent(new Vector3(5, 4, 0), new Vector3(7, 4, 0));
            AddEntranceComponent(new Vector3(45, 4, 0), new Vector3(50, 4, 0));
            AddEntranceComponent(new Vector3(5, 5, 0), new Vector3(8, 5, 0));
            AddEntranceComponent(new Vector3(14, 5, 0), new Vector3(19, 5, 0));
            AddEntranceComponent(new Vector3(22, 5, 0), new Vector3(26, 5, 0));
            AddEntranceComponent(new Vector3(43, 5, 0), new Vector3(50, 5, 0));
            AddEntranceComponent(new Vector3(4, 6, 0), new Vector3(19, 6, 0));
            AddEntranceComponent(new Vector3(22, 6, 0), new Vector3(28, 6, 0));
            AddEntranceComponent(new Vector3(33, 6, 0), new Vector3(36, 6, 0));
            AddEntranceComponent(new Vector3(43, 6, 0), new Vector3(50, 6, 0));
            AddEntranceComponent(new Vector3(1, 7, 0), new Vector3(4, 7, 0));
            AddEntranceComponent(new Vector3(6, 7, 0), new Vector3(16, 7, 0));
            AddEntranceComponent(new Vector3(17, 7, 0), new Vector3(19, 7, 0));
            AddEntranceComponent(new Vector3(22, 7, 0), new Vector3(24, 7, 0));
            AddEntranceComponent(new Vector3(25, 7, 0), new Vector3(39, 7, 0));
            AddEntranceComponent(new Vector3(43, 7, 0), new Vector3(50, 7, 0)); 
            AddEntranceComponent(new Vector3(0, 8, 0), new Vector3(2, 8, 0));
            AddEntranceComponent(new Vector3(8, 8, 0), new Vector3(13, 8, 0));
            AddEntranceComponent(new Vector3(36, 8, 0), new Vector3(41, 8, 0));
            AddEntranceComponent(new Vector3(46, 8, 0), new Vector3(50, 8, 0));
            AddEntranceComponent(new Vector3(0, 9, 0), new Vector3(2, 9, 0));
            AddEntranceComponent(new Vector3(38, 9, 0), new Vector3(43, 9, 0));
            AddEntranceComponent(new Vector3(46, 9, 0), new Vector3(50, 9, 0));
            AddEntranceComponent(new Vector3(0, 10, 0), new Vector3(2, 10, 0));
            AddEntranceComponent(new Vector3(16, 10, 0), new Vector3(21, 10, 0));
            AddEntranceComponent(new Vector3(40, 10, 0), new Vector3(50, 10, 0));
            AddEntranceComponent(new Vector3(0, 11, 0), new Vector3(4, 11, 0));
            AddEntranceComponent(new Vector3(14, 11, 0), new Vector3(23, 11, 0));
            AddEntranceComponent(new Vector3(40, 11, 0), new Vector3(50, 11, 0));
            AddEntranceComponent(new Vector3(0, 12, 0), new Vector3(7, 12, 0));
            AddEntranceComponent(new Vector3(12, 12, 0), new Vector3(19, 12, 0));
            AddEntranceComponent(new Vector3(22, 12, 0), new Vector3(24, 12, 0));
            AddEntranceComponent(new Vector3(27, 12, 0), new Vector3(30, 12, 0));
            AddEntranceComponent(new Vector3(33, 12, 0), new Vector3(36, 12, 0));
            AddEntranceComponent(new Vector3(39, 12, 0), new Vector3(50, 12, 0));
            AddEntranceComponent(new Vector3(0, 13, 0), new Vector3(16, 13, 0));
            AddEntranceComponent(new Vector3(22, 13, 0), new Vector3(30, 13, 0));
            AddEntranceComponent(new Vector3(33, 13, 0), new Vector3(41, 13, 0));
            AddEntranceComponent(new Vector3(44, 13, 0), new Vector3(50, 13, 0));
            AddEntranceComponent(new Vector3(0, 14, 0), new Vector3(11, 14, 0));
            AddEntranceComponent(new Vector3(23, 14, 0), new Vector3(30, 14, 0));
            AddEntranceComponent(new Vector3(33, 14, 0), new Vector3(41, 14, 0));
            AddEntranceComponent(new Vector3(45, 14, 0), new Vector3(50, 14, 0));
            AddEntranceComponent(new Vector3(0, 15, 0), new Vector3(10, 15, 0));
            AddEntranceComponent(new Vector3(24, 15, 0), new Vector3(27, 15, 0));
            AddEntranceComponent(new Vector3(36, 15, 0), new Vector3(40, 15, 0));
            AddEntranceComponent(new Vector3(47, 15, 0), new Vector3(50, 15, 0));
            AddEntranceComponent(new Vector3(0, 16, 0), new Vector3(8, 16, 0));
            AddEntranceComponent(new Vector3(47, 16, 0), new Vector3(50, 16, 0));
            AddEntranceComponent(new Vector3(0, 17, 0), new Vector3(8, 17, 0));
            AddEntranceComponent(new Vector3(47, 17, 0), new Vector3(50, 17, 0));
            AddEntranceComponent(new Vector3(0, 18, 0), new Vector3(8, 18, 0));
            AddEntranceComponent(new Vector3(46, 18, 0), new Vector3(50, 18, 0));
            AddEntranceComponent(new Vector3(0, 19, 0), new Vector3(5, 19, 0));
            AddEntranceComponent(new Vector3(44, 19, 0), new Vector3(50, 19, 0));
            AddEntranceComponent(new Vector3(0, 20, 0), new Vector3(3, 20, 0));
            AddEntranceComponent(new Vector3(39, 20, 0), new Vector3(50, 20, 0));
            AddEntranceComponent(new Vector3(0, 21, 0), new Vector3(0, 21, 0));
            AddEntranceComponent(new Vector3(12, 21, 0), new Vector3(23, 21, 0));
            AddEntranceComponent(new Vector3(28, 21, 0), new Vector3(30, 21, 0));
            AddEntranceComponent(new Vector3(39, 21, 0), new Vector3(50, 21, 0));
            AddEntranceComponent(new Vector3(0, 22, 0), new Vector3(3, 22, 0));
            AddEntranceComponent(new Vector3(9, 22, 0), new Vector3(30, 22, 0));
            AddEntranceComponent(new Vector3(39, 22, 0), new Vector3(50, 22, 0));
            AddEntranceComponent(new Vector3(0, 23, 0), new Vector3(4, 23, 0));
            AddEntranceComponent(new Vector3(9, 23, 0), new Vector3(30, 23, 0));
            AddEntranceComponent(new Vector3(39, 23, 0), new Vector3(50, 23, 0));
            AddEntranceComponent(new Vector3(0, 24, 0), new Vector3(4, 24, 0));
            AddEntranceComponent(new Vector3(9, 24, 0), new Vector3(13, 24, 0));
            AddEntranceComponent(new Vector3(24, 24, 0), new Vector3(30, 24, 0));
            AddEntranceComponent(new Vector3(39, 24, 0), new Vector3(41, 24, 0));
            AddEntranceComponent(new Vector3(44, 24, 0), new Vector3(50, 24, 0));
            AddEntranceComponent(new Vector3(0, 25, 0), new Vector3(4, 25, 0));
            AddEntranceComponent(new Vector3(44, 25, 0), new Vector3(50, 25, 0));
            AddEntranceComponent(new Vector3(0, 26, 0), new Vector3(5, 26, 0));
            AddEntranceComponent(new Vector3(43, 26, 0), new Vector3(50, 26, 0));
            AddEntranceComponent(new Vector3(0, 27, 0), new Vector3(50, 27, 0));

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
