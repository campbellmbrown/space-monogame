using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SpaceGame.Menus;
using SpaceGame.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceGame.Managers.InventoryStateManagers
{
    public class InventoryStateManager
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
        protected Vector2 menuSize;
        public InventoryEventManager eventManager;

        public InventoryStateManager()
        {
            eventManager = new InventoryEventManager();
            menuType = ShipMenuType.Items;
            itemMenu = new ItemMenu(Vector2.Zero, LimitsEdgeGame.textures["selection_bar"], true);
            menuSize = new Vector2(330, 142);
            LimitsEdgeGame.shipCamera.Position = (-LimitsEdgeGame.screenSize + menuSize) / 2f;
        }

        public void Update(GameTime gameTime)
        {
            eventManager.Update(gameTime);
            // LimitsEdgeGame.shipCamera.Position = Helper.RoundVector2(LimitsEdgeGame.shipCamera.Position, 1);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            switch (menuType)
            {
                case ShipMenuType.Items:
                    itemMenu.Draw(spriteBatch);
                    break;
            }
        }

        public void Click(Vector2 mousePosition)
        {
            switch (menuType)
            {
                case ShipMenuType.Items:
                    itemMenu.Click(mousePosition);
                    break;
            }
        }
    }
}
