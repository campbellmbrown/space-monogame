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
            AddEquipmentBuffs();
        }

        public RidoxiumGear(Vector2 position, Vector2 linearVelocity, float angularVelocity)
            : base(LimitsEdgeGame.textures["ridoxium_gear"], position, linearVelocity, angularVelocity, "Ridoxium Gear")
        {
            AddEquipmentBuffs();
        }

        public override void AddEquipmentBuffs()
        {
            equipmentBuffs.Add(new EquipmentBuff(EquipmentBuffType.ShipLinearSpeed, 0.1f));
            base.AddEquipmentBuffs();
        }
    }
}
