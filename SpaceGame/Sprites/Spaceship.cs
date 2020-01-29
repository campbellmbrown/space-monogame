using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceGame.Sprites
{
    public class Spaceship : MovingSprite
    {
        protected Texture2D wingTexture;
        protected float wingRotation = 0f;
        protected int WingWidth { get { return wingTexture.Width; } }
        protected int WingHeight { get { return wingTexture.Height; } }
        protected Vector2 WingCenter { get { return new Vector2(WingWidth / 2f, WingHeight / 2f); } }

        public Spaceship(Vector2 position, Texture2D texture, Texture2D wingTexture, 
            float maxAcceleration, float maxVelocity, float maxAngularVelocity, float maxAngularAcceleration) 
            : base(position, texture, maxAcceleration, maxVelocity, maxAngularVelocity, maxAngularAcceleration)
        {
            this.wingTexture = wingTexture;
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(wingTexture, position, null, Color.White, wingRotation, WingCenter, scale, SpriteEffects.None, 0f);
            base.Draw(spriteBatch);
        }
    }
}
