using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceGame.Items
{
    /// <summary>
    /// Base class for Items.
    /// </summary>
    public class Item
    {
        protected Vector2 position;
        protected Texture2D texture;
        protected int count;
        protected Vector2 linearAcceleration = Vector2.Zero;
        protected Vector2 linearVelocity = Vector2.Zero;
        protected float angularAcceleration = 0f;
        protected float angularVelocity = 0f;
        protected float rotation = 0f;
        public Vector2 linearDirection { get { return (linearVelocity.Length() == 0) ? Vector2.Zero : Vector2.Normalize(linearVelocity); } }
        protected float angularDirection { get { return Math.Sign(angularVelocity); } }
        protected Vector2 center { get { return new Vector2(texture.Width / 2f, texture.Height / 2f); } }
        public float linearDragCoefficient = 0f;
        public float angularDragCoefficient = 0f;

        /// <summary>
        /// Creates a new instance of the Item class, with specified parameters.
        /// </summary>
        /// <param name="texture">Texture of the item.</param>
        /// <param name="position">X and Y starting coordinates.</param>
        /// <param name="count">The number of that specified item in this 'stack'.</param>
        /// <param name="randomize">Determines if the velocities are random.</param>
        public Item(Texture2D texture, Vector2 position, int count, bool randomize)
        {
            this.position = position;
            this.texture = texture;
            this.count = count;
            if (randomize)
            {
                linearVelocity = new Vector2(LimitsEdgeGame.r.Next(-50, 51), LimitsEdgeGame.r.Next(-50, 51));
                angularVelocity = LimitsEdgeGame.r.Next(-628, 629) / 100f;
            }
            else
            {
                linearVelocity = Vector2.Zero;
                angularVelocity = 0f;
            }
        }

        /// <summary>
        /// Creates a new instance of the Item class, with specified parameters.
        /// </summary>
        /// <param name="texture">Texture of the item.</param>
        /// <param name="position">X and Y starting coordinates.</param>
        /// <param name="count">The number of that specified item in this 'stack'.</param>
        /// <param name="linearVelocity">X and Y linear velocites of the item.</param>
        /// <param name="angularVelocity">Angular velocity of the item.</param>
        public Item(Texture2D texture, Vector2 position, int count, Vector2 linearVelocity, float angularVelocity)
        {
            this.position = position;
            this.texture = texture;
            this.count = count;
            this.linearVelocity = linearVelocity;
            this.angularVelocity = angularVelocity;
        }

        /// <summary>
        /// Updates the item.
        /// </summary>
        /// <param name="gameTime">GameTime instance.</param>
        public void Update(GameTime gameTime)
        {
            float t = (float)gameTime.ElapsedGameTime.TotalSeconds;
            Move(t);
        }

        /// <summary>
        /// Draws the item.
        /// </summary>
        /// <param name="spriteBatch">SpriteBatch instance.</param>
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, position, null, Color.White, rotation, center, 1f, SpriteEffects.None, 1f);
        }

        /// <summary>
        /// Moves the item, based on the item's accelerations and velocities.
        /// </summary>
        /// <param name="t">Time since the last tick.</param>
        public void Move(float t)
        {
            // Friction
            linearAcceleration = -linearDragCoefficient * (float)Math.Pow(linearVelocity.Length(), 2f) * linearDirection;
            angularAcceleration = -linearDragCoefficient * (float)Math.Pow(angularVelocity, 2f) * angularDirection;
            // Velocities and positions
            linearVelocity += linearAcceleration * t;
            angularVelocity += angularAcceleration * t;
            position += linearVelocity * t;
            rotation += angularVelocity * t;
        }
    }
}
