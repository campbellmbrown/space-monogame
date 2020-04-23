using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceGame.Tiles
{
    public class PlaceableTile : Tile
    {
        public PlaceableTile(int X, int Y) : base(LimitsEdgeGame.textures["ship_display_tiles"], X, Y, SpecificTileType.AngleCrossSectTopLeft)
        {
        }
    }
}
