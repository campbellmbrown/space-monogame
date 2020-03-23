using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceGame.Tiles
{
    public class ShipWall : Tile
    {
        public ShipWall(Texture2D texture, int X, int Y, SpecificTileType specificTileType) : base(texture, X, Y, specificTileType)
        {
        }
    }
}
