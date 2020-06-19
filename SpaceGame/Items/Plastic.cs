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
        public Plastic(Vector2 position, bool randomize = true)
            : base(LimitsEdgeGame.textures["plastic"], position, "Plastic", randomize)
        {
        }

        public Plastic(Vector2 position, Vector2 linearVelocity, float angularVelocity)
            : base(LimitsEdgeGame.textures["plastic"], position, linearVelocity, angularVelocity, "Plastic")
        {
        }
    }
}
