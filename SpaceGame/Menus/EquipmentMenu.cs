using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using SpaceGame.Managers.InventoryStateManagers;
using SpaceGame.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceGame.Menus
{
    public class EquipmentMenu : Menu
    {
        protected List<EquipmentHolder> kinematicEquipmentHolders;
        protected List<EquipmentHolder> defenseEquipmentHolders;
        protected List<EquipmentHolder> attackEquipmentHolders;
        protected List<EquipmentHolder> reputationEquipmentHolders;
        protected List<EquipmentHolder> cosmeticsEquipmentHolders;
        protected List<EquipmentHolder> familiarsEquipmentHolders;
        protected int spaceBetweenHolders = 24;

        public EquipmentMenu(Vector2 selectionBarPosition) : base(selectionBarPosition, "Equipment", InventoryType.Equipment)
        {
            kinematicEquipmentHolders = new List<EquipmentHolder>();
            defenseEquipmentHolders = new List<EquipmentHolder>();
            attackEquipmentHolders = new List<EquipmentHolder>();
            reputationEquipmentHolders = new List<EquipmentHolder>();
            cosmeticsEquipmentHolders = new List<EquipmentHolder>();
            familiarsEquipmentHolders = new List<EquipmentHolder>();
            CreateRow(kinematicEquipmentHolders, EquipmentType.Kinematics, 2, 0);
            CreateRow(defenseEquipmentHolders, EquipmentType.Defense, 2, spaceBetweenHolders);
            CreateRow(attackEquipmentHolders, EquipmentType.Attack, 2, 2 * spaceBetweenHolders);
            CreateRow(reputationEquipmentHolders, EquipmentType.Reputation, 2, 3 * spaceBetweenHolders);
            CreateRow(cosmeticsEquipmentHolders, EquipmentType.Cosmetics, 2, 4 * spaceBetweenHolders);
            CreateRow(familiarsEquipmentHolders, EquipmentType.Familiars, 2, 5 * spaceBetweenHolders);
        }

        public void CreateRow(List<EquipmentHolder> equipmentList, EquipmentType equipmentType, int columns, int verticalDisplacement)
        {
            for (int i = 0; i < columns; ++i)
                equipmentList.Add(new EquipmentHolder(menuOffset + new Vector2(i * spaceBetweenHolders, verticalDisplacement), equipmentType));
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            if (selected)
            {
                foreach (var holder in kinematicEquipmentHolders) holder.Draw(spriteBatch);
                foreach (var holder in defenseEquipmentHolders) holder.Draw(spriteBatch);
                foreach (var holder in attackEquipmentHolders) holder.Draw(spriteBatch);
                foreach (var holder in reputationEquipmentHolders) holder.Draw(spriteBatch);
                foreach (var holder in cosmeticsEquipmentHolders) holder.Draw(spriteBatch);
                foreach (var holder in familiarsEquipmentHolders) holder.Draw(spriteBatch);
            }
            base.Draw(spriteBatch);
        }

        public override void Click(Vector2 mousePosition)
        {
            if (selected)
            {
                SubClick(kinematicEquipmentHolders, mousePosition);
                SubClick(defenseEquipmentHolders, mousePosition);
                SubClick(attackEquipmentHolders, mousePosition);
                SubClick(reputationEquipmentHolders, mousePosition);
                SubClick(cosmeticsEquipmentHolders, mousePosition);
                SubClick(familiarsEquipmentHolders, mousePosition);
            }
            base.Click(mousePosition);
        }

        public void SubClick(List<EquipmentHolder> equipmentList, Vector2 mousePosition)
        {
            foreach (var equipmentHolder in equipmentList)
                if (equipmentHolder.CheckHover(mousePosition))
                    equipmentHolder.ClickAction();
        }

        public override void Hover(Vector2 mousePosition)
        {
            if (selected)
            {
                label.active = false;
                SubHover(kinematicEquipmentHolders, mousePosition);
                if (!label.active) SubHover(defenseEquipmentHolders, mousePosition);
                if (!label.active) SubHover(attackEquipmentHolders, mousePosition);
                if (!label.active) SubHover(reputationEquipmentHolders, mousePosition);
                if (!label.active) SubHover(cosmeticsEquipmentHolders, mousePosition);
                if (!label.active) SubHover(familiarsEquipmentHolders, mousePosition);
            }
            base.Hover(mousePosition);
        }

        public void SubHover(List<EquipmentHolder> equipmentList, Vector2 mousePosition)
        {
            foreach (var equipment in equipmentList)
            {
                // If the mouse is hovering over the equipment holder
                if (equipment.CheckItemHover(mousePosition))
                {
                    // Update the menu label
                    label.Update(LimitsEdgeGame.mousePosition, equipment.item.name, equipment.item.subtext);
                    label.active = true;
                    break;
                }
            }
        }
    }
}
