using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SpaceGame.Sprites.WorldStateSprites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceGame.Models.WorldStateSprites
{
    public class CollidableObject : WSSprite
    {
        public Rectangle collisionRectangle { get { return new Rectangle((int)(position.X - Width / 2f), (int)(position.Y - Height / 2f), Width, Height); } }
        public int currentHealth = 1;
        public int maxHealth = 1;

        public CollidableObject(Vector2 position, Texture2D texture) : base(position, texture)
        {
        }

        public bool CheckCollision(Rectangle collisionRectangle)
        {
            if (this.collisionRectangle.Intersects(collisionRectangle))
                return true;
            else
                return false;
        }

        public bool DepleteHealth(int damage)
        {
            currentHealth -= damage;
            if (currentHealth <= 0) return true;
            return false;
        }

        public virtual void BreakAction()
        {

        }
    }
}
