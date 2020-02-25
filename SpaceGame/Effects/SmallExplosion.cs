using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceGame.Effects
{
    /// <summary>
    /// SmallExplosion class - inherits the Particle class.
    /// </summary>
    public class SmallExplosion : Particle
    {
        /// <summary>
        /// Creates a new instance of the SmallExplosion class, with specified parameters.
        /// </summary>
        /// <param name="position">X and Y starting coordinates.</param>
        /// <param name="randomize">Determines if the velocities are random.</param>
        public SmallExplosion(Vector2 position, bool randomize) : base(position, LimitsEdgeGame.animations["small_explosion"], randomize)
        {
        }
    }
}
