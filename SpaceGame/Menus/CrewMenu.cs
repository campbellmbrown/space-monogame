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
    public class CrewMenu : Menu
    {
        protected Texture2D crewMenuTexture;
        protected List<InShipCrew> inShipCrew;

        public CrewMenu(Vector2 selectionBarPosition) : base(selectionBarPosition, "Crew", InventoryType.Crew)
        {
            crewMenuTexture = LimitsEdgeGame.textures["crew_menu"];
            inShipCrew = new List<InShipCrew>();
            for (int i = 0; i < 3; ++i) inShipCrew.Add(new InShipCrew(LimitsEdgeGame.animations["crew"], menuOffset + new Vector2(8, 8)));
        }

        public override void Update(GameTime gameTime)
        {
            if (selected)
            {
                foreach (var crew in inShipCrew) crew.Update(gameTime);
                inShipCrew = inShipCrew.OrderBy(o => o.position.Y).ToList();
            }
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            if (selected)
            {
                spriteBatch.Draw(crewMenuTexture, menuOffset, null, Color.White, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0f);
                foreach (var crew in inShipCrew) crew.Draw(spriteBatch);
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

        public override void Hover(Vector2 mousePosition)
        {
            if (selected)
            {
                label.active = false;
                foreach (var crew in inShipCrew)
                {
                    if (crew.CheckHover(mousePosition))
                    {
                        label.Update(LimitsEdgeGame.mousePosition, crew.name);
                        label.active = true;
                        break;
                    }
                }
            }
            base.Hover(mousePosition);
        }
    }
}
