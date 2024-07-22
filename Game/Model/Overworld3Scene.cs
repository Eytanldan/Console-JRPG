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
    public class Overworld3Scene : IScene
    {
        private readonly Player _playerModel;
        private readonly Entity _playerEntity;
        private readonly SceneManager _sceneManager;

        public Zone SceneZone { get; private set; }
        public Vector3 StartingPosition { get; private set; }

        public Overworld3Scene(Player playerModel, Entity playerEntity, SceneManager sceneManager)
        {
            _playerModel = playerModel;
            _playerEntity = playerEntity;
            _sceneManager = sceneManager;
            StartingPosition = new Vector3(2, 14, 1);
        }

        public void PopulateZone()
        {
            SceneZone = new Zone("Overworld", new Vector3(Console.WindowWidth, Console.WindowHeight, 3));

            SetupImages();

            AddEntranceComponent(new Vector3(0, 8, 0), new Vector3(0, 21, 0),
                new SwitchZoneComponent(_sceneManager.GetSceneByIndex(2), new Vector3(45, 14, 1)));

            SceneZone.AddEntity(_playerEntity);
        }

        private void SetupImages()
        {
            var backgroundImage = new OverworldBackgroundImage3();
            ConstructSpriteImage(new Vector3(0, 0, 0), backgroundImage.ImageStrings);

            SceneZone.Entities.Where(e => e.GetComponent<SpriteComponent>().Sprite != ' ').
                ForEach(e => e.AddComponent(new ConstantEntranceComponent(false)));

            AddEntranceComponent(new Vector3(1, 7, 0), new Vector3(1, 7, 0));
            AddEntranceComponent(new Vector3(10, 10, 0), new Vector3(10, 10, 0));
            AddEntranceComponent(new Vector3(41, 14, 0), new Vector3(43, 14, 0));
            AddEntranceComponent(new Vector3(40, 20, 0), new Vector3(41, 20, 0));
            AddEntranceComponent(new Vector3(35, 24, 0), new Vector3(37, 24, 0));
            AddEntranceComponent(new Vector3(8, 25, 0), new Vector3(10, 25, 0));
            AddEntranceComponent(new Vector3(12, 25, 0), new Vector3(15, 25, 0));

            var caveImage = new CaveImage();
            var cavePos = new Vector3(14, 22, 0);
            ConstructSpriteImage(cavePos, caveImage.ImageStrings);

            AddEntranceComponent(new Vector3(cavePos.X - 1, cavePos.Y, cavePos.Z),
                new Vector3(cavePos.X + 3, cavePos.Y + caveImage.Height, cavePos.Z));
            AddEntranceComponent(new Vector3(cavePos.X + 3, cavePos.Y + 1, cavePos.Z),
                new Vector3(cavePos.X + 5, cavePos.Y + caveImage.Height, cavePos.Z));
            AddEntranceComponent(new Vector3(cavePos.X + 5, cavePos.Y + 2, cavePos.Z),
                new Vector3(cavePos.X + 6, cavePos.Y + caveImage.Height, cavePos.Z));
            AddEntranceComponent(new Vector3(cavePos.X + 6, cavePos.Y + 3, cavePos.Z),
                new Vector3(cavePos.X + 6, cavePos.Y + caveImage.Height, cavePos.Z));

            AddEntranceComponent(new Vector3(cavePos.X + 17, cavePos.Y + 3, cavePos.Z),
                new Vector3(cavePos.X + 17, cavePos.Y + caveImage.Height, cavePos.Z));
            AddEntranceComponent(new Vector3(cavePos.X + 18, cavePos.Y + 2, cavePos.Z),
                new Vector3(cavePos.X + 19, cavePos.Y + caveImage.Height, cavePos.Z));
            AddEntranceComponent(new Vector3(cavePos.X + 19, cavePos.Y + 1, cavePos.Z),
                new Vector3(cavePos.X + 21, cavePos.Y + caveImage.Height, cavePos.Z));
            AddEntranceComponent(new Vector3(cavePos.X + 21, cavePos.Y, cavePos.Z),
                new Vector3(cavePos.X + 25, cavePos.Y + caveImage.Height, cavePos.Z));
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
