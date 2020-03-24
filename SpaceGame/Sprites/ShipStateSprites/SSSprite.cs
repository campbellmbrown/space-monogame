using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SpaceGame.Managers;
using SpaceGame.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceGame.Sprites.ShipStateSprites
{
    public class SSSprite
    {
        public Vector2 position 
        { 
            get 
            { 
                return _position; 
            } 
            set 
            { 
                if (hasAnimation) 
                    animationManager.position = value; 
                _position = value; 
            } 
        }
        private Vector2 _position;
        protected Texture2D texture;
        protected Animation animation;
        protected AnimationManager animationManager;
        protected bool hasAnimation { get { return animationManager != null; } }
        protected bool hasTexture { get { return texture != null; } }
        private Vector2 bottomMiddle { get { return new Vector2(texture.Width / 2f, texture.Height); } }

        public SSSprite(Vector2 position, Texture2D texture)
        {
            this.position = position;
            this.texture = texture;
        }

        public SSSprite(Vector2 position, Animation animation)
        {
            this.position = position;
            this.animation = animation;
            animationManager = new AnimationManager(animation, AnimationManager.RotationOrigin.BottomMiddle, 0.5f);
        }

        public virtual void Update(GameTime gameTime)
        {
            if (hasAnimation) animationManager.Update(gameTime);
        }

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            if (hasAnimation) animationManager.Draw(spriteBatch);
            else if (hasTexture) spriteBatch.Draw(texture, position, null, Color.White, 0f, bottomMiddle, 0.5f, SpriteEffects.None, 0f);
        }
    }
}
