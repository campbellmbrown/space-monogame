using Microsoft.Xna.Framework.Graphics;
using SpaceGame.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceGame.Tiles
{
    public class HoldingTile : Tile
    {
        SmallMenu menu;

        public HoldingTile(int X, int Y) : base(LimitsEdgeGame.textures["ship_display_tiles"], X, Y, SpecificTileType.AngleCrossSectTopLeft)
        {
            menu = new SmallMenu();
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);
            menu.Draw(spriteBatch);
        }
    }
}
