using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceGame.Effects
{
    public class Particle
    {
        protected Vector2 position;
        protected Texture2D texture;
        protected float lifeTime;
        protected float currentLifeTime;
        protected float rotation;
        protected float angularVelocity;
        protected Vector2 linearVelocity;

        public Particle(Vector2 position, Texture2D texture, float lifeTime = 0f)
        {
            this.position = position;
            this.texture = texture;
            this.lifeTime = lifeTime;
            angularVelocity = Game1.r.Next(-10, 11);
            linearVelocity = new Vector2(Game1.r.Next(-10, 11), Game1.r.Next(-10, 11));
        }

        public void Update(GameTime gameTime)
        {
            float t = (float)gameTime.ElapsedGameTime.TotalSeconds;
            position += linearVelocity * t;
            rotation += angularVelocity * t;
            currentLifeTime += t;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, position, null, Color.White, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0f);
        }

        public bool ExceedsLifeTime()
        {
            if (currentLifeTime > lifeTime)
                return true;
            return false;
        }
    }

}