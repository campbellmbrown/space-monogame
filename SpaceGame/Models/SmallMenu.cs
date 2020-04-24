using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Extended;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceGame.Models
{
    public class SmallMenu
    {
        public List<SmallMenuOption> menuOptions;
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

        public void AddMenuOption(int optionListOrder, Vector2 position, string text, Color textColor, Action clickAction)
        {
            menuOptions.Add(new SmallMenuOption(optionListOrder, position, width, height, text, textColor, clickAction));
        }

        /*
         * public void ErrorDBConcurrency(DBConcurrencyException e, Action method)
         * {
         *     if (MessageBox.Show("You must refresh the datasource") == DialogResult.OK)
         *         method();
         * }
         * void MyAction()
         * {
         * 
         * }
         * 
         * ErrorDBConcurrency(e, MyAction); 
         * // OR
         * ErrorDBConcurrency(e, () => MyAction(1, 2, "Test")); 
         */
    }
}
