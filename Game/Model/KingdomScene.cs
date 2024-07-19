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
    public class KingdomScene : IScene
    {
        private readonly Player _playerModel;
        private readonly Entity _playerEntity;
        private readonly SceneManager _sceneManager;

        public Zone SceneZone { get; private set; }
        public Vector3 StartingPosition { get; private set; }

        public KingdomScene(Player playerModel, Entity playerEntity, SceneManager sceneManager)
        {
            _playerModel = playerModel;
            _playerEntity = playerEntity;
            _sceneManager = sceneManager;
            StartingPosition = new Vector3(24, 20, 1);
        }

        public void PopulateZone()
        {
            SceneZone = new Zone("Kingdom", new Vector3(Console.WindowWidth, Console.WindowHeight, 3));

            SetupImages();

            var exitLevel = new Entity();
            exitLevel.AddComponent(new SwitchZoneComponent(_sceneManager.GetNextScene(this)));
            exitLevel.AddComponent(new SpriteComponent { Sprite = ' ' });
            exitLevel.Position = new Vector3(24, 27, 0);

            SceneZone.AddEntity(_playerEntity);
            SceneZone.AddEntity(exitLevel);

        }


        private void SetupImages()
        {
            var throneImage = new ThroneImage();
            var thronePos = new Vector3(16, 4, 0);
            ConstructSpriteImage(thronePos, throneImage.ImageStrings);
            AddWallMask(new Vector3(thronePos.X, thronePos.Y, thronePos.Z),
                new Vector3(thronePos.X + throneImage.Width, thronePos.Y + throneImage.Height, thronePos.Z));

            var buttomWallImage = new ButtomWallImage();
            var wallPos = new Vector3(0, 27, 0);
            ConstructSpriteImage(wallPos, buttomWallImage.ImageStrings);
            AddWallMask(new Vector3(wallPos.X, wallPos.Y, wallPos.Z), new Vector3(buttomWallImage.Width, wallPos.Y, wallPos.Z));

            var exitDoor = new OpenDoorwayImage();
            var exitDoorPos = new Vector3(22, 27, 0);
            ConstructSpriteImage(exitDoorPos, exitDoor.ImageStrings);
            AddWallMask(exitDoorPos, new Vector3(exitDoorPos.X + exitDoor.Width, exitDoorPos.Y, exitDoorPos.Z));

            var piller1 = new PillarImage();
            var piller1pos = new Vector3(35, 1, 0);
            ConstructSpriteImage(piller1pos, piller1.ImageStrings);

            var piller2 = new PillarImage();
            var piller2pos = new Vector3(5, 1, 0);
            ConstructSpriteImage(piller2pos, piller2.ImageStrings);

            var stepsImage = new ThroneRoomStepsImage();
            var stepsPos = new Vector3(0, 14, 0);
            ConstructSpriteImage(stepsPos, stepsImage.ImageStrings);
            AddWallMask(new Vector3(stepsPos.X, stepsPos.Y + stepsImage.Height - 1, stepsPos.Z),
                new Vector3(stepsPos.X + stepsImage.Width, stepsPos.Y + stepsImage.Height - 1, stepsPos.Z));

            var piller3 = new PillarImage();
            var piller3pos = new Vector3(39, 7, 0);
            ConstructSpriteImage(piller3pos, piller3.ImageStrings);

            var piller4 = new PillarImage();
            var piller4pos = new Vector3(1, 7, 0);
            ConstructSpriteImage(piller4pos, piller4.ImageStrings);
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

        private void AddWallMask(Vector3 leftEdge, Vector3 rightEdge)
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

            wallEntities.ForEach(e => e.AddComponent(new ConstantEntranceComponent(false)));
        }
    }
}
