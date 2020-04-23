using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonoGame.Extended;
using SpaceGame.Models;
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
        public List<ShipFloorTile> floorTiles;          // Tiles used for pathfinding for entities
        protected List<Tile> bottomLayerTiles;          // Tiles to be rendered first
        protected List<Tile> topLayerTiles;             // Tiles to be rendered second
        public List<HoldingTile> holdingTiles;          // Tiles that can hold interior objects
        protected Texture2D texture;                    // Texture of all themeable tiles

        protected int floorID;

        public ShipTileManager(Texture2D texture)
        {
            this.texture = texture;
            floorTiles = new List<ShipFloorTile>();
            topLayerTiles = new List<Tile>();
            bottomLayerTiles = new List<Tile>();
            holdingTiles = new List<HoldingTile>();
            BuildShip();
        }

        public Vector2 GetShipSize()
        {
            int maxX = floorTiles[0].X;
            int maxY = floorTiles[0].Y;

            foreach (var floorTile in floorTiles)
            {
                if (floorTile.X > maxX) maxX = floorTile.X;
                if (floorTile.Y > maxY) maxY = floorTile.Y;
            }
            foreach (var topLayerTiles in topLayerTiles)
            {
                if (topLayerTiles.X > maxX) maxX = topLayerTiles.X;
                if (topLayerTiles.Y > maxY) maxY = topLayerTiles.Y;
            }
            foreach (var bottomLayerTiles in bottomLayerTiles)
            {
                if (bottomLayerTiles.X > maxX) maxX = bottomLayerTiles.X;
                if (bottomLayerTiles.Y > maxY) maxY = bottomLayerTiles.Y;
            }
            return new Vector2(maxX, maxY);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (var floorTile in floorTiles) floorTile.Draw(spriteBatch);
            foreach (var bottomLayerTile in bottomLayerTiles) bottomLayerTile.Draw(spriteBatch);
            foreach (var topLayerTile in topLayerTiles) topLayerTile.Draw(spriteBatch);
            foreach (var placeableTile in holdingTiles) placeableTile.Draw(spriteBatch);
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
            AddPlaceableTileArea(2, 11, 10, 10);
            AddFloorTileArea(1, 11, 11, 14);
            AddPlaceableTileArea(1, 11, 15, 15);
            AddFloorTileColumn(12, 13, 12);
            AddHorizontalCrossSection(2, 5, 8);
            topLayerTiles.Add(new Tile(texture, 6, 8, SpecificTileType.CrossSectIntersectUp));
            AddHorizontalCrossSection(7, 11, 8);
            AddHorizontalWall(2, 11, 9);
            AddVerticalCrossSection(10, 15, 0);
            topLayerTiles.Add(new Tile(texture, 12, 8, SpecificTileType.CrossSectCornerBottomLeft));
            topLayerTiles.Add(new Tile(texture, 12, 9, SpecificTileType.CrossSectVertical));
            topLayerTiles.Add(new Tile(texture, 12, 10, SpecificTileType.CrossSectEndTop));
            topLayerTiles.Add(new Tile(texture, 12, 11, SpecificTileType.Wall));
            topLayerTiles.Add(new Tile(texture, 12, 14, SpecificTileType.CrossSectEndBottom));
            topLayerTiles.Add(new Tile(texture, 12, 15, SpecificTileType.CrossSectVertical));
            // Room 2
            AddFloorTileRow(17, 26, 10);
            AddFloorTileArea(17, 27, 11, 15);
            AddFloorTileColumn(12, 13, 16);
            AddHorizontalCrossSection(17, 21, 8);
            topLayerTiles.Add(new Tile(texture, 22, 8, SpecificTileType.CrossSectIntersectUp));
            AddHorizontalCrossSection(23, 26, 8);
            AddHorizontalWall(17, 26, 9);
            AddVerticalCrossSection(10, 15, 28);
            topLayerTiles.Add(new Tile(texture, 16, 8, SpecificTileType.CrossSectCornerBottomRight));
            topLayerTiles.Add(new Tile(texture, 16, 9, SpecificTileType.CrossSectVertical));
            topLayerTiles.Add(new Tile(texture, 16, 10, SpecificTileType.CrossSectEndTop));
            topLayerTiles.Add(new Tile(texture, 16, 11, SpecificTileType.Wall));
            topLayerTiles.Add(new Tile(texture, 16, 14, SpecificTileType.CrossSectEndBottom));
            topLayerTiles.Add(new Tile(texture, 16, 15, SpecificTileType.CrossSectVertical));
            // Room 3
            AddFloorTileArea(1, 11, 18, 23);
            AddFloorTileColumn(20, 21, 12);
            AddHorizontalCrossSection(1, 11, 16);
            AddHorizontalWall(1, 11, 17);
            AddVerticalCrossSection(17, 23, 0);
            topLayerTiles.Add(new Tile(texture, 0, 16, SpecificTileType.CrossSectIntersectRight));
            topLayerTiles.Add(new Tile(texture, 12, 16, SpecificTileType.CrossSectIntersectLeft));
            topLayerTiles.Add(new Tile(texture, 12, 17, SpecificTileType.CrossSectVertical));
            topLayerTiles.Add(new Tile(texture, 12, 18, SpecificTileType.CrossSectEndTop));
            topLayerTiles.Add(new Tile(texture, 12, 19, SpecificTileType.Wall));
            topLayerTiles.Add(new Tile(texture, 12, 22, SpecificTileType.CrossSectEndBottom));
            topLayerTiles.Add(new Tile(texture, 12, 23, SpecificTileType.CrossSectVertical));
            // Room 4
            AddFloorTileArea(17, 27, 18, 23);
            AddFloorTileColumn(20, 21, 16);
            AddHorizontalCrossSection(17, 27, 16);
            AddHorizontalWall(17, 27, 17);
            AddVerticalCrossSection(17, 23, 28);
            topLayerTiles.Add(new Tile(texture, 28, 16, SpecificTileType.CrossSectIntersectLeft));
            topLayerTiles.Add(new Tile(texture, 16, 16, SpecificTileType.CrossSectIntersectRight));
            topLayerTiles.Add(new Tile(texture, 16, 17, SpecificTileType.CrossSectVertical));
            topLayerTiles.Add(new Tile(texture, 16, 18, SpecificTileType.CrossSectEndTop));
            topLayerTiles.Add(new Tile(texture, 16, 19, SpecificTileType.Wall));
            topLayerTiles.Add(new Tile(texture, 16, 22, SpecificTileType.CrossSectEndBottom));
            topLayerTiles.Add(new Tile(texture, 16, 23, SpecificTileType.CrossSectVertical));
            // Room 5
            AddFloorTileArea(1, 11, 26, 31);
            AddFloorTileColumn(28, 29, 12);
            AddHorizontalCrossSection(1, 11, 24);
            AddHorizontalWall(1, 11, 25);
            AddHorizontalCrossSection(2, 6, 32);
            AddVerticalCrossSection(25, 30, 0);
            topLayerTiles.Add(new Tile(texture, 0, 24, SpecificTileType.CrossSectIntersectRight));
            topLayerTiles.Add(new Tile(texture, 12, 24, SpecificTileType.CrossSectIntersectLeft));
            topLayerTiles.Add(new Tile(texture, 12, 25, SpecificTileType.CrossSectVertical));
            topLayerTiles.Add(new Tile(texture, 12, 26, SpecificTileType.CrossSectEndTop));
            topLayerTiles.Add(new Tile(texture, 12, 27, SpecificTileType.Wall));
            topLayerTiles.Add(new Tile(texture, 12, 30, SpecificTileType.CrossSectEndBottom));
            topLayerTiles.Add(new Tile(texture, 12, 31, SpecificTileType.CrossSectVertical));
            // Room 6
            AddFloorTileArea(17, 27, 26, 31);
            AddFloorTileColumn(28, 29, 16);
            AddHorizontalCrossSection(17, 27, 24);
            AddHorizontalWall(17, 27, 25);
            AddHorizontalCrossSection(22, 26, 32);
            AddVerticalCrossSection(25, 30, 28);
            topLayerTiles.Add(new Tile(texture, 28, 24, SpecificTileType.CrossSectIntersectLeft));
            topLayerTiles.Add(new Tile(texture, 16, 24, SpecificTileType.CrossSectIntersectRight));
            topLayerTiles.Add(new Tile(texture, 16, 25, SpecificTileType.CrossSectVertical));
            topLayerTiles.Add(new Tile(texture, 16, 26, SpecificTileType.CrossSectEndTop));
            topLayerTiles.Add(new Tile(texture, 16, 27, SpecificTileType.Wall));
            topLayerTiles.Add(new Tile(texture, 16, 30, SpecificTileType.CrossSectEndBottom));
            topLayerTiles.Add(new Tile(texture, 16, 31, SpecificTileType.CrossSectVertical));
            // Engine room
            AddFloorTileArea(8, 20, 34, 40);
            AddHorizontalCrossSection(8, 11, 32);
            AddHorizontalWall(8, 12, 33);
            AddHorizontalCrossSection(17, 20, 32);
            AddHorizontalWall(16, 20, 33);
            AddHorizontalCrossSection(9, 19, 41);
            AddVerticalCrossSection(33, 39, 7);
            AddVerticalCrossSection(33, 39, 21);
            topLayerTiles.Add(new Tile(texture, 7, 32, SpecificTileType.CrossSectIntersectBottom));
            topLayerTiles.Add(new Tile(texture, 21, 32, SpecificTileType.CrossSectIntersectBottom));
            topLayerTiles.Add(new Tile(texture, 12, 32, SpecificTileType.CrossSectCornerTopLeft));
            topLayerTiles.Add(new Tile(texture, 16, 32, SpecificTileType.CrossSectCornerTopRight));
            // Hallway
            AddFloorTileArea(7, 21, 5, 7);

            // Corners
            topLayerTiles.Add(new Tile(texture, 8, 0, SpecificTileType.OuterCrossSectBottomRight));
            topLayerTiles.Add(new Tile(texture, 7, 1, SpecificTileType.OuterCrossSectBottomRight));
            topLayerTiles.Add(new Tile(texture, 6, 2, SpecificTileType.OuterCrossSectBottomRight));
            topLayerTiles.Add(new Tile(texture, 0, 8, SpecificTileType.OuterCrossSectBottomRight));
            topLayerTiles.Add(new Tile(texture, 20, 0, SpecificTileType.OuterCrossSectBottomLeft));
            topLayerTiles.Add(new Tile(texture, 21, 1, SpecificTileType.OuterCrossSectBottomLeft));
            topLayerTiles.Add(new Tile(texture, 22, 2, SpecificTileType.OuterCrossSectBottomLeft));
            topLayerTiles.Add(new Tile(texture, 28, 8, SpecificTileType.OuterCrossSectBottomLeft));
            topLayerTiles.Add(new Tile(texture, 0, 32, SpecificTileType.OuterCrossSectTopRight));
            topLayerTiles.Add(new Tile(texture, 7, 41, SpecificTileType.OuterCrossSectTopRight));
            topLayerTiles.Add(new Tile(texture, 21, 41, SpecificTileType.OuterCrossSectTopLeft));
            topLayerTiles.Add(new Tile(texture, 28, 32, SpecificTileType.OuterCrossSectTopLeft));

            topLayerTiles.Add(new Tile(texture, 9, 2, SpecificTileType.WallAngleTopLeft));
            topLayerTiles.Add(new Tile(texture, 8, 3, SpecificTileType.WallAngleTopLeft));
            topLayerTiles.Add(new Tile(texture, 7, 4, SpecificTileType.WallAngleTopLeft));
            topLayerTiles.Add(new Tile(texture, 1, 10, SpecificTileType.WallAngleTopLeft));

            topLayerTiles.Add(new Tile(texture, 19, 2, SpecificTileType.WallAngleTopRight));
            topLayerTiles.Add(new Tile(texture, 20, 3, SpecificTileType.WallAngleTopRight));
            topLayerTiles.Add(new Tile(texture, 21, 4, SpecificTileType.WallAngleTopRight));
            topLayerTiles.Add(new Tile(texture, 27, 10, SpecificTileType.WallAngleTopRight));

            topLayerTiles.Add(new Tile(texture, 6, 3, SpecificTileType.CurveCrossSectBottomRight1));
            topLayerTiles.Add(new Tile(texture, 0, 9, SpecificTileType.CurveCrossSectBottomRight1));
            topLayerTiles.Add(new Tile(texture, 22, 3, SpecificTileType.CurveCrossSectBottomLeft1));
            topLayerTiles.Add(new Tile(texture, 28, 9, SpecificTileType.CurveCrossSectBottomLeft1));
            topLayerTiles.Add(new Tile(texture, 0, 31, SpecificTileType.CurveCrossSectTopRight1));
            topLayerTiles.Add(new Tile(texture, 7, 40, SpecificTileType.CurveCrossSectTopRight1));
            topLayerTiles.Add(new Tile(texture, 21, 40, SpecificTileType.CurveCrossSectTopLeft1));
            topLayerTiles.Add(new Tile(texture, 28, 31, SpecificTileType.CurveCrossSectTopLeft1));

            topLayerTiles.Add(new Tile(texture, 9, 0, SpecificTileType.CurveCrossSectBottomRight2));
            topLayerTiles.Add(new Tile(texture, 1, 8, SpecificTileType.CurveCrossSectBottomRight2));
            topLayerTiles.Add(new Tile(texture, 19, 0, SpecificTileType.CurveCrossSectBottomLeft2));
            topLayerTiles.Add(new Tile(texture, 27, 8, SpecificTileType.CurveCrossSectBottomLeft2));
            topLayerTiles.Add(new Tile(texture, 1, 32, SpecificTileType.CurveCrossSectTopRight2));
            topLayerTiles.Add(new Tile(texture, 8, 41, SpecificTileType.CurveCrossSectTopRight2));
            topLayerTiles.Add(new Tile(texture, 20, 41, SpecificTileType.CurveCrossSectTopLeft2));
            topLayerTiles.Add(new Tile(texture, 27, 32, SpecificTileType.CurveCrossSectTopLeft2));

            topLayerTiles.Add(new Tile(texture, 27, 31, SpecificTileType.AngleCrossSectBottomRight));
            topLayerTiles.Add(new Tile(texture, 20, 40, SpecificTileType.AngleCrossSectBottomRight));
            topLayerTiles.Add(new Tile(texture, 1, 31, SpecificTileType.AngleCrossSectBottomLeft));
            topLayerTiles.Add(new Tile(texture, 8, 40, SpecificTileType.AngleCrossSectBottomLeft));

            topLayerTiles.Add(new Tile(texture, 9, 1, SpecificTileType.AngleCrossSectTopLeft));
            topLayerTiles.Add(new Tile(texture, 8, 2, SpecificTileType.AngleCrossSectTopLeft));
            topLayerTiles.Add(new Tile(texture, 7, 3, SpecificTileType.AngleCrossSectTopLeft));
            topLayerTiles.Add(new Tile(texture, 1, 9, SpecificTileType.AngleCrossSectTopLeft));
            topLayerTiles.Add(new Tile(texture, 19, 1, SpecificTileType.AngleCrossSectTopRight));
            topLayerTiles.Add(new Tile(texture, 20, 2, SpecificTileType.AngleCrossSectTopRight));
            topLayerTiles.Add(new Tile(texture, 21, 3, SpecificTileType.AngleCrossSectTopRight));
            topLayerTiles.Add(new Tile(texture, 27, 9, SpecificTileType.AngleCrossSectTopRight));

            topLayerTiles.Add(new Tile(texture, 8, 1, SpecificTileType.AngleBottomRight));
            topLayerTiles.Add(new Tile(texture, 7, 2, SpecificTileType.AngleBottomRight));
            topLayerTiles.Add(new Tile(texture, 20, 1, SpecificTileType.AngleBottomLeft));
            topLayerTiles.Add(new Tile(texture, 21, 2, SpecificTileType.AngleBottomLeft));

            bottomLayerTiles.Add(new Tile(texture, 9, 2, SpecificTileType.FloorDark));
            bottomLayerTiles.Add(new Tile(texture, 8, 3, SpecificTileType.FloorDark));
            bottomLayerTiles.Add(new Tile(texture, 7, 4, SpecificTileType.FloorDark));
            bottomLayerTiles.Add(new Tile(texture, 1, 10, SpecificTileType.FloorDark));
            bottomLayerTiles.Add(new Tile(texture, 19, 2, SpecificTileType.FloorDark));
            bottomLayerTiles.Add(new Tile(texture, 20, 3, SpecificTileType.FloorDark));
            bottomLayerTiles.Add(new Tile(texture, 21, 4, SpecificTileType.FloorDark));
            bottomLayerTiles.Add(new Tile(texture, 27, 10, SpecificTileType.FloorDark));
        }

        protected void AddFloorTileColumn(int startY, int finishY, int columnX) { AddFloorTileArea(columnX, columnX, startY, finishY); }

        protected void AddFloorTileRow(int startX, int finishX, int rowY) { AddFloorTileArea(startX, finishX, rowY, rowY); }

        protected void AddFloorTileArea(int startX, int finishX, int startY, int finishY)
        {
            for (int i = startX; i <= finishX; ++i)
            {
                for (int j = startY; j <= finishY; ++j)
                {
                    floorTiles.Add(new ShipFloorTile(texture, i, j, (i + j) % 2 == 0 ? SpecificTileType.FloorLight : SpecificTileType.FloorDark, floorID));
                    floorID++;
                }
            }
        }

        protected void AddHorizontalCrossSection(int startX, int finishX, int rowY)
        {
            for (int i = startX; i <= finishX; ++i)
            {
                topLayerTiles.Add(new Tile(texture, i, rowY, SpecificTileType.CrossSectHorizontal));
            }
        }

        protected void AddVerticalCrossSection(int startY, int finishY, int columnX)
        {
            for (int i = startY; i <= finishY; ++i)
            {
                topLayerTiles.Add(new Tile(texture, columnX, i, SpecificTileType.CrossSectVertical));
            }
        }

        protected void AddHorizontalWall(int startX, int finishX, int rowY)
        {
            for (int i = startX; i <= finishX; ++i)
            {
                topLayerTiles.Add(new Tile(texture, i, rowY, SpecificTileType.Wall));
            }
        }

        protected void AddPlaceableTileArea(int startX, int finishX, int startY, int finishY)
        {
            for (int i = startX; i <= finishX; ++i)
            {
                for (int j = startY; j <= finishY; ++j)
                {
                    holdingTiles.Add(new HoldingTile(i, j));
                }
            }
        }
    }
}
