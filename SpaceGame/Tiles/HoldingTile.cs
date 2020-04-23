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
        protected SmallMenu menu;
        protected bool showMenu = false;
        public Rectangle interactionRectangle { get { return new Rectangle(X, Y, tileSize, tileSize); } }

        public HoldingTile(int X, int Y) : base(LimitsEdgeGame.textures["ship_display_tiles"], X, Y, SpecificTileType.AngleCrossSectTopLeft)
        {
            menu = new SmallMenu(8, 40);
            menu.AddMenuOption(3, position);
            menu.AddMenuOption(2, position);
            menu.AddMenuOption(1, position);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);
            if (showMenu) menu.Draw(spriteBatch);
        }

        public void SetMenuStatus(bool status)
        {
            showMenu = status;
        }
    }
}
