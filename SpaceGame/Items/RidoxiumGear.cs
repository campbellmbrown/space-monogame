using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceGame.Items
{
    public class RidoxiumGear : Item
    {
        public RidoxiumGear(Vector2 position, bool randomize = true)
            : base(LimitsEdgeGame.textures["ridoxium_gear"], position, "Ridoxium Gear", randomize)
        {
        }

        public RidoxiumGear(Vector2 position, Vector2 linearVelocity, float angularVelocity)
            : base(LimitsEdgeGame.textures["ridoxium_gear"], position, linearVelocity, angularVelocity, "Ridoxium Gear")
        {
        }
    }
}
