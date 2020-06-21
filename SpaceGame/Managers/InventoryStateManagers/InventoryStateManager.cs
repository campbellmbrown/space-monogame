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
        Equipment
    }

    public class InventoryStateManager
    {

        public InventoryType inventoryType;
        public ItemMenu itemMenu;
        public CrewMenu crewMenu;
        public EquipmentMenu equipmentMenu;
        protected Vector2 menuSize;
        public InventoryEventManager eventManager;

        public InventoryStateManager()
        {
            eventManager = new InventoryEventManager();
            inventoryType = InventoryType.Items;
            itemMenu = new ItemMenu(Vector2.Zero);
            crewMenu = new CrewMenu(new Vector2(0, 22));
            equipmentMenu = new EquipmentMenu(new Vector2(0, 44));
            menuSize = new Vector2(330, 142);
            LimitsEdgeGame.inventoryCamera.Position = (-LimitsEdgeGame.screenSize + menuSize) / 2f;
        }

        public void Update(GameTime gameTime)
        {
            itemMenu.Update(gameTime);
            crewMenu.Update(gameTime);
            equipmentMenu.Update(gameTime);
            eventManager.Update(gameTime);
            // LimitsEdgeGame.shipCamera.Position = Helper.RoundVector2(LimitsEdgeGame.shipCamera.Position, 1);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            itemMenu.Draw(spriteBatch);
            crewMenu.Draw(spriteBatch);
            equipmentMenu.Draw(spriteBatch);
        }

        public void Click(Vector2 mousePosition)
        {
            itemMenu.Click(mousePosition);
            crewMenu.Click(mousePosition);
            equipmentMenu.Click(mousePosition);
        }

        public void Hover(Vector2 mousePosition)
        {
            itemMenu.Hover(mousePosition);
            crewMenu.Hover(mousePosition);
            equipmentMenu.Hover(mousePosition);
        }

        public void SwitchInventoryType(InventoryType inventoryType)
        {
            this.inventoryType = inventoryType;
        }
    }
}
