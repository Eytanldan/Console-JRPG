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
    public class Overworld1Scene : IScene
    {
        private readonly Player _playerModel;
        private readonly Entity _playerEntity;
        private readonly SceneManager _sceneManager;

        public Zone SceneZone { get; private set; }
        public Vector3 StartingPosition { get; private set; }

        public Overworld1Scene(Player playerModel, Entity playerEntity, SceneManager sceneManager)
        {
            _playerModel = playerModel;
            _playerEntity = playerEntity;
            _sceneManager = sceneManager;
            StartingPosition = new Vector3(20, 12, 1);
        }

        public void PopulateZone()
        {
            SceneZone = new Zone("Overworld", new Vector3(Console.WindowWidth, Console.WindowHeight, 3));

            SetupImages();

            var tilesToNextScene = SceneZone.Entities.Where(p => p.Position.X == 45 && p.Position.Y >= 5 && p.Position.Y <= 17).ToList();
            tilesToNextScene.ForEach(e => e.AddComponent(new SwitchZoneComponent(_sceneManager.GetNextScene(this))));

            var tilesToPreviousScene = SceneZone.Entities.Where(p => p.Position.X >= 19 && p.Position.X <= 21 && p.Position.Y == 10).ToList();
            tilesToPreviousScene.ForEach(e => e.AddComponent(new SwitchZoneComponent(_sceneManager.GetPreviousScene(this), new Vector3(24, 25, 0))));

            SceneZone.Entities.Except(tilesToNextScene).Except(tilesToPreviousScene)
                .ForEach(e => e.AddComponent(new EncounterChanceEntranceComponent(RandomEncounter(), 18)));

            SceneZone.AddEntity(_playerEntity);
        }

        private CombatComponent RandomEncounter()
        {
            return new CombatComponent(() => new Combat(_playerModel, new[] { new BasicMob(), new BasicMob(), new BasicMob() }));
        }

        private void SetupImages()
        {
            var backgroundImage = new OverworldBackgroundImage1();
            ConstructSpriteImage(new Vector3(0, 0, 0), backgroundImage.ImageStrings);

            // left mountian wall
            AddWallMask(new Vector3(9, 10, 0), new Vector3(9, 10, 0));
            AddWallMask(new Vector3(9, 16, 0), new Vector3(9, 18, 0));
            AddWallMask(new Vector3(8, 3, 0), new Vector3(8, 17, 0));

            // bottom mountian wall
            AddWallMask(new Vector3(1, 18, 0), new Vector3(50, 18, 0));

            // shoreline wall
            AddWallMask(new Vector3(1, 2, 0), new Vector3(21, 2, 0));
            AddWallMask(new Vector3(21, 1, 0), new Vector3(39, 1, 0));
            AddWallMask(new Vector3(25, 2, 0), new Vector3(35, 2, 0));
            AddWallMask(new Vector3(27, 3, 0), new Vector3(33, 3, 0));
            AddWallMask(new Vector3(39, 2, 0), new Vector3(50, 2, 0));
            AddWallMask(new Vector3(41, 3, 0), new Vector3(50, 3, 0));
            AddWallMask(new Vector3(43, 4, 0), new Vector3(50, 4, 0));


            var castleImage = new CastleImage();
            var castlePos = new Vector3(14, 5, 0);
            ConstructSpriteImage(castlePos, castleImage.ImageStrings);
            AddWallMask(castlePos, new Vector3(castlePos.X + castleImage.Width, castlePos.Y + castleImage.Height, 0));
            ConstructSpriteImage(new Vector3(19, 10, 0), new[] { "___" });
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
