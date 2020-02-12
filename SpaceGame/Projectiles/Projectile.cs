using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Extended;
using SpaceGame.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceGame.Projectiles
{
    public class Projectile
    {
        public Rectangle collisionRectangle { get { return new Rectangle((int)position.X, (int)position.Y, Width, Height); } }
        protected Texture2D texture;
        protected Vector2 position;
        protected Vector2 linearVelocity;
        protected float rotation;
        protected int Width { get { return texture.Width; } }
        protected int Height { get { return texture.Height; } }
        protected Vector2 center { get { return new Vector2(texture.Width / 2f, texture.Height / 2f); } }
        protected Color color = Color.White;

        public Projectile(Vector2 position, Texture2D texture, float rotation, Vector2 linearVelocity)
        {
            this.position = position;
            this.texture = texture;
            this.rotation = rotation;
            this.linearVelocity = linearVelocity;
        }

        public void Update(GameTime gameTime)
        {
            float t = (float)gameTime.ElapsedGameTime.TotalSeconds;
            position += linearVelocity * t;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, position, null, color, rotation, center, 1f, SpriteEffects.None, 1f);
        }
    }
}
