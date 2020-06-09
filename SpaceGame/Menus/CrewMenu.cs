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
        Texture2D crewMenuTexture;

        public CrewMenu(Vector2 selectionBarPosition) : base(selectionBarPosition, "Crew", InventoryType.Crew)
        {
            crewMenuTexture = LimitsEdgeGame.textures["crew_menu"];
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            if (selected)
            {
                spriteBatch.Draw(crewMenuTexture, menuOffset, null, Color.White, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0f);
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
