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
    public enum InventoryType
    {
        Items,
        Crew,
        Engines,
        Shields,
        Weapons
    }

    public class InventoryStateManager
    {

        public InventoryType inventoryType;
        public ItemMenu itemMenu;
        public CrewMenu crewMenu;
        protected Vector2 menuSize;
        public InventoryEventManager eventManager;

        public InventoryStateManager()
        {
            eventManager = new InventoryEventManager();
            inventoryType = InventoryType.Items;
            itemMenu = new ItemMenu(Vector2.Zero);
            crewMenu = new CrewMenu(new Vector2(0, 22));
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
            itemMenu.Draw(spriteBatch);
            crewMenu.Draw(spriteBatch);
        }

        public void Click(Vector2 mousePosition)
        {
            itemMenu.Click(mousePosition);
            crewMenu.Click(mousePosition);
        }

        public void SwitchInventoryType(InventoryType inventoryType)
        {
            this.inventoryType = inventoryType;
        }
    }
}
