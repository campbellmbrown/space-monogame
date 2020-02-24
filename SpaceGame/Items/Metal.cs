using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceGame.Items
{
    /// <summary>
    /// Metal class - inherits the Item class.
    /// </summary>
    public class Metal : Item
    {
        /// <summary>
        /// Creates a new instance of the Metal class, with specified parameters.
        /// </summary>
        /// <param name="position">X and Y starting coordinates.</param>
        /// <param name="count">The number of metal items in this 'stack'.</param>
        /// <param name="randomize">Determines if the velocities are random.</param>
        public Metal(Vector2 position, int count, bool randomize)
            : base(LimitsEdgeGame.textures["metal"], position, count, randomize)
        {
        }

        /// <summary>
        /// Creates a new instance of the Item class, with specified parameters.
        /// </summary>
        /// <param name="position">X and Y starting coordinates.</param>
        /// <param name="count">The number of metal items in this 'stack'.</param>
        /// <param name="linearVelocity">X and Y linear velocites of the metal item.</param>
        /// <param name="angularVelocity">Angular velocity of the metal item.</param>
        public Metal(Vector2 position, int count, Vector2 linearVelocity, float angularVelocity)
            : base(LimitsEdgeGame.textures["metal"], position, count, linearVelocity, angularVelocity)
        {
        }
    }
}
