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
        protected float maxAcceleration;
        protected float maxSpeed;

        public MovingSprite(Vector2 position, Texture2D texture, float maxAcceleration, float maxSpeed) : base(position, texture)
        {
            this.maxAcceleration = maxAcceleration;
            this.maxSpeed = maxSpeed;
        }

        public void Move(float t)
        {
            velocity += acceleration * t;
            position += velocity * t;
        }
    }
}
