using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceGame.Effects
{
    public class Shadow
    {
        Vector2 position;
        Texture2D texture;
        float opacity = 0.1f;
        float scale = 1f;
        Vector2 center { get { return new Vector2(texture.Width / 2f, texture.Height / 2f); } }

        public Shadow(Texture2D texture, float opacity)
        {
            this.texture = texture;
            this.opacity = opacity;
        }

        public void Update(Vector2 position, float desiredWidth)
        {
            this.position = position;
            scale = desiredWidth / texture.Width;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, position, null, Color.White * opacity, 0f, center, scale, SpriteEffects.None, 0f);
        }
    }
}
