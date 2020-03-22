﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Extended;
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
        protected List<ShipWall> wallTiles;
        protected List<Tile> otherTiles;
        protected Texture2D texture;

        public ShipTileManager(Texture2D texture)
        {
            this.texture = texture;
            floorTiles = new List<ShipFloor>();
            otherTiles = new List<Tile>();
            wallTiles = new List<ShipWall>();
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
            foreach (var collidableWall in wallTiles)
            {
                if (collidableWall.position.X > maxPosition.X) maxPosition.X = collidableWall.position.X;
                if (collidableWall.position.Y > maxPosition.Y) maxPosition.Y = collidableWall.position.Y;
            }
            foreach (var otherTile in otherTiles)
            {
                if (otherTile.position.X > maxPosition.X) maxPosition.X = otherTile.position.X;
                if (otherTile.position.Y > maxPosition.Y) maxPosition.Y = otherTile.position.Y;
            }
            return maxPosition;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (var floorTile in floorTiles) floorTile.Draw(spriteBatch);
            foreach (var otherTile in otherTiles) otherTile.Draw(spriteBatch);
            foreach (var collidableWall in wallTiles) collidableWall.Draw(spriteBatch);
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
            wallTiles.Add(new ShipWall(texture, Tile.tileSize * new Vector2(6, 8), SpecificTileType.CrossSectIntersectUp));
            AddHorizontalCrossSection(7, 11, 8);
            AddHorizontalWall(2, 11, 9);
            AddVerticalCrossSection(10, 15, 0);
            wallTiles.Add(new ShipWall(texture, Tile.tileSize * new Vector2(12, 8), SpecificTileType.CrossSectCornerBottomLeft));
            wallTiles.Add(new ShipWall(texture, Tile.tileSize * new Vector2(12, 9), SpecificTileType.CrossSectVertical));
            wallTiles.Add(new ShipWall(texture, Tile.tileSize * new Vector2(12, 10), SpecificTileType.CrossSectEndTop));
            wallTiles.Add(new ShipWall(texture, Tile.tileSize * new Vector2(12, 11), SpecificTileType.Wall));
            wallTiles.Add(new ShipWall(texture, Tile.tileSize * new Vector2(12, 14), SpecificTileType.CrossSectEndBottom));
            wallTiles.Add(new ShipWall(texture, Tile.tileSize * new Vector2(12, 15), SpecificTileType.CrossSectVertical));
            // Room 2
            AddFloorTileRow(17, 26, 10);
            AddFloorTileArea(17, 27, 11, 15);
            AddFloorTileColumn(12, 13, 16);
            AddHorizontalCrossSection(17, 21, 8);
            wallTiles.Add(new ShipWall(texture, Tile.tileSize * new Vector2(22, 8), SpecificTileType.CrossSectIntersectUp));
            AddHorizontalCrossSection(23, 26, 8);
            AddHorizontalWall(17, 26, 9);
            AddVerticalCrossSection(10, 15, 28);
            wallTiles.Add(new ShipWall(texture, Tile.tileSize * new Vector2(16, 8), SpecificTileType.CrossSectCornerBottomRight));
            wallTiles.Add(new ShipWall(texture, Tile.tileSize * new Vector2(16, 9), SpecificTileType.CrossSectVertical));
            wallTiles.Add(new ShipWall(texture, Tile.tileSize * new Vector2(16, 10), SpecificTileType.CrossSectEndTop));
            wallTiles.Add(new ShipWall(texture, Tile.tileSize * new Vector2(16, 11), SpecificTileType.Wall));
            wallTiles.Add(new ShipWall(texture, Tile.tileSize * new Vector2(16, 14), SpecificTileType.CrossSectEndBottom));
            wallTiles.Add(new ShipWall(texture, Tile.tileSize * new Vector2(16, 15), SpecificTileType.CrossSectVertical));
            // Room 3
            AddFloorTileArea(1, 11, 18, 23);
            AddFloorTileColumn(20, 21, 12);
            AddHorizontalCrossSection(1, 11, 16);
            AddHorizontalWall(1, 11, 17);
            AddVerticalCrossSection(17, 23, 0);
            wallTiles.Add(new ShipWall(texture, Tile.tileSize * new Vector2(0, 16), SpecificTileType.CrossSectIntersectRight));
            wallTiles.Add(new ShipWall(texture, Tile.tileSize * new Vector2(12, 16), SpecificTileType.CrossSectIntersectLeft));
            wallTiles.Add(new ShipWall(texture, Tile.tileSize * new Vector2(12, 17), SpecificTileType.CrossSectVertical));
            wallTiles.Add(new ShipWall(texture, Tile.tileSize * new Vector2(12, 18), SpecificTileType.CrossSectEndTop));
            wallTiles.Add(new ShipWall(texture, Tile.tileSize * new Vector2(12, 19), SpecificTileType.Wall));
            wallTiles.Add(new ShipWall(texture, Tile.tileSize * new Vector2(12, 22), SpecificTileType.CrossSectEndBottom));
            wallTiles.Add(new ShipWall(texture, Tile.tileSize * new Vector2(12, 23), SpecificTileType.CrossSectVertical));
            // Room 4
            AddFloorTileArea(17, 27, 18, 23);
            AddFloorTileColumn(20, 21, 16);
            AddHorizontalCrossSection(17, 27, 16);
            AddHorizontalWall(17, 27, 17);
            AddVerticalCrossSection(17, 23, 28);
            wallTiles.Add(new ShipWall(texture, Tile.tileSize * new Vector2(28, 16), SpecificTileType.CrossSectIntersectLeft));
            wallTiles.Add(new ShipWall(texture, Tile.tileSize * new Vector2(16, 16), SpecificTileType.CrossSectIntersectRight));
            wallTiles.Add(new ShipWall(texture, Tile.tileSize * new Vector2(16, 17), SpecificTileType.CrossSectVertical));
            wallTiles.Add(new ShipWall(texture, Tile.tileSize * new Vector2(16, 18), SpecificTileType.CrossSectEndTop));
            wallTiles.Add(new ShipWall(texture, Tile.tileSize * new Vector2(16, 19), SpecificTileType.Wall));
            wallTiles.Add(new ShipWall(texture, Tile.tileSize * new Vector2(16, 22), SpecificTileType.CrossSectEndBottom));
            wallTiles.Add(new ShipWall(texture, Tile.tileSize * new Vector2(16, 23), SpecificTileType.CrossSectVertical));
            // Room 5
            AddFloorTileArea(1, 11, 26, 31);
            AddFloorTileColumn(28, 29, 12);
            AddHorizontalCrossSection(1, 11, 24);
            AddHorizontalWall(1, 11, 25);
            AddHorizontalCrossSection(2, 6, 32);
            AddVerticalCrossSection(25, 30, 0);
            wallTiles.Add(new ShipWall(texture, Tile.tileSize * new Vector2(0, 24), SpecificTileType.CrossSectIntersectRight));
            wallTiles.Add(new ShipWall(texture, Tile.tileSize * new Vector2(12, 24), SpecificTileType.CrossSectIntersectLeft));
            wallTiles.Add(new ShipWall(texture, Tile.tileSize * new Vector2(12, 25), SpecificTileType.CrossSectVertical));
            wallTiles.Add(new ShipWall(texture, Tile.tileSize * new Vector2(12, 26), SpecificTileType.CrossSectEndTop));
            wallTiles.Add(new ShipWall(texture, Tile.tileSize * new Vector2(12, 27), SpecificTileType.Wall));
            wallTiles.Add(new ShipWall(texture, Tile.tileSize * new Vector2(12, 30), SpecificTileType.CrossSectEndBottom));
            wallTiles.Add(new ShipWall(texture, Tile.tileSize * new Vector2(12, 31), SpecificTileType.CrossSectVertical));
            // Room 6
            AddFloorTileArea(17, 27, 26, 31);
            AddFloorTileColumn(28, 29, 16);
            AddHorizontalCrossSection(17, 27, 24);
            AddHorizontalWall(17, 27, 25);
            AddHorizontalCrossSection(22, 26, 32);
            AddVerticalCrossSection(25, 30, 28);
            wallTiles.Add(new ShipWall(texture, Tile.tileSize * new Vector2(28, 24), SpecificTileType.CrossSectIntersectLeft));
            wallTiles.Add(new ShipWall(texture, Tile.tileSize * new Vector2(16, 24), SpecificTileType.CrossSectIntersectRight));
            wallTiles.Add(new ShipWall(texture, Tile.tileSize * new Vector2(16, 25), SpecificTileType.CrossSectVertical));
            wallTiles.Add(new ShipWall(texture, Tile.tileSize * new Vector2(16, 26), SpecificTileType.CrossSectEndTop));
            wallTiles.Add(new ShipWall(texture, Tile.tileSize * new Vector2(16, 27), SpecificTileType.Wall));
            wallTiles.Add(new ShipWall(texture, Tile.tileSize * new Vector2(16, 30), SpecificTileType.CrossSectEndBottom));
            wallTiles.Add(new ShipWall(texture, Tile.tileSize * new Vector2(16, 31), SpecificTileType.CrossSectVertical));
            // Engine room
            AddFloorTileArea(8, 20, 34, 40);
            AddHorizontalCrossSection(8, 11, 32);
            AddHorizontalWall(8, 12, 33);
            AddHorizontalCrossSection(17, 20, 32);
            AddHorizontalWall(16, 20, 33);
            AddHorizontalCrossSection(9, 19, 41);
            AddVerticalCrossSection(33, 39, 7);
            AddVerticalCrossSection(33, 39, 21);
            wallTiles.Add(new ShipWall(texture, Tile.tileSize * new Vector2(7, 32), SpecificTileType.CrossSectIntersectBottom));
            wallTiles.Add(new ShipWall(texture, Tile.tileSize * new Vector2(21, 32), SpecificTileType.CrossSectIntersectBottom));
            wallTiles.Add(new ShipWall(texture, Tile.tileSize * new Vector2(12, 32), SpecificTileType.CrossSectCornerTopLeft));
            wallTiles.Add(new ShipWall(texture, Tile.tileSize * new Vector2(16, 32), SpecificTileType.CrossSectCornerTopRight));
            // Hallway
            AddFloorTileArea(7, 21, 5, 7);

            // Corners
            wallTiles.Add(new ShipWall(texture, Tile.tileSize * new Vector2(8, 0), SpecificTileType.OuterCrossSectBottomRight));
            wallTiles.Add(new ShipWall(texture, Tile.tileSize * new Vector2(7, 1), SpecificTileType.OuterCrossSectBottomRight));
            wallTiles.Add(new ShipWall(texture, Tile.tileSize * new Vector2(6, 2), SpecificTileType.OuterCrossSectBottomRight));
            wallTiles.Add(new ShipWall(texture, Tile.tileSize * new Vector2(0, 8), SpecificTileType.OuterCrossSectBottomRight));
            wallTiles.Add(new ShipWall(texture, Tile.tileSize * new Vector2(20, 0), SpecificTileType.OuterCrossSectBottomLeft));
            wallTiles.Add(new ShipWall(texture, Tile.tileSize * new Vector2(21, 1), SpecificTileType.OuterCrossSectBottomLeft));
            wallTiles.Add(new ShipWall(texture, Tile.tileSize * new Vector2(22, 2), SpecificTileType.OuterCrossSectBottomLeft));
            wallTiles.Add(new ShipWall(texture, Tile.tileSize * new Vector2(28, 8), SpecificTileType.OuterCrossSectBottomLeft));
            wallTiles.Add(new ShipWall(texture, Tile.tileSize * new Vector2(0, 32), SpecificTileType.OuterCrossSectTopRight));
            wallTiles.Add(new ShipWall(texture, Tile.tileSize * new Vector2(7, 41), SpecificTileType.OuterCrossSectTopRight));
            wallTiles.Add(new ShipWall(texture, Tile.tileSize * new Vector2(21, 41), SpecificTileType.OuterCrossSectTopLeft));
            wallTiles.Add(new ShipWall(texture, Tile.tileSize * new Vector2(28, 32), SpecificTileType.OuterCrossSectTopLeft));

            wallTiles.Add(new ShipWall(texture, Tile.tileSize * new Vector2(9, 2), SpecificTileType.WallAngleTopLeft));
            wallTiles.Add(new ShipWall(texture, Tile.tileSize * new Vector2(8, 3), SpecificTileType.WallAngleTopLeft));
            wallTiles.Add(new ShipWall(texture, Tile.tileSize * new Vector2(7, 4), SpecificTileType.WallAngleTopLeft));
            wallTiles.Add(new ShipWall(texture, Tile.tileSize * new Vector2(1, 10), SpecificTileType.WallAngleTopLeft));

            wallTiles.Add(new ShipWall(texture, Tile.tileSize * new Vector2(19, 2), SpecificTileType.WallAngleTopRight));
            wallTiles.Add(new ShipWall(texture, Tile.tileSize * new Vector2(20, 3), SpecificTileType.WallAngleTopRight));
            wallTiles.Add(new ShipWall(texture, Tile.tileSize * new Vector2(21, 4), SpecificTileType.WallAngleTopRight));
            wallTiles.Add(new ShipWall(texture, Tile.tileSize * new Vector2(27, 10), SpecificTileType.WallAngleTopRight));

            wallTiles.Add(new ShipWall(texture, Tile.tileSize * new Vector2(6, 3), SpecificTileType.CurveCrossSectBottomRight1));
            wallTiles.Add(new ShipWall(texture, Tile.tileSize * new Vector2(0, 9), SpecificTileType.CurveCrossSectBottomRight1));
            wallTiles.Add(new ShipWall(texture, Tile.tileSize * new Vector2(22, 3), SpecificTileType.CurveCrossSectBottomLeft1));
            wallTiles.Add(new ShipWall(texture, Tile.tileSize * new Vector2(28, 9), SpecificTileType.CurveCrossSectBottomLeft1));
            wallTiles.Add(new ShipWall(texture, Tile.tileSize * new Vector2(0, 31), SpecificTileType.CurveCrossSectTopRight1));
            wallTiles.Add(new ShipWall(texture, Tile.tileSize * new Vector2(7, 40), SpecificTileType.CurveCrossSectTopRight1));
            wallTiles.Add(new ShipWall(texture, Tile.tileSize * new Vector2(21, 40), SpecificTileType.CurveCrossSectTopLeft1));
            wallTiles.Add(new ShipWall(texture, Tile.tileSize * new Vector2(28, 31), SpecificTileType.CurveCrossSectTopLeft1));

            wallTiles.Add(new ShipWall(texture, Tile.tileSize * new Vector2(9, 0), SpecificTileType.CurveCrossSectBottomRight2));
            wallTiles.Add(new ShipWall(texture, Tile.tileSize * new Vector2(1, 8), SpecificTileType.CurveCrossSectBottomRight2));
            wallTiles.Add(new ShipWall(texture, Tile.tileSize * new Vector2(19, 0), SpecificTileType.CurveCrossSectBottomLeft2));
            wallTiles.Add(new ShipWall(texture, Tile.tileSize * new Vector2(27, 8), SpecificTileType.CurveCrossSectBottomLeft2));
            wallTiles.Add(new ShipWall(texture, Tile.tileSize * new Vector2(1, 32), SpecificTileType.CurveCrossSectTopRight2));
            wallTiles.Add(new ShipWall(texture, Tile.tileSize * new Vector2(8, 41), SpecificTileType.CurveCrossSectTopRight2));
            wallTiles.Add(new ShipWall(texture, Tile.tileSize * new Vector2(20, 41), SpecificTileType.CurveCrossSectTopLeft2));
            wallTiles.Add(new ShipWall(texture, Tile.tileSize * new Vector2(27, 32), SpecificTileType.CurveCrossSectTopLeft2));

            wallTiles.Add(new ShipWall(texture, Tile.tileSize * new Vector2(27, 31), SpecificTileType.AngleCrossSectBottomRight));
            wallTiles.Add(new ShipWall(texture, Tile.tileSize * new Vector2(20, 40), SpecificTileType.AngleCrossSectBottomRight));
            wallTiles.Add(new ShipWall(texture, Tile.tileSize * new Vector2(1, 31), SpecificTileType.AngleCrossSectBottomLeft));
            wallTiles.Add(new ShipWall(texture, Tile.tileSize * new Vector2(8, 40), SpecificTileType.AngleCrossSectBottomLeft));

            wallTiles.Add(new ShipWall(texture, Tile.tileSize * new Vector2(9, 1), SpecificTileType.AngleCrossSectTopLeft));
            wallTiles.Add(new ShipWall(texture, Tile.tileSize * new Vector2(8, 2), SpecificTileType.AngleCrossSectTopLeft));
            wallTiles.Add(new ShipWall(texture, Tile.tileSize * new Vector2(7, 3), SpecificTileType.AngleCrossSectTopLeft));
            wallTiles.Add(new ShipWall(texture, Tile.tileSize * new Vector2(1, 9), SpecificTileType.AngleCrossSectTopLeft));
            wallTiles.Add(new ShipWall(texture, Tile.tileSize * new Vector2(19, 1), SpecificTileType.AngleCrossSectTopRight));
            wallTiles.Add(new ShipWall(texture, Tile.tileSize * new Vector2(20, 2), SpecificTileType.AngleCrossSectTopRight));
            wallTiles.Add(new ShipWall(texture, Tile.tileSize * new Vector2(21, 3), SpecificTileType.AngleCrossSectTopRight));
            wallTiles.Add(new ShipWall(texture, Tile.tileSize * new Vector2(27, 9), SpecificTileType.AngleCrossSectTopRight));

            wallTiles.Add(new ShipWall(texture, Tile.tileSize * new Vector2(8, 1), SpecificTileType.AngleBottomRight));
            wallTiles.Add(new ShipWall(texture, Tile.tileSize * new Vector2(7, 2), SpecificTileType.AngleBottomRight));
            wallTiles.Add(new ShipWall(texture, Tile.tileSize * new Vector2(20, 1), SpecificTileType.AngleBottomLeft));
            wallTiles.Add(new ShipWall(texture, Tile.tileSize * new Vector2(21, 2), SpecificTileType.AngleBottomLeft));

            otherTiles.Add(new ShipWall(texture, Tile.tileSize * new Vector2(9, 2), SpecificTileType.FloorDark));
            otherTiles.Add(new ShipWall(texture, Tile.tileSize * new Vector2(8, 3), SpecificTileType.FloorDark));
            otherTiles.Add(new ShipWall(texture, Tile.tileSize * new Vector2(7, 4), SpecificTileType.FloorDark));
            otherTiles.Add(new ShipWall(texture, Tile.tileSize * new Vector2(1, 10), SpecificTileType.FloorDark));
            otherTiles.Add(new ShipWall(texture, Tile.tileSize * new Vector2(19, 2), SpecificTileType.FloorDark));
            otherTiles.Add(new ShipWall(texture, Tile.tileSize * new Vector2(20, 3), SpecificTileType.FloorDark));
            otherTiles.Add(new ShipWall(texture, Tile.tileSize * new Vector2(21, 4), SpecificTileType.FloorDark));
            otherTiles.Add(new ShipWall(texture, Tile.tileSize * new Vector2(27, 10), SpecificTileType.FloorDark));
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
                wallTiles.Add(new ShipWall(texture, Tile.tileSize * new Vector2(i, rowY), SpecificTileType.CrossSectHorizontal));
            }
        }

        protected void AddVerticalCrossSection(int startY, int finishY, int columnX)
        {
            for (int i = startY; i <= finishY; ++i)
            {
                wallTiles.Add(new ShipWall(texture, Tile.tileSize * new Vector2(columnX, i), SpecificTileType.CrossSectVertical));
            }
        }

        protected void AddHorizontalWall(int startX, int finishX, int rowY)
        {
            for (int i = startX; i <= finishX; ++i)
            {
                wallTiles.Add(new ShipWall(texture, Tile.tileSize * new Vector2(i, rowY), SpecificTileType.Wall));
            }
        }
    }
}
