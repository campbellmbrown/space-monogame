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
        protected Vector2 position;
        protected Texture2D texture;
        protected readonly float scale = 1f;
        protected float rotation;
        protected Vector2 Center { get { return new Vector2(texture.Width / 2f, texture.Height / 2f); } }

        public Sprite(Vector2 position, Texture2D texture)
        {
            this.position = position;
            this.texture = texture;
            rotation = 0f;
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
