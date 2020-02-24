using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceGame.Effects
{
    /// <summary>
    /// Smoke class - inherits the Particle class.
    /// </summary>
    public class Smoke : Particle
    {
        /// <summary>
        /// Creates a new instance of the Smoke class, with specified parameters.
        /// </summary>
        /// <param name="position">X and Y starting coordinates.</param>
        /// <param name="randomize">Determines if the velocities are random.</param>
        public Smoke(Vector2 position, bool randomize) : base(position, LimitsEdgeGame.animations["smoke"], randomize)
        {
        }
    }
}
