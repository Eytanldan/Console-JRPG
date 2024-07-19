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
    public class Overworld2Scene : IScene
    {
        private readonly Player _playerModel;
        private readonly Entity _playerEntity;
        private readonly SceneManager _sceneManager;

        public Zone SceneZone { get; private set; }
        public Vector3 StartingPosition { get; private set; }

        public Overworld2Scene(Player playerModel, Entity playerEntity, SceneManager sceneManager)
        {
            _playerModel = playerModel;
            _playerEntity = playerEntity;
            _sceneManager = sceneManager;
            StartingPosition = new Vector3(2, 12, 1);
        }

        public void PopulateZone()
        {
            SceneZone = new Zone("Overworld", new Vector3(Console.WindowWidth, Console.WindowHeight, 3));

            SetupBackgroundImage();

            SetupForestEntity();

            SceneZone.Entities.Where(p => p.Position.X == 0 && p.Position.Y >= 5 && p.Position.Y <= 19)
                .ForEach(e => e.AddComponent(new SwitchZoneComponent(_sceneManager.GetPreviousScene(this), new Vector3(42, 12, 1))));

            SceneZone.AddEntity(_playerEntity);
        }

        private void SetupForestEntity()
        {
            var forestImage = new ForestImage();
            var forestPos = new Vector3(15, 9, 0);
            ConstructSpriteImage(forestPos, forestImage.ImageStrings);
            AddWallMask(new Vector3(forestPos.X + 1, forestPos.Y, 0),
                new Vector3(forestPos.X + forestImage.Width - 1, forestPos.Y + forestImage.Height, 0));
            
            SceneZone.Entities.Where(p => 
            p.Position.X == forestPos.X &&
            p.Position.Y >= forestPos.Y &&
            p.Position.Y <= forestPos.Y + forestImage.Height)
                .ForEach(e => e.AddComponent(new SwitchZoneComponent(_sceneManager.GetNextScene(this))));

            SceneZone.Entities.Where(p =>
            p.Position.X == forestPos.X + forestImage.Width &&
            p.Position.Y >= forestPos.Y &&
            p.Position.Y <= forestPos.Y + forestImage.Height)
                .ForEach(e => e.AddComponent(new SwitchZoneComponent(_sceneManager.GetNextScene(this))));
        }

        private void SetupBackgroundImage()
        {
            var backgroundImage = new OverworldBackgroundImage2();
            ConstructSpriteImage(new Vector3(0, 0, 0), backgroundImage.ImageStrings);

            // bottom mountian wall
            AddWallMask(new Vector3(0, 19, 0), new Vector3(10, 19, 0));
            AddWallMask(new Vector3(10, 18, 0), new Vector3(41, 18, 0));
            AddWallMask(new Vector3(30, 16, 0), new Vector3(33, 16, 0));
            AddWallMask(new Vector3(31, 17, 0), new Vector3(34, 17, 0));
            AddWallMask(new Vector3(41, 19, 0), new Vector3(50, 19, 0));

            // shoreline wall
            AddWallMask(new Vector3(0, 5, 0), new Vector3(2, 5, 0));
            AddWallMask(new Vector3(2, 6, 0), new Vector3(4, 6, 0));
            AddWallMask(new Vector3(4, 7, 0), new Vector3(8, 7, 0));
            AddWallMask(new Vector3(8, 8, 0), new Vector3(10, 8, 0));
            AddWallMask(new Vector3(10, 9, 0), new Vector3(16, 9, 0));
            AddWallMask(new Vector3(30, 8, 0), new Vector3(46, 8, 0));
            AddWallMask(new Vector3(32, 9, 0), new Vector3(44, 9, 0));
            AddWallMask(new Vector3(33, 10, 0), new Vector3(42, 10, 0));
            AddWallMask(new Vector3(46, 7, 0), new Vector3(50, 7, 0));
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
