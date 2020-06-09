using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Extended.BitmapFonts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceGame.Menus
{
    public class Menu
    {
        protected Vector2 selectionBarPosition;
        protected Texture2D selectionBarTexture;
        protected string selectionBarName;
        protected Rectangle selectionRectangle { get { return new Rectangle((int)selectionBarPosition.X, (int)selectionBarPosition.Y, selectionBarTexture.Width, selectionBarTexture.Height); } }
        protected Vector2 selectionBarTextPos;
        protected bool selected;
        protected float opacity { get { return selected ? 1f : 0.5f; } }
        protected Vector2 menuOffset = new Vector2(140, 0);

        public Menu(Vector2 selectionBarPosition, Texture2D selectionBarTexture, string selectionBarName, bool selected = false)
        {
            this.selectionBarPosition = selectionBarPosition;
            this.selectionBarTexture = selectionBarTexture;
            this.selectionBarName = selectionBarName;
            this.selected = selected;
            selectionBarTextPos = selectionBarPosition + new Vector2((selectionBarTexture.Height - 16) / 2f);
        }

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(selectionBarTexture, selectionBarPosition, null, Color.White * opacity, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0f);
            spriteBatch.DrawString(LimitsEdgeGame.bitmapFonts["game_font_16"], selectionBarName, selectionBarTextPos + Vector2.One, Color.Black);
            spriteBatch.DrawString(LimitsEdgeGame.bitmapFonts["game_font_16"], selectionBarName, selectionBarTextPos, Color.White);
        }

        public virtual void Click(Vector2 mousePosition)
        {

        }
    }
}
