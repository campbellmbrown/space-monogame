using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceGame.Sprites
{
    public class Crate : ItemCarryingSprite
    {
        public Crate(Vector2 position, Vector2 linearVelocity, float angularVelocity) 
            : base(position, Game1.textures["crate"], linearVelocity, angularVelocity)
        {
        }

        public Crate(Vector2 position, bool randomize) 
            : base(position, Game1.textures["crate"], randomize)
        {
        }
    }
}