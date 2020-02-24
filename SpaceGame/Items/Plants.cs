using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceGame.Items
{
    public class Plants : Item
    {
        public Plants(Vector2 position, int count, bool randomize)
            : base(LimitsEdgeGame.textures["plants"], position, count, randomize)
        {
        }

        public Plants(Vector2 position, int count, Vector2 linearVelocity, float angularVelocity)
            : base(LimitsEdgeGame.textures["plants"], position, count, linearVelocity, angularVelocity)
        {
        }
    }
}
