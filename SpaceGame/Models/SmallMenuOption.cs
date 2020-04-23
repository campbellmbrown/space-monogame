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
    public class SmallMenuOption
    {
        int optionListOrder;
        Vector2 menuPosition;
        int width;
        int height;

        public SmallMenuOption(int optionListOrder, Vector2 menuPosition, int width, int height)
        {
            this.optionListOrder = optionListOrder;
            this.menuPosition = menuPosition;
            this.width = width;
            this.height = height;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.DrawRectangle(new RectangleF(menuPosition.X, menuPosition.Y - optionListOrder * height, width, height), Color.White);
        }
    }
}
