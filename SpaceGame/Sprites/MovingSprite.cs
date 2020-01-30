using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SpaceGame.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceGame.Sprites
{
    public class MovingSprite : Sprite
    {
        protected float linearAcceleration;
        protected float angularVelocity;
        protected float angularAcceleration;
        protected float linearThrust = 0;
        protected float angularThrust = 0;
        public Vector2 direction { get { return new Vector2((float)Math.Cos(rotation - Math.PI / 2), (float)Math.Sin(rotation - Math.PI / 2f)); } }
        public float linearVelocity;
        public float linearDragCoefficient = 0;
        public float angularDragCoefficient = 0;
        public float maxLinearVelocity = 0;
        public float maxAngularVelocity = 0;
        public float maxLinearThrust = 0;
        public float maxAngularThrust = 0;

        public MovingSprite(Vector2 position, Texture2D texture) 
            : base(position, texture)
        {
        }

        public virtual void Move(float t)
        {
            linearAcceleration = (linearThrust - linearDragCoefficient * (float)Math.Pow(Math.Abs(linearVelocity), 2)) / mass;
            angularAcceleration = (angularThrust - angularDragCoefficient * (float)Math.Pow(Math.Abs(angularVelocity), 2)) / mass;
            linearVelocity += linearAcceleration * t;
            angularVelocity += angularAcceleration * t;
            linearVelocity = Helper.Clamp(linearVelocity, -maxLinearVelocity, maxLinearVelocity);
            angularVelocity = Helper.Clamp(angularVelocity, -maxAngularVelocity, maxAngularVelocity);
            position += linearVelocity * direction * t;
            rotation += angularVelocity * t;
        }
    }
}
