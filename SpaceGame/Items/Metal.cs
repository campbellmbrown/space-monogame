using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceGame.Items
{
    public class Metal : Item
    {
        public Metal(Vector2 position, int count, bool randomize)
            : base(LimitsEdgeGame.textures["metal"], position, count, randomize)
        {
        }

        public Metal(Vector2 position, int count, Vector2 linearVelocity, float angularVelocity)
            : base(LimitsEdgeGame.textures["metal"], position, count, linearVelocity, angularVelocity)
        {
        }
    }
}
