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
        public Plants(Vector2 position, bool randomize)
            : base(LimitsEdgeGame.textures["plants"], position, randomize)
        {
        }

        public Plants(Vector2 position, Vector2 linearVelocity, float angularVelocity)
            : base(LimitsEdgeGame.textures["plants"], position, linearVelocity, angularVelocity)
        {
        }
    }
}
