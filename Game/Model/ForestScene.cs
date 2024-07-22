using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game.Abstract;
using Game.Model.Components;
using Game.Externsions;
using Game.Model.Images;

namespace Game.Model
{
    public class ForestScene : IScene
    {
        private readonly Player _playerModel;
        private readonly Entity _playerEntity;
        private readonly SceneManager _sceneManager;

        public Zone SceneZone { get; private set; }
        public Vector3 StartingPosition { get; private set; }

        public ForestScene(Player playerModel, Entity playerEntity, SceneManager sceneManager)
        {
            _playerModel = playerModel;
            _playerEntity = playerEntity;
            _sceneManager = sceneManager;
            StartingPosition = new Vector3(2, 15, 1);
        }
        
        public void PopulateZone()
        {
            SceneZone = new Zone("Forest", new Vector3(Console.WindowWidth, Console.WindowHeight, 4));

            SetupBackgroundImages();

            AddEntranceComponent(new Vector3(0, 10, 0), new Vector3(0, 18, 0),
                new SwitchZoneComponent(_sceneManager.GetPreviousScene(this), new Vector3(12, 12, 1)));

            AddEntranceComponent(new Vector3(49, 4, 0), new Vector3(49, 8, 0),
                new SwitchZoneComponent(_sceneManager.GetPreviousScene(this), new Vector3(31, 12, 1)));

            SceneZone.AddEntity(_playerEntity);
        }

        private void SetupBackgroundImages()
        {
            var backgroundImage = new ForestBackgroundImage();
            ConstructSpriteImage(new Vector3(0, 0, 0), backgroundImage.ImageStrings);

            AddEntranceComponent(new Vector3(0, 17, 0), new Vector3(7, 17, 0),
                new ElevationBasedEntranceComponent(false, true));
            AddEntranceComponent(new Vector3(12, 17, 0), new Vector3(22, 17, 0),
                new ElevationBasedEntranceComponent(false, true));

            AddEntranceComponent(new Vector3(0, 8, 0), new Vector3(7, 10, 0));
            AddEntranceComponent(new Vector3(12, 8, 0), new Vector3(50, 10, 0));
            AddEntranceComponent(new Vector3(13, 10, 0), new Vector3(50, 10, 0));
            AddEntranceComponent(new Vector3(14, 11, 0), new Vector3(50, 11, 0));
            AddEntranceComponent(new Vector3(19, 12, 0), new Vector3(50, 12, 0));
            AddEntranceComponent(new Vector3(27, 13, 0), new Vector3(31, 13, 0));
            AddEntranceComponent(new Vector3(43, 13, 0), new Vector3(50, 13, 0));
            AddEntranceComponent(new Vector3(28, 14, 0), new Vector3(30, 14, 0));
            AddEntranceComponent(new Vector3(45, 14, 0), new Vector3(50, 14, 0));
            AddEntranceComponent(new Vector3(46, 15, 0), new Vector3(50, 25, 0));
            AddEntranceComponent(new Vector3(22, 24, 0), new Vector3(50, 24, 0));
            AddEntranceComponent(new Vector3(45, 21, 0), new Vector3(45, 23, 0));
            AddEntranceComponent(new Vector3(0, 23, 0), new Vector3(25, 23, 0));
            AddEntranceComponent(new Vector3(22, 18, 0), new Vector3(25, 18, 0));
            AddEntranceComponent(new Vector3(25, 19, 0), new Vector3(31, 19, 0));
            

            var secondFloorImage = new ForestSecondFloorImage();
            ConstructSpriteImage(new Vector3(0, 0, 2), secondFloorImage.ImageStrings);

            AddEntranceComponent(new Vector3(0, 3, 0), new Vector3(50, 3, 0));
            AddEntranceComponent(new Vector3(5, 4, 0), new Vector3(7, 4, 0));
            AddEntranceComponent(new Vector3(18, 4, 0), new Vector3(20, 4, 0));
            AddEntranceComponent(new Vector3(32, 4, 0), new Vector3(34, 4, 0));

            var rampImage = new ForestRampImage();
            var rampPos = new Vector3(0, 18, 2);
            ConstructSpriteImage(rampPos, rampImage.ImageStrings);
            AddEntranceComponent(rampPos, new Vector3(rampPos.X + rampImage.Width, rampPos.Y, rampPos.Z),
                new ElevationBasedEntranceComponent(false, true));
            
            AddEntranceComponent(new Vector3(0, 18, 0), new Vector3(0, 24, 0));
            AddEntranceComponent(new Vector3(1, 18, 0), new Vector3(1, 24, 0));
            AddEntranceComponent(new Vector3(2, 19, 0), new Vector3(2, 24, 0));
            AddEntranceComponent(new Vector3(3, 21, 0), new Vector3(3, 24, 0));
            AddEntranceComponent(new Vector3(4, 21, 0), new Vector3(4, 24, 0));
            AddEntranceComponent(new Vector3(5, 22, 0), new Vector3(5, 24, 0));

            AddEntranceComponent(new Vector3(22, 18, 0), new Vector3(22, 23, 0), new HeightAdjustmentComponent(3));
            AddEntranceComponent(new Vector3(23, 19, 0), new Vector3(23, 23, 0), new HeightAdjustmentComponent(1));

            var bridgeImage = new ForestBridgeImage();
            var bridgePos = new Vector3(7, 8, 2);
            ConstructSpriteImage(bridgePos, bridgeImage.ImageStrings);

            AddEntranceComponent(new Vector3(8, 9, 0), new Vector3(11, 9, 0), new ElevationBasedEntranceComponent(false, true));

            AddEntranceComponent(new Vector3(7, 8, 0), new Vector3(7, 10, 0));
            AddEntranceComponent(new Vector3(11, 8, 0), new Vector3(11, 10, 0));

            AddEntranceComponent(new Vector3(7, 9, 0), new Vector3(7, 18, 0), new ElevationBasedEntranceComponent(true, false));
            AddEntranceComponent(new Vector3(11, 9, 0), new Vector3(11, 18, 0), new ElevationBasedEntranceComponent(true, false));

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
