using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Extended.BitmapFonts;
using SpaceGame.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceGame.Effects
{
    public class Cursor
    {
        protected Texture2D texture;
        protected Vector2 position { get { return LimitsEdgeGame.mousePosition; } }
        protected float zoom { get { return 3f / LimitsEdgeGame.currentZoom; } }
        protected float itemSize = 16;
        public Item item;
        public int itemCount = 0;

        public Cursor(Texture2D texture)
        {
            this.texture = texture;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (LimitsEdgeGame.gameState == GameState.Inventory && itemCount > 0)
            {
                item.DrawPreview(spriteBatch, position, itemSize);
                if (itemCount > 1)
                {
                    spriteBatch.DrawString(LimitsEdgeGame.bitmapFonts["game_font_16"], itemCount.ToString(), position + Vector2.One, Color.Black);
                    spriteBatch.DrawString(LimitsEdgeGame.bitmapFonts["game_font_16"], itemCount.ToString(), position, Color.White);
                }
            } else
            {
                spriteBatch.Draw(texture, position, null, Color.White, 0f, Vector2.Zero, zoom, SpriteEffects.None, 0f);
            }
        }

        public void RemoveItem()
        {
            item = null;
            itemCount = 0;
        }

        public void SetItem(Item item, int itemCount)
        {
            this.item = item;
            this.itemCount = itemCount;
        }
    }
}
