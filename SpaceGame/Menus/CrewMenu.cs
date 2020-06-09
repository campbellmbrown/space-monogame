using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SpaceGame.Managers.InventoryStateManagers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceGame.Menus
{
    public class CrewMenu : Menu
    {
        public CrewMenu(Vector2 selectionBarPosition) : base(selectionBarPosition, "Crew", InventoryType.Crew)
        {
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            if (selected)
            {

            }
            base.Draw(spriteBatch);
        }

        public override void Click(Vector2 mousePosition)
        {
            if (selected)
            {
            }
            base.Click(mousePosition);
        }
    }
}
