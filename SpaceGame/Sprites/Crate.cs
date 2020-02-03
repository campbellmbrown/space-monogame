using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceGame.Sprites
{
    public class Crate : MovingSprite
    {
        public Crate(Vector2 position, Vector2 linearVelocity, float angularVelocity) : base(position, Game1.textures["crate"])
        {
            base.linearVelocity = linearVelocity;
            base.angularVelocity = angularVelocity;
        }

        public Crate(Vector2 position, bool randomize) : base(position, Game1.textures["crate"])
        {
            if (randomize)
            {
                linearVelocity = new Vector2(Game1.r.Next(-50, 51), Game1.r.Next(-50, 51));
                angularVelocity = Game1.r.Next(-628, 629) / 100f;
            }
            else
            {
                linearVelocity = Vector2.Zero;
                angularVelocity = 0f;
            }
        }
    }
}