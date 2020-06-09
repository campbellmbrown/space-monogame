using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SpaceGame.Items;
using SpaceGame.Managers.InventoryStateManagers;
using SpaceGame.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceGame.Menus
{
    public class ItemMenu : Menu
    {
        protected int rows = 6;
        protected int columns = 8;
        protected List<ItemHolder> itemHolders;

        public ItemMenu(Vector2 selectionBarPosition) : base(selectionBarPosition, "Items", InventoryType.Items)
        {
            itemHolders = new List<ItemHolder>();
            for (int i = 0; i < rows; ++i)
            {
                for (int j = 0; j < columns; ++j)
                {
                    itemHolders.Add(new ItemHolder(menuOffset + new Vector2(j * 24, i * 24)));
                }
            }
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            if (selected)
            {
                foreach (var itemHolder in itemHolders) itemHolder.Draw(spriteBatch);
            }
            base.Draw(spriteBatch);
        }

        public void AddItem(Item item)
        {
            foreach (var itemHolder in itemHolders)
            {
                if (itemHolder.AddItemToStack(item))
                    return;
            }
            foreach (var itemHolder in itemHolders)
            {
                if (itemHolder.AddItem(item))
                    return;
            }
        }

        public override void Click(Vector2 mousePosition)
        {
            if (selected)
            {
                foreach (var itemHolder in itemHolders)
                {
                    if (itemHolder.clickRectangle.Contains(mousePosition))
                    {
                        itemHolder.ClickAction();
                    }
                }
            }
            base.Click(mousePosition);
        }
    }
}
