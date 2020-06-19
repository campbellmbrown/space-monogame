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
        public Metal(Vector2 position, bool randomize = true)
            : base(LimitsEdgeGame.textures["metal"], position, "Metal", randomize)
        {
        }

        public Metal(Vector2 position, Vector2 linearVelocity, float angularVelocity)
            : base(LimitsEdgeGame.textures["metal"], position, linearVelocity, angularVelocity, "Metal")
        {
        }
    }
}
