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
    public class CollidableObject : Sprite
    {
        public Rectangle collisionRectangle { get { return new Rectangle((int)(position.X - Width / 2f), (int)(position.Y - Height / 2f), Width, Height); } }

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

        public virtual void BreakAction()
        {

        }
    }
}
