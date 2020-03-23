using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceGame.Tiles
{
    public class ShipFloor : Tile
    {
        List<Vector2> connectedTilePositions;

        public ShipFloor(Texture2D texture, int X, int Y, SpecificTileType specificTileType) : base(texture, X, Y, specificTileType)
        {
            connectedTilePositions = new List<Vector2>();
        }
    }
}
