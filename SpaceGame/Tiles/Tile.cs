using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceGame.Tiles
{
    public enum SpecificTileType
    {
        // Left/Right and Top/Bottom refer to where they are connected to other tiles
        CurveCrossSectTopLeft1,
        CurveCrossSectTopRight1,
        CurveCrossSectBottomLeft1,
        CurveCrossSectBottomRight1,
        CurveCrossSectTopLeft2,
        CurveCrossSectTopRight2,
        CurveCrossSectBottomLeft2,
        CurveCrossSectBottomRight2,
        AngleCrossSectTopLeft,
        AngleCrossSectTopRight,
        AngleCrossSectBottomLeft,
        AngleCrossSectBottomRight,
        Wall,
        WallAngleTopRight,
        WallAngleTopLeft,
        OuterCrossSectBottomRight,
        OuterCrossSectBottomLeft,
        OuterCrossSectTopRight,
        OuterCrossSectTopLeft,
        CrossSectCornerBottomRight,
        CrossSectCornerBottomLeft,
        CrossSectIntersectRight,
        CrossSectIntersectLeft,
        CrossSectIntersectUp,
        CrossSectIntersectBottom,
        CrossSectCornerTopLeft,
        CrossSectCornerTopRight,
        CrossSectEndBottom,
        CrossSectEndTop,
        CrossSectHorizontal,
        CrossSectVertical,
        AngleBottomLeft,
        AngleBottomRight,
        FloorLight,
        FloorDark,
        PlaceableTile
    }

    public class Tile
    {
        public int X;
        public int Y;
        protected Vector2 position { get { return new Vector2(X, Y); } }
        protected Texture2D texture;
        protected bool collidable;
        protected Rectangle textureRectangle;

        public static int tileSize = 8;
        public static Dictionary<SpecificTileType, Rectangle> tileRectangleLookup = new Dictionary<SpecificTileType, Rectangle>()
        {
            { SpecificTileType.CurveCrossSectBottomRight1,  new Rectangle(0 * tileSize, 0 * tileSize, tileSize, tileSize ) },
            { SpecificTileType.CurveCrossSectBottomLeft1,   new Rectangle(1 * tileSize, 0 * tileSize, tileSize, tileSize ) },
            { SpecificTileType.CurveCrossSectBottomRight2,  new Rectangle(2 * tileSize, 0 * tileSize, tileSize, tileSize ) },
            { SpecificTileType.CurveCrossSectBottomLeft2,   new Rectangle(3 * tileSize, 0 * tileSize, tileSize, tileSize ) },
            { SpecificTileType.AngleCrossSectBottomRight,   new Rectangle(4 * tileSize, 0 * tileSize, tileSize, tileSize ) },
            { SpecificTileType.AngleCrossSectBottomLeft,    new Rectangle(5 * tileSize, 0 * tileSize, tileSize, tileSize ) },
            { SpecificTileType.Wall,                        new Rectangle(6 * tileSize, 0 * tileSize, tileSize, tileSize ) },
            { SpecificTileType.PlaceableTile,               new Rectangle(7 * tileSize, 0 * tileSize, tileSize, tileSize ) },
            { SpecificTileType.CurveCrossSectTopRight1,     new Rectangle(0 * tileSize, 1 * tileSize, tileSize, tileSize ) },
            { SpecificTileType.CurveCrossSectTopLeft1,      new Rectangle(1 * tileSize, 1 * tileSize, tileSize, tileSize ) },
            { SpecificTileType.CurveCrossSectTopRight2,     new Rectangle(2 * tileSize, 1 * tileSize, tileSize, tileSize ) },
            { SpecificTileType.CurveCrossSectTopLeft2,      new Rectangle(3 * tileSize, 1 * tileSize, tileSize, tileSize ) },
            { SpecificTileType.AngleCrossSectTopRight,      new Rectangle(4 * tileSize, 1 * tileSize, tileSize, tileSize ) },
            { SpecificTileType.AngleCrossSectTopLeft,       new Rectangle(5 * tileSize, 1 * tileSize, tileSize, tileSize ) },
            { SpecificTileType.CrossSectIntersectLeft,      new Rectangle(6 * tileSize, 1 * tileSize, tileSize, tileSize ) },
            { SpecificTileType.OuterCrossSectBottomRight,   new Rectangle(0 * tileSize, 2 * tileSize, tileSize, tileSize ) },
            { SpecificTileType.OuterCrossSectBottomLeft,    new Rectangle(1 * tileSize, 2 * tileSize, tileSize, tileSize ) },
            { SpecificTileType.CrossSectCornerBottomRight,  new Rectangle(2 * tileSize, 2 * tileSize, tileSize, tileSize ) },
            { SpecificTileType.CrossSectCornerBottomLeft,   new Rectangle(3 * tileSize, 2 * tileSize, tileSize, tileSize ) },
            { SpecificTileType.WallAngleTopRight,           new Rectangle(4 * tileSize, 2 * tileSize, tileSize, tileSize ) },
            { SpecificTileType.WallAngleTopLeft,            new Rectangle(5 * tileSize, 2 * tileSize, tileSize, tileSize ) },
            { SpecificTileType.CrossSectIntersectRight,     new Rectangle(6 * tileSize, 2 * tileSize, tileSize, tileSize ) },
            { SpecificTileType.OuterCrossSectTopRight,      new Rectangle(0 * tileSize, 3 * tileSize, tileSize, tileSize ) },
            { SpecificTileType.OuterCrossSectTopLeft,       new Rectangle(1 * tileSize, 3 * tileSize, tileSize, tileSize ) },
            { SpecificTileType.CrossSectCornerTopRight,     new Rectangle(2 * tileSize, 3 * tileSize, tileSize, tileSize ) },
            { SpecificTileType.CrossSectCornerTopLeft,      new Rectangle(3 * tileSize, 3 * tileSize, tileSize, tileSize ) },
            { SpecificTileType.AngleBottomLeft,             new Rectangle(4 * tileSize, 3 * tileSize, tileSize, tileSize ) },
            { SpecificTileType.FloorLight,                  new Rectangle(5 * tileSize, 3 * tileSize, tileSize, tileSize ) },
            { SpecificTileType.CrossSectIntersectUp,        new Rectangle(6 * tileSize, 3 * tileSize, tileSize, tileSize ) },
            { SpecificTileType.CrossSectEndBottom,          new Rectangle(0 * tileSize, 4 * tileSize, tileSize, tileSize ) },
            { SpecificTileType.CrossSectHorizontal,         new Rectangle(1 * tileSize, 4 * tileSize, tileSize, tileSize ) },
            { SpecificTileType.CrossSectVertical,           new Rectangle(2 * tileSize, 4 * tileSize, tileSize, tileSize ) },
            { SpecificTileType.CrossSectEndTop,             new Rectangle(3 * tileSize, 4 * tileSize, tileSize, tileSize ) },
            { SpecificTileType.AngleBottomRight,            new Rectangle(4 * tileSize, 4 * tileSize, tileSize, tileSize ) },
            { SpecificTileType.FloorDark,                   new Rectangle(5 * tileSize, 4 * tileSize, tileSize, tileSize ) },
            { SpecificTileType.CrossSectIntersectBottom,    new Rectangle(6 * tileSize, 4 * tileSize, tileSize, tileSize ) }
        };
        
        public Tile(Texture2D texture, int X, int Y, SpecificTileType specificTileType)
        {
            this.texture = texture;
            this.X = X * tileSize;
            this.Y = Y * tileSize;
            this.textureRectangle = tileRectangleLookup[specificTileType];
        }

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, position, textureRectangle, Color.White, 0f, Vector2.Zero, 1f, SpriteEffects.None, 1f);
        }

        public virtual void Update(GameTime gameTime)
        {

        }
    }
}
