using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SpaceGame.Tiles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceGame.Managers
{
    public class ShipTileManager
    {
        protected List<ShipFloor> floorTiles;
        protected List<CollidableWall> collidableWalls;
        protected List<NonCollidableWall> nonCollidableWalls;
        protected Texture2D texture;

        public ShipTileManager(Texture2D texture)
        {
            this.texture = texture;
            floorTiles = new List<ShipFloor>();
            collidableWalls = new List<CollidableWall>();
            nonCollidableWalls = new List<NonCollidableWall>();
            BuildShip();
        }

        public Vector2 GetShipSize()
        {
            Vector2 maxPosition = floorTiles[0].position;

            foreach (var floorTile in floorTiles)
            {
                if (floorTile.position.X > maxPosition.X) maxPosition.X = floorTile.position.X;
                if (floorTile.position.Y > maxPosition.Y) maxPosition.Y = floorTile.position.Y;
            }
            foreach (var collidableWall in collidableWalls)
            {
                if (collidableWall.position.X > maxPosition.X) maxPosition.X = collidableWall.position.X;
                if (collidableWall.position.Y > maxPosition.Y) maxPosition.Y = collidableWall.position.Y;
            }
            foreach (var nonCollidableWall in nonCollidableWalls)
            {
                if (nonCollidableWall.position.X > maxPosition.X) maxPosition.X = nonCollidableWall.position.X;
                if (nonCollidableWall.position.Y > maxPosition.Y) maxPosition.Y = nonCollidableWall.position.Y;
            }
            return maxPosition;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (var floorTile in floorTiles) floorTile.Draw(spriteBatch);
            foreach (var collidableWall in collidableWalls) collidableWall.Draw(spriteBatch);
            foreach (var nonCollidableWall in collidableWalls) nonCollidableWall.Draw(spriteBatch);
        }

        protected void BuildShip()
        {
            // Cockpit
            AddFloorTileRow(10, 18, 2);
            AddFloorTileRow(9, 19, 3);
            AddFloorTileRow(8, 20, 4);
            AddFloorTileArea(13, 15, 8, 33);
            AddHorizontalCrossSection(10, 18, 0);
            AddHorizontalWall(10, 18, 1);
            AddVerticalCrossSection(4, 7, 6);
            AddVerticalCrossSection(4, 7, 22);
            // Room 1
            AddFloorTileRow(2, 11, 10);
            AddFloorTileArea(1, 11, 11, 15);
            AddFloorTileColumn(12, 13, 12);
            AddHorizontalCrossSection(2, 5, 8);
            collidableWalls.Add(new CollidableWall(texture, Tile.tileSize * new Vector2(6, 8), SpecificTileType.CrossSectIntersectUp));
            AddHorizontalCrossSection(7, 11, 8);
            AddHorizontalWall(2, 11, 9);
            AddVerticalCrossSection(10, 15, 0);
            collidableWalls.Add(new CollidableWall(texture, Tile.tileSize * new Vector2(12, 8), SpecificTileType.CrossSectCornerBottomLeft));
            collidableWalls.Add(new CollidableWall(texture, Tile.tileSize * new Vector2(12, 9), SpecificTileType.CrossSectVertical));
            collidableWalls.Add(new CollidableWall(texture, Tile.tileSize * new Vector2(12, 10), SpecificTileType.CrossSectEndTop));
            collidableWalls.Add(new CollidableWall(texture, Tile.tileSize * new Vector2(12, 11), SpecificTileType.Wall));
            collidableWalls.Add(new CollidableWall(texture, Tile.tileSize * new Vector2(12, 14), SpecificTileType.CrossSectEndBottom));
            collidableWalls.Add(new CollidableWall(texture, Tile.tileSize * new Vector2(12, 15), SpecificTileType.CrossSectVertical));
            // Room 2
            AddFloorTileRow(17, 26, 10);
            AddFloorTileArea(17, 27, 11, 15);
            AddFloorTileColumn(12, 13, 16);
            AddHorizontalCrossSection(17, 21, 8);
            collidableWalls.Add(new CollidableWall(texture, Tile.tileSize * new Vector2(22, 8), SpecificTileType.CrossSectIntersectUp));
            AddHorizontalCrossSection(23, 26, 8);
            AddHorizontalWall(17, 26, 9);
            AddVerticalCrossSection(10, 15, 28);
            collidableWalls.Add(new CollidableWall(texture, Tile.tileSize * new Vector2(16, 8), SpecificTileType.CrossSectCornerBottomRight));
            collidableWalls.Add(new CollidableWall(texture, Tile.tileSize * new Vector2(16, 9), SpecificTileType.CrossSectVertical));
            collidableWalls.Add(new CollidableWall(texture, Tile.tileSize * new Vector2(16, 10), SpecificTileType.CrossSectEndTop));
            collidableWalls.Add(new CollidableWall(texture, Tile.tileSize * new Vector2(16, 11), SpecificTileType.Wall));
            collidableWalls.Add(new CollidableWall(texture, Tile.tileSize * new Vector2(16, 14), SpecificTileType.CrossSectEndBottom));
            collidableWalls.Add(new CollidableWall(texture, Tile.tileSize * new Vector2(16, 15), SpecificTileType.CrossSectVertical));
            // Room 3
            AddFloorTileArea(1, 11, 18, 23);
            AddFloorTileColumn(20, 21, 12);
            AddHorizontalCrossSection(1, 11, 16);
            AddHorizontalWall(1, 11, 17);
            AddVerticalCrossSection(17, 23, 0);
            collidableWalls.Add(new CollidableWall(texture, Tile.tileSize * new Vector2(0, 16), SpecificTileType.CrossSectIntersectRight));
            collidableWalls.Add(new CollidableWall(texture, Tile.tileSize * new Vector2(12, 16), SpecificTileType.CrossSectIntersectLeft));
            collidableWalls.Add(new CollidableWall(texture, Tile.tileSize * new Vector2(12, 17), SpecificTileType.CrossSectVertical));
            collidableWalls.Add(new CollidableWall(texture, Tile.tileSize * new Vector2(12, 18), SpecificTileType.CrossSectEndTop));
            collidableWalls.Add(new CollidableWall(texture, Tile.tileSize * new Vector2(12, 19), SpecificTileType.Wall));
            collidableWalls.Add(new CollidableWall(texture, Tile.tileSize * new Vector2(12, 22), SpecificTileType.CrossSectEndBottom));
            collidableWalls.Add(new CollidableWall(texture, Tile.tileSize * new Vector2(12, 23), SpecificTileType.CrossSectVertical));
            // Room 4
            AddFloorTileArea(17, 27, 18, 23);
            AddFloorTileColumn(20, 21, 16);
            AddHorizontalCrossSection(17, 27, 16);
            AddHorizontalWall(17, 27, 17);
            AddVerticalCrossSection(17, 23, 28);
            collidableWalls.Add(new CollidableWall(texture, Tile.tileSize * new Vector2(28, 16), SpecificTileType.CrossSectIntersectLeft));
            collidableWalls.Add(new CollidableWall(texture, Tile.tileSize * new Vector2(16, 16), SpecificTileType.CrossSectIntersectRight));
            collidableWalls.Add(new CollidableWall(texture, Tile.tileSize * new Vector2(16, 17), SpecificTileType.CrossSectVertical));
            collidableWalls.Add(new CollidableWall(texture, Tile.tileSize * new Vector2(16, 18), SpecificTileType.CrossSectEndTop));
            collidableWalls.Add(new CollidableWall(texture, Tile.tileSize * new Vector2(16, 19), SpecificTileType.Wall));
            collidableWalls.Add(new CollidableWall(texture, Tile.tileSize * new Vector2(16, 22), SpecificTileType.CrossSectEndBottom));
            collidableWalls.Add(new CollidableWall(texture, Tile.tileSize * new Vector2(16, 23), SpecificTileType.CrossSectVertical));
            // Room 5
            AddFloorTileArea(1, 11, 26, 31);
            AddFloorTileColumn(28, 29, 12);
            AddHorizontalCrossSection(1, 11, 24);
            AddHorizontalWall(1, 11, 25);
            AddHorizontalCrossSection(2, 6, 32);
            AddVerticalCrossSection(25, 30, 0);
            collidableWalls.Add(new CollidableWall(texture, Tile.tileSize * new Vector2(0, 24), SpecificTileType.CrossSectIntersectRight));
            collidableWalls.Add(new CollidableWall(texture, Tile.tileSize * new Vector2(12, 24), SpecificTileType.CrossSectIntersectLeft));
            collidableWalls.Add(new CollidableWall(texture, Tile.tileSize * new Vector2(12, 25), SpecificTileType.CrossSectVertical));
            collidableWalls.Add(new CollidableWall(texture, Tile.tileSize * new Vector2(12, 26), SpecificTileType.CrossSectEndTop));
            collidableWalls.Add(new CollidableWall(texture, Tile.tileSize * new Vector2(12, 27), SpecificTileType.Wall));
            collidableWalls.Add(new CollidableWall(texture, Tile.tileSize * new Vector2(12, 30), SpecificTileType.CrossSectEndBottom));
            collidableWalls.Add(new CollidableWall(texture, Tile.tileSize * new Vector2(12, 31), SpecificTileType.CrossSectVertical));
            // Room 6
            AddFloorTileArea(17, 27, 26, 31);
            AddFloorTileColumn(28, 29, 16);
            AddHorizontalCrossSection(17, 27, 24);
            AddHorizontalWall(17, 27, 25);
            AddHorizontalCrossSection(22, 26, 32);
            AddVerticalCrossSection(25, 30, 28);
            collidableWalls.Add(new CollidableWall(texture, Tile.tileSize * new Vector2(28, 24), SpecificTileType.CrossSectIntersectLeft));
            collidableWalls.Add(new CollidableWall(texture, Tile.tileSize * new Vector2(16, 24), SpecificTileType.CrossSectIntersectRight));
            collidableWalls.Add(new CollidableWall(texture, Tile.tileSize * new Vector2(16, 25), SpecificTileType.CrossSectVertical));
            collidableWalls.Add(new CollidableWall(texture, Tile.tileSize * new Vector2(16, 26), SpecificTileType.CrossSectEndTop));
            collidableWalls.Add(new CollidableWall(texture, Tile.tileSize * new Vector2(16, 27), SpecificTileType.Wall));
            collidableWalls.Add(new CollidableWall(texture, Tile.tileSize * new Vector2(16, 30), SpecificTileType.CrossSectEndBottom));
            collidableWalls.Add(new CollidableWall(texture, Tile.tileSize * new Vector2(16, 31), SpecificTileType.CrossSectVertical));
            // Engine room
            AddFloorTileArea(8, 20, 34, 40);
            AddHorizontalCrossSection(8, 11, 32);
            AddHorizontalWall(8, 12, 33);
            AddHorizontalCrossSection(17, 20, 32);
            AddHorizontalWall(16, 20, 33);
            AddHorizontalCrossSection(9, 19, 41);
            AddVerticalCrossSection(33, 39, 7);
            AddVerticalCrossSection(33, 39, 21);
            collidableWalls.Add(new CollidableWall(texture, Tile.tileSize * new Vector2(7, 32), SpecificTileType.CrossSectIntersectBottom));
            collidableWalls.Add(new CollidableWall(texture, Tile.tileSize * new Vector2(21, 32), SpecificTileType.CrossSectIntersectBottom));
            collidableWalls.Add(new CollidableWall(texture, Tile.tileSize * new Vector2(12, 32), SpecificTileType.CrossSectCornerTopLeft));
            collidableWalls.Add(new CollidableWall(texture, Tile.tileSize * new Vector2(16, 32), SpecificTileType.CrossSectCornerTopRight));
            // Hallway
            AddFloorTileArea(7, 21, 5, 7);
        }

        protected void AddFloorTileColumn(int startY, int finishY, int columnX) { AddFloorTileArea(columnX, columnX, startY, finishY); }

        protected void AddFloorTileRow(int startX, int finishX, int rowY) { AddFloorTileArea(startX, finishX, rowY, rowY); }

        protected void AddFloorTileArea(int startX, int finishX, int startY, int finishY)
        {
            for (int i = startX; i <= finishX; ++i)
            {
                for (int j = startY; j <= finishY; ++j)
                {
                    floorTiles.Add(new ShipFloor(texture, Tile.tileSize * new Vector2(i, j),
                        (i + j) % 2 == 0 ? SpecificTileType.FloorLight : SpecificTileType.FloorDark));
                }
            }
        }

        protected void AddHorizontalCrossSection(int startX, int finishX, int rowY)
        {
            for (int i = startX; i <= finishX; ++i)
            {
                collidableWalls.Add(new CollidableWall(texture, Tile.tileSize * new Vector2(i, rowY), SpecificTileType.CrossSectHorizontal));
            }
        }

        protected void AddVerticalCrossSection(int startY, int finishY, int columnX)
        {
            for (int i = startY; i <= finishY; ++i)
            {
                collidableWalls.Add(new CollidableWall(texture, Tile.tileSize * new Vector2(columnX, i), SpecificTileType.CrossSectVertical));
            }
        }

        protected void AddHorizontalWall(int startX, int finishX, int rowY)
        {
            for (int i = startX; i <= finishX; ++i)
            {
                collidableWalls.Add(new CollidableWall(texture, Tile.tileSize * new Vector2(i, rowY), SpecificTileType.Wall));
            }
        }
    }
}
