﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SpaceGame.Items;
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

        public ItemMenu(Vector2 selectionBarPosition, Texture2D selectionBarTexture, bool selected) : base(selectionBarPosition, selectionBarTexture, selected)
        {
            itemHolders = new List<ItemHolder>();
            for (int i = 0; i < rows; ++i)
            {
                for (int j = 0; j < columns; ++j)
                {
                    itemHolders.Add(new ItemHolder(menuOffset + new Vector2(i * 24, j * 24)));
                }
            }
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            foreach (var itemHolder in itemHolders) itemHolder.Draw(spriteBatch);
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
    }
}
