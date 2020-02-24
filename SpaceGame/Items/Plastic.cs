using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceGame.Items
{
    /// <summary>
    /// Plastic class - inherits the Item class.
    /// </summary>
    public class Plastic : Item
    {
        /// <summary>
        /// Creates a new instance of the Plastic class, with specified parameters.
        /// </summary>
        /// <param name="position">X and Y starting coordinates.</param>
        /// <param name="count">The number of plastic items in this 'stack'.</param>
        /// <param name="randomize">Determines if the velocities are random.</param>
        public Plastic(Vector2 position, int count, bool randomize)
            : base(LimitsEdgeGame.textures["plastic"], position, count, randomize)
        {
        }

        /// <summary>
        /// Creates a new instance of the Plastic class, with specified parameters.
        /// </summary>
        /// <param name="position">X and Y starting coordinates.</param>
        /// <param name="count">The number of plastic items in this 'stack'.</param>
        /// <param name="linearVelocity">X and Y linear velocites of the plastic item.</param>
        /// <param name="angularVelocity">Angular velocity of the plastic item.</param>
        public Plastic(Vector2 position, int count, Vector2 linearVelocity, float angularVelocity)
            : base(LimitsEdgeGame.textures["plastic"], position, count, linearVelocity, angularVelocity)
        {
        }
    }
}
