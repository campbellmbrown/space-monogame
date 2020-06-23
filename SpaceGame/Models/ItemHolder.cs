using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonoGame.Extended.BitmapFonts;
using SpaceGame.Effects;
using SpaceGame.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceGame.Models
{
    public class ItemHolder
    {
        protected Texture2D texture;
        public Item item;
        public int itemCount = 0;
        protected Vector2 position;
        protected int itemSize = 16;
        Vector2 center { get { return new Vector2(texture.Width / 2f, texture.Height / 2f); } }
        public Rectangle hoverRectangle { get { return new Rectangle((int)position.X, (int)position.Y, texture.Width, texture.Height); } }

        // Constructor
        public ItemHolder(Vector2 position)
        {
            texture = LimitsEdgeGame.textures["item_slot"];
            this.position = position;
        }

        // Draw method
        public virtual void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, position, null, Color.White, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0f);
            if (itemCount > 0)
            {
                item.DrawPreview(spriteBatch, position + center, itemSize);
                if (itemCount > 1) 
                {
                    spriteBatch.DrawString(LimitsEdgeGame.bitmapFonts["game_font_16"], itemCount.ToString(), position + Vector2.One, Color.Black);
                    spriteBatch.DrawString(LimitsEdgeGame.bitmapFonts["game_font_16"], itemCount.ToString(), position, Color.White);
                }
            }
        }

        // For removing items
        public void RemoveItem()
        {
            item = null;
            itemCount = 0;
        }

        // For adding items to a stack of already existing items
        public bool AddItemToStack(Item item, int itemCount)
        {
            if (this.itemCount > 0 && item.GetType().Equals(this.item.GetType()))
            {
                this.itemCount += itemCount;
                return true;
            }
            else return false;
        }

        // Sets the item in the item holder
        public void SetItem(Item item, int itemCount)
        {
            this.item = item;
            this.itemCount = itemCount;
        }

        // Attempt to place item in slot, will only place if empty
        public bool TryFillEmptySlot(Item item, int itemCount)
        {
            if (this.itemCount == 0)
            {
                SetItem(item, itemCount);
                return true;
            }
            return false;
        }

        public virtual void ClickAction()
        {
            Cursor cursor = LimitsEdgeGame.cursorManager.cursor;
            if (itemCount > 0) // The item holder has an item
            {
                if (cursor.itemCount == 0) // Picking up item
                {
                    cursor.SetItem(item, itemCount);
                    RemoveItem();
                } 
                else if (AddItemToStack(cursor.item, cursor.itemCount)) // Adding item onto stack
                {
                    cursor.RemoveItem();
                }
                else // Swapping item
                {
                    Item tempItem = cursor.item;
                    int tempItemCount = cursor.itemCount;
                    cursor.SetItem(item, itemCount);
                    SetItem(tempItem, tempItemCount);
                    //item = tempItem;
                    //itemCount = tempItemCount;
                }
            } 
            else if (cursor.itemCount > 0) // Placing item
            {
                SetItem(cursor.item, cursor.itemCount);
                cursor.RemoveItem();
            }
        }

        // For cursor clicking
        public bool CheckHover(Vector2 mousePosition)
        {
            return hoverRectangle.Contains(mousePosition);
        }

        // For label displaying
        public bool CheckItemHover(Vector2 mousePosition)
        {
            if (itemCount > 0)
            {
                return CheckHover(mousePosition);
            }
            return false;
        }
    }
}
