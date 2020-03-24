using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SpaceGame.Models.WorldStateSprites;
using SpaceGame.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceGame.Sprites.WorldStateSprites
{
    public class MovingSprite : CollidableObject
    {
        protected Vector2 linearAcceleration;
        protected Vector2 linearFrictionAcceleration;
        protected float angularAcceleration;
        protected float angularFrictionAcceleration;
        protected float linearThrust = 0f;
        protected float angularThrust = 0f;
        public Vector2 facing { get { return new Vector2((float)Math.Cos(rotation - Math.PI / 2), (float)Math.Sin(rotation - Math.PI / 2f)); } }
        public Vector2 direction { get { return (linearVelocity.Length() == 0) ? Vector2.Zero : Vector2.Normalize(linearVelocity); } }
        protected int spinningDirection { get { return Math.Sign(angularVelocity); } }
        public Vector2 linearVelocity = Vector2.Zero;
        public float angularVelocity = 0f;
        public float linearDragCoefficient = 0f;
        public float angularDragCoefficient = 0f;
        public float maxLinearVelocity = 9999f;
        public float maxAngularVelocity = 9999f;
        public float maxLinearThrust = 0f;
        public float maxAngularThrust = 0f;

        public MovingSprite(Vector2 position, Texture2D texture) 
            : base(position, texture)
        {
        }

        public override void Update(GameTime gameTime)
        {
            Move((float)gameTime.ElapsedGameTime.TotalSeconds);
            base.Update(gameTime);
        }

        public virtual void Move(float t)
        {
            // Linear acceleration
            linearAcceleration = linearThrust * facing / mass;
            linearFrictionAcceleration = (linearThrust == 0) ? -linearDragCoefficient * (float)Math.Pow(linearVelocity.Length(), 2) * direction / mass : Vector2.Zero;
            Vector2 totalLinearAcceleration = linearAcceleration + linearFrictionAcceleration;

            // Angular acceleration
            angularAcceleration = angularThrust / mass;
            angularFrictionAcceleration = (angularThrust == 0) ? -angularDragCoefficient * (float)Math.Pow(Math.Abs(angularVelocity), 2) * spinningDirection / mass : 0;
            float totalAngularAcceleration = angularAcceleration + angularFrictionAcceleration;

            // Velocities
            linearVelocity += totalLinearAcceleration * t;
            angularVelocity += totalAngularAcceleration * t;
            if (linearVelocity.Length() > maxLinearVelocity) linearVelocity = Vector2.Normalize(linearVelocity) * maxLinearVelocity;
            angularVelocity = Helper.Clamp(angularVelocity, -maxAngularVelocity, maxAngularVelocity);

            // Position and rotation
            position += linearVelocity * t;
            rotation = Helper.SimplifyRadians(rotation + angularVelocity * t);
        }

        public void RandomizeVelocities(int maxLinVel, int maxAngVel)
        {
            linearVelocity = Helper.Vector2RandomDirecAndLength(maxLinVel);
            angularVelocity = LimitsEdgeGame.r.Next(-maxAngVel * 100, (maxAngVel * 100) + 1) / 100f;
        }
    }
}
