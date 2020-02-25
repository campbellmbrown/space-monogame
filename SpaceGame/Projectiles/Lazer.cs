using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceGame.Projectiles
{
    /// <summary>
    /// Class that defines a Lazer. Inherits the projectile class.
    /// </summary>
    public class Lazer : Projectile 
    {
        /// <summary>
        /// Creates an instance of the Lazer class.
        /// </summary>
        /// <param name="position">X and Y position of the lazer.</param>
        /// <param name="rotation">Rotation of the lazer.</param>
        /// <param name="color">Color of the lazer.</param>
        /// <param name="linearVelocity">X and Y linear velocities of the lazer.</param>
        public Lazer(Vector2 position, float rotation, Color color, Vector2 linearVelocity)
            : base(position, LimitsEdgeGame.textures["lazer"], rotation, linearVelocity)
        {
            base.color = color;
        }
    }
}
