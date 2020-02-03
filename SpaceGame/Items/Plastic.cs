using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceGame.Items
{
    public class Plastic : Item
    {
        public Plastic(Vector2 position, int count, bool randomize)
            : base(Game1.textures["plastic"], position, count, randomize)
        {
        }

        public Plastic(Vector2 position, int count, Vector2 linearVelocity, float angularVelocity)
            : base(Game1.textures["plastic"], position, count, linearVelocity, angularVelocity)
        {
        }
    }
}
