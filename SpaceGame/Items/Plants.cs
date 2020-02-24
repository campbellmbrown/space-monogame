using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceGame.Items
{
    /// <summary>
    /// Plants class - inherits the Item class.
    /// </summary>
    public class Plants : Item
    {
        /// <summary>
        /// Creates a new instance of the Plants class, with specified parameters.
        /// </summary>
        /// <param name="position">X and Y starting coordinates.</param>
        /// <param name="count">The number of plants items in this 'stack'.</param>
        /// <param name="randomize">Determines if the velocities are random.</param>
        public Plants(Vector2 position, int count, bool randomize)
            : base(LimitsEdgeGame.textures["plants"], position, count, randomize)
        {
        }

        /// <summary>
        /// Creates a new instance of the Plants class, with specified parameters.
        /// </summary>
        /// <param name="position">X and Y starting coordinates.</param>
        /// <param name="count">The number of plants items in this 'stack'.</param>
        /// <param name="linearVelocity">X and Y linear velocites of the plants item.</param>
        /// <param name="angularVelocity">Angular velocity of the plants item.</param>
        public Plants(Vector2 position, int count, Vector2 linearVelocity, float angularVelocity)
            : base(LimitsEdgeGame.textures["plants"], position, count, linearVelocity, angularVelocity)
        {
        }
    }
}
