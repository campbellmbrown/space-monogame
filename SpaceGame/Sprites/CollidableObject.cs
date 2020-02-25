using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Extended;
using SpaceGame.Sprites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceGame.Models
{
    /// <summary>
    /// Class used for collidable objects. Inherits the sprite class.
    /// </summary>
    public class CollidableObject : Sprite
    {
        public Rectangle collisionRectangle { get { return new Rectangle((int)(position.X - Width / 2f), (int)(position.Y - Height / 2f), Width, Height); } }
        public int currentHealth = 1;
        public int maxHealth = 1;

        /// <summary>
        /// Creates an instance of the CollidableObject class.
        /// </summary>
        /// <param name="position">Position of the object.</param>
        /// <param name="texture">Texture of the object.</param>
        public CollidableObject(Vector2 position, Texture2D texture) : base(position, texture)
        {
        }

        /// <summary>
        /// Will return true if the object's collision box is intersecting a rectangle.
        /// </summary>
        /// <param name="collisionRectangle">The rectangle to check collision with.</param>
        /// <returns></returns>
        public bool CheckCollision(Rectangle collisionRectangle)
        {
            if (this.collisionRectangle.Intersects(collisionRectangle))
                return true;
            else
                return false;
        }

        /// <summary>
        /// Depletes the sprite health by a certain amount of damange. Will return true when the health is fully depleted.
        /// </summary>
        /// <param name="damage"></param>
        /// <returns></returns>
        public bool DepleteHealth(int damage)
        {
            currentHealth -= damage;
            if (currentHealth <= 0) return true;
            return false;
        }

        /// <summary>
        /// Action to be taken when the object is broken.
        /// </summary>
        public virtual void BreakAction()
        {

        }
    }
}
