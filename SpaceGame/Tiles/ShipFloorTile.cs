using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceGame.Tiles
{
    public class ShipFloorTile : Tile
    {
        public int floorID;

        public ShipFloorTile(Texture2D texture, int X, int Y, SpecificTileType specificTileType, int floorID) : base(texture, X, Y, specificTileType)
        {
            this.floorID = floorID;
        }
    }
}
