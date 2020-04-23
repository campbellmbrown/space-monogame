using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceGame.Models
{
    public class SmallMenu
    {
        protected List<SmallMenuOption> menuOptions;
        protected int height;
        protected int width;

        public SmallMenu(int menuOptionHeight, int menuOptionWidth)
        {
            height = menuOptionHeight;
            width = menuOptionWidth;
            menuOptions = new List<SmallMenuOption>();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (var menuOption in menuOptions) menuOption.Draw(spriteBatch);
        }

        public void AddMenuOption(int optionListOrder, Vector2 position)
        {
            menuOptions.Add(new SmallMenuOption(optionListOrder, position, width, height));
        }
    }
}
