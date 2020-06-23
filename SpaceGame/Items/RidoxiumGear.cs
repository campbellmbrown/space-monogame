using Microsoft.Xna.Framework;
using SpaceGame.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceGame.Items
{
    public class RidoxiumGear : Equipment
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
            equipmentType = EquipmentType.Kinematics;
            equipmentBuffs.Add(new Buff(BuffType.ShipLinearSpeed, 0.1f, new Color(59, 186, 213), new Color(19, 60, 68)));
            base.AddEquipmentBuffs();
        }
    }
}
