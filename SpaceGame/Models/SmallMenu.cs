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

        public SmallMenu()
        {
            menuOptions = new List<SmallMenuOption>();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (var menuOption in menuOptions) menuOption.Draw(spriteBatch);
        }
    }
}
