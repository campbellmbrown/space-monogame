using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SpaceGame.Menus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceGame.Managers.ShipStateManagers
{
    public class ShipMenuManager 
    {
        public enum ShipMenuType
        {
            Items,
            Crew,
            Engines,
            Shields,
            Weapons
        }

        protected ShipMenuType menuType;
        public ItemMenu itemMenu;

        public ShipMenuManager()
        {
            menuType = ShipMenuType.Items;
            itemMenu = new ItemMenu(Vector2.Zero, LimitsEdgeGame.textures["selection_bar"], true);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            itemMenu.Draw(spriteBatch);
        }


    }
}
