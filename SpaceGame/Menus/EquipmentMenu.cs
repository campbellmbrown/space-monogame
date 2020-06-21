using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
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
        protected List<ItemHolder> itemHolders;

        public EquipmentMenu(Vector2 selectionBarPosition) : base(selectionBarPosition, "Equipment", InventoryType.Equipment)
        {
            itemHolders = new List<ItemHolder>();
            for (int i = 0; i < 4; ++i)
            {
                for (int j = 0; j < 2; ++j)
                {
                    itemHolders.Add(new ItemHolder(menuOffset + new Vector2(j * 24, i * 24)));
                }
            }
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            if (selected)
            {
                foreach (var itemHolder in itemHolders) itemHolder.Draw(spriteBatch);
            }
            base.Draw(spriteBatch);
        }

        public override void Click(Vector2 mousePosition)
        {
            if (selected)
            {
                foreach (var itemHolder in itemHolders)
                {
                    if (itemHolder.CheckHover(mousePosition))
                    {
                        itemHolder.ClickAction();
                    }
                }
            }
            base.Click(mousePosition);
        }

        public override void Hover(Vector2 mousePosition)
        {
            if (selected)
            {
                label.active = false;
                foreach (var itemHolder in itemHolders)
                {
                    if (itemHolder.CheckItemHover(mousePosition))
                    {
                        List<string> subtext = new List<string>();
                        foreach (var equipmentBuff in itemHolder.item.equipmentBuffs)
                            subtext.Add(equipmentBuff.buffString);
                        label.Update(LimitsEdgeGame.mousePosition, itemHolder.item.name, subtext);
                        label.active = true;
                        break;
                    }
                }
            }
            base.Hover(mousePosition);
        }
    }
}
