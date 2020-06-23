using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SpaceGame.Effects;
using SpaceGame.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceGame.Models
{
    public enum EquipmentType
    {
        Kinematics = 0,
        Defense = 1,
        Attack = 2,
        Reputation = 3,
        Cosmetics = 4,
        Familiars = 5
    }

    public class EquipmentHolder : ItemHolder
    {
        protected int iconSize = 22;
        protected EquipmentType equipmentType;
        protected Rectangle iconTextureRect;
        protected Texture2D iconTexture;
        protected float iconOpacity = 0.4f;

        public EquipmentHolder(Vector2 position, EquipmentType equipmentType) : base(position)
        {
            iconTexture = LimitsEdgeGame.textures["equipment_icons"];
            this.equipmentType = equipmentType;
            iconTextureRect = new Rectangle((int)equipmentType * iconSize, 0, iconSize, iconSize);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);
            if (itemCount == 0)
            {
                spriteBatch.Draw(iconTexture, position, iconTextureRect, Color.White * iconOpacity);
            }
        }

        public override void ClickAction()
        {
            Cursor cursor = LimitsEdgeGame.cursorManager.cursor;
            if (cursor.itemCount == 0)
                base.ClickAction();
            else if (cursor.item is Equipment)
            {
                Equipment heldEquipment = (Equipment)cursor.item;
                if (heldEquipment.equipmentType == equipmentType)
                    base.ClickAction();
            }
        }
    }
}
