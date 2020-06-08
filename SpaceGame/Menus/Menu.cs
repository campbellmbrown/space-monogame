using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
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
        protected Rectangle selectionRectangle { get { return new Rectangle((int)selectionBarPosition.X, (int)selectionBarPosition.Y, selectionBarTexture.Width, selectionBarTexture.Height); } }
        protected bool selected = false;
        protected float opacity { get { return selected ? 1f : 0.5f; } }
        protected Vector2 menuOffset = new Vector2(140, 0);

        public Menu(Vector2 selectionBarPosition, Texture2D selectionBarTexture, bool selected)
        {
            this.selectionBarPosition = selectionBarPosition;
            this.selectionBarTexture = selectionBarTexture;
            this.selected = selected;
        }

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(selectionBarTexture, selectionBarPosition, null, Color.White * opacity, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0f);
        }

        public virtual void Click(Vector2 mousePosition)
        {

        }
    }
}
