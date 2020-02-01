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

        public Particle(Vector2 position, Texture2D texture, float lifeTime = 0f)
        {
            this.position = position;
            this.texture = texture;
            this.lifeTime = lifeTime;
        }

        public void Update(GameTime gameTime)
        {
            currentLifeTime += (float)gameTime.ElapsedGameTime.TotalSeconds;
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