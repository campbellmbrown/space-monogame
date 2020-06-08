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
        protected Vector2 itemPosition { get { return position + new Vector2(texture.Width + itemSize / 2f, texture.Height + itemSize / 2f); } }
        protected float zoom { get { return 3f / LimitsEdgeGame.currentZoom; } }
        protected float itemSize = 16;
        public Item item;
        public int itemCount = 0;

        public Cursor(Texture2D texture)
        {
            this.texture = texture;
            item = new Metal(Vector2.Zero, true);
            itemCount = 2;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, position, null, Color.White, 0f, Vector2.Zero, zoom, SpriteEffects.None, 0f);
            if (LimitsEdgeGame.gameState == GameState.Spaceship && itemCount > 0)
            {
                item.DrawPreview(spriteBatch, itemPosition, itemSize);
                if (itemCount > 1)
                {
                    spriteBatch.DrawString(LimitsEdgeGame.bitmapFonts["game_font_16"], itemCount.ToString(), itemPosition + new Vector2(1), Color.Black);
                    spriteBatch.DrawString(LimitsEdgeGame.bitmapFonts["game_font_16"], itemCount.ToString(), itemPosition, Color.White);
                }
            }
        }
    }
}
