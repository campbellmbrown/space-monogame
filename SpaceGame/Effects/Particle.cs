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
    public enum ParticleDestroyType
    {
        LifeTime,
        Fade,
        Shrink,
        Other
    }

    public class Particle
    {
        private Vector2 _position;
        protected Vector2 position { get { return _position; } set { _position = value; if (_hasAnimation) animationManager.position = value; } }
        protected Texture2D texture;
        protected AnimationManager animationManager;
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
        protected ParticleDestroyType particleDestroyType;
        protected float opacity = 1f;
        protected float scale = 1f;

        public float lifeTime = 999f;
        public float fadeTime = 10f;
        public float shrinkTime = 10f;

        public Particle(Vector2 position, Texture2D texture, bool randomize, ParticleDestroyType particleDestroyType)
        {
            this.position = position;
            this.texture = texture;
            this.particleDestroyType = particleDestroyType;
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
            if (particleDestroyType == ParticleDestroyType.Fade) opacity -= t / fadeTime;
            if (particleDestroyType == ParticleDestroyType.Shrink) scale -= t / shrinkTime;
            if (_hasAnimation) animationManager.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (_hasAnimation) animationManager.Draw(spriteBatch, rotation);
            else if (_hasTexture) spriteBatch.Draw(texture, position, textureRectangle, Color.White * opacity, rotation, center, scale, SpriteEffects.None, 0f);
        }

        public bool CheckToDestroy()
        {
            bool toDestroy;
            switch (particleDestroyType)
            {
                case ParticleDestroyType.LifeTime:
                    toDestroy = ExceedsLifeTime();
                    break;
                case ParticleDestroyType.Fade:
                    toDestroy = FadedToNothing();
                    break;
                case ParticleDestroyType.Shrink:
                    toDestroy = ShrankToNothing();
                    break;
                default:
                    toDestroy = false;
                    break;
            }
            return toDestroy;
        }

        public bool ExceedsLifeTime()
        {
            if (currentLifeTime > lifeTime)
                return true;
            return false;
        }

        public bool FadedToNothing()
        {
            if (opacity <= 0)
                return true;
            return false;
        }

        public bool ShrankToNothing()
        {
            if (scale <= 0)
                return true;
            return false;
        }
    }

}