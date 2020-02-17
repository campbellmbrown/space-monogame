using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SpaceGame.Managers;
using SpaceGame.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceGame.Effects
{
    public class Particle
    {
        private Vector2 _position;
        protected Vector2 position { get { return _position; } set { _position = value; if (_hasAnimation) animationManager.position = value; } }
        protected Texture2D texture;
        protected AnimationManager animationManager;
        protected float lifeTime;
        protected float currentLifeTime;
        public float rotation;
        public float angularVelocity;
        public Vector2 linearVelocity;
        protected Vector2 center 
        { 
            get 
            {
                if (!hasTextureRectangle) return new Vector2(texture.Width / 2f, texture.Height / 2f);
                else return new Vector2( textureRectangle.Width / 2f, textureRectangle.Height / 2f );
            } 
        }
        public Rectangle textureRectangle;
        private bool _hasAnimation { get { return animationManager != null; } }
        private bool _hasTexture { get { return texture != null; } }
        protected bool hasTextureRectangle { get { return textureRectangle != null; } }

        public Particle(Vector2 position, Texture2D texture, bool randomize, float lifeTime = 999f)
        {
            this.position = position;
            this.texture = texture;
            this.lifeTime = lifeTime;
            if (randomize) RandomizeVelocities();
        }

        public Particle(Vector2 position, Animation animation, bool randomize)
        {
            animationManager = new AnimationManager(animation);
            this.position = position;
            this.lifeTime = animation.frameCount * animation.frameSpeed;
            if (randomize) RandomizeVelocities();
        }

        protected void RandomizeVelocities()
        {
            angularVelocity = Game1.r.Next(-10, 11);
            linearVelocity = new Vector2(Game1.r.Next(-10, 11), Game1.r.Next(-10, 11));
        }

        public void Update(GameTime gameTime)
        {
            float t = (float)gameTime.ElapsedGameTime.TotalSeconds;
            position += linearVelocity * t;
            rotation += angularVelocity * t;
            currentLifeTime += t;
            if (_hasAnimation)
            {
                animationManager.Update(gameTime);
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (_hasAnimation) animationManager.Draw(spriteBatch, rotation);
            else if (_hasTexture) spriteBatch.Draw(texture, position, textureRectangle, Color.White, rotation, center, 1f, SpriteEffects.None, 0f);
        }

        public bool ExceedsLifeTime()
        {
            if (currentLifeTime > lifeTime)
                return true;
            return false;
        }
    }

}