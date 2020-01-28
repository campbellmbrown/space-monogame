using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceGame.Sprites
{
    public class MovingSprite : Sprite
    {
        protected Vector2 acceleration;
        protected Vector2 velocity;
        protected float angularVelocity;
        protected float angularAcceleration;
        protected float maxAcceleration;
        protected float maxVelocity;
        protected float maxAngularVelocity;
        protected float maxAngularAcceleration;
        protected Vector2 Direction { get { return new Vector2((float)Math.Cos(rotation - Math.PI / 2), (float)Math.Sin(rotation - Math.PI / 2f)); } }

        public MovingSprite(Vector2 position, Texture2D texture, float maxAcceleration, float maxVelocity, float maxAngularVelocity, float maxAngularAcceleration) 
            : base(position, texture)
        {
            this.maxAcceleration = maxAcceleration;
            this.maxVelocity = maxVelocity;
            this.maxAngularAcceleration = maxAngularAcceleration;
            this.maxAngularVelocity = maxAngularVelocity;
        }

        public void Move(float t)
        {
            velocity += acceleration * t;
            position += velocity * t;
            angularVelocity += angularAcceleration * t;
            rotation += angularVelocity * t;
        }
    }
}
