using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceGame.Sprites
{
    public class Sprite
    {
        public Vector2 position;
        protected Texture2D texture;
        protected readonly float scale = 1f;
        protected float rotation = 0f;
        protected int Width { get { return texture.Width; } }
        protected int Height { get { return texture.Height; } }
        protected Vector2 Center { get { return new Vector2(Width / 2f, Height / 2f); } }

        public Sprite(Vector2 position, Texture2D texture)
        {
            this.position = position;
            this.texture = texture;
        }

        public virtual void Update(GameTime gameTime)
        {

        }

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, position, null, Color.White, rotation, Center, scale, SpriteEffects.None, 0f);
        }
    }
}
