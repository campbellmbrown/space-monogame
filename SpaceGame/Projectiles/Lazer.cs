using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceGame.Projectiles
{
    public class Lazer : Projectile 
    {
        public Lazer(Vector2 position, float rotation, Color color, Vector2 linearVelocity)
            : base(position, Game1.textures["lazer"], rotation, linearVelocity)
        {
            base.color = color;
        }
    }
}
