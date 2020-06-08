using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
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
        public Rectangle clickRectangle { get { return new Rectangle((int)position.X, (int)position.Y, texture.Width, texture.Height); } }

        public ItemHolder(Vector2 position)
        {
            texture = LimitsEdgeGame.textures["item_slot"];
            this.position = position;
        }

        public bool AddItemToStack(Item item)
        {
            if (this.item != null && item.GetType().Equals(this.item.GetType()))
            {
                itemCount++;
                return true;
            }
            else return false;
        }

        public bool AddItem(Item item)
        {
            if (this.item == null)
            {
                this.item = item;
                itemCount = 1;
                return true;
            }
            else return false;
        }

        public void Draw(SpriteBatch spriteBatch)
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

        public void ClickAction()
        {
            Cursor cursor = LimitsEdgeGame.cursorManager.cursor;
            if (itemCount > 0) 
            {
                if (cursor.itemCount == 0) // Picking up item
                {
                    cursor.item = item;
                    cursor.itemCount = itemCount;
                    item = null;
                    itemCount = 0;
                } 
                else // Swapping item
                {
                    Item tempItem = cursor.item;
                    int tempItemCount = cursor.itemCount;
                    cursor.item = item;
                    cursor.itemCount = itemCount;
                    item = tempItem;
                    itemCount = tempItemCount;
                }
            } 
            else if (cursor.itemCount > 0) // Placing item
            {
                item = cursor.item;
                itemCount = cursor.itemCount;
                cursor.item = null;
                cursor.itemCount = 0;
            }
        }
    }
}
