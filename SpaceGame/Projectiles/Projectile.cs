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
    /// <summary>
    /// Base class for projectiles.
    /// </summary>
    public class Projectile
    {
        public Rectangle collisionRectangle { get { return new Rectangle((int)position.X, (int)position.Y, Width, Height); } }
        public Vector2 position;
        public int damage;
        public Vector2 explosionVelocity { get { return (linearVelocity.Length() != 0) ? Vector2.Normalize(linearVelocity) * 20f : Vector2.Zero; } }

        protected Texture2D texture;
        protected Vector2 linearVelocity;
        protected float rotation;
        protected int Width { get { return texture.Width; } }
        protected int Height { get { return texture.Height; } }
        protected Vector2 center { get { return new Vector2(texture.Width / 2f, texture.Height / 2f); } }
        protected Color color = Color.White;

        /// <summary>
        /// Creates an instance of the Projectile class.
        /// </summary>
        /// <param name="position">X and Y position of the projectile.</param>
        /// <param name="texture">Texture of the projectile.</param>
        /// <param name="rotation">Rotation of the projectile.</param>
        /// <param name="linearVelocity">X and Y linear velocities of the projectile.</param>
        /// <param name="damage">Damage of the projectile.</param>
        public Projectile(Vector2 position, Texture2D texture, float rotation, Vector2 linearVelocity, int damage = 0)
        {
            this.position = position;
            this.texture = texture;
            this.rotation = rotation;
            this.linearVelocity = linearVelocity;
            this.damage = damage;
        }

        /// <summary>
        /// Updates the projectile.
        /// </summary>
        /// <param name="gameTime">GameTime instance.</param>
        public void Update(GameTime gameTime)
        {
            float t = (float)gameTime.ElapsedGameTime.TotalSeconds;
            position += linearVelocity * t;
        }

        /// <summary>
        /// Draws the projectile.
        /// </summary>
        /// <param name="spriteBatch">SpriteBatch instance.</param>
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, position, null, color, rotation, center, 1f, SpriteEffects.None, 1f);
        }
    }
}
