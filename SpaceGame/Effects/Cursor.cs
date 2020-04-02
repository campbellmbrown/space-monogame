using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
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

        public Cursor(Texture2D texture)
        {
            this.texture = texture;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, position, null, Color.White, 0f, Vector2.Zero, zoom, SpriteEffects.None, 0f);
        }
    }
}
