using Microsoft.Xna.Framework;
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
        public SmallMenu menu;
        public Rectangle interactionRectangle { get { return new Rectangle(X, Y, tileSize, tileSize); } }
        protected Vector2 menuPositon { get { return position + new Vector2(tileSize / 2f, 0); } }

        public HoldingTile(int X, int Y) : base(LimitsEdgeGame.textures["ship_display_tiles"], X, Y, SpecificTileType.AngleCrossSectTopLeft)
        {
            menu = new SmallMenu(6, 40);
            menu.AddMenuOption(1, menuPositon, "Option 1", Color.DarkGreen);
            menu.AddMenuOption(2, menuPositon, "Option 2", Color.DarkMagenta);
            menu.AddMenuOption(3, menuPositon, "Option 3", Color.DarkSlateBlue);
        }
    }
}
