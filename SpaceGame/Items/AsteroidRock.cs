using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceGame.Items
{
    public class AsteroidRock : Item
    {
        public AsteroidRock(Vector2 position, bool randomize = true)
            : base(LimitsEdgeGame.textures["asteroid_rock"], position, "Asteroid Rock", randomize)
        {
        }

        public AsteroidRock(Vector2 position, Vector2 linearVelocity, float angularVelocity)
            : base(LimitsEdgeGame.textures["asteroid_rock"], position, linearVelocity, angularVelocity, "Asteroid Rock")
        {
        }
    }
}
