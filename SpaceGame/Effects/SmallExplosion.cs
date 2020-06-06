using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceGame.Effects
{
    public class SmallExplosion : Particle
    {
        public SmallExplosion(Vector2 position, bool randomize) : base(position, LimitsEdgeGame.animations["small_explosion"], randomize)
        {
        }
    }
}
