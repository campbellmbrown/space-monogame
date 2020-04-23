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
        protected int optionListOrder;
        protected Vector2 menuPosition;
        protected int width;
        protected int height;
        protected Color textColor;
        protected string text;
        protected Vector2 textSize { get { return LimitsEdgeGame.fonts["courier_new_bold"].MeasureString(text); } }
        protected float textScale { get { return height / textSize.Y; } }

        public SmallMenuOption(int optionListOrder, Vector2 menuPosition, int width, int height, string text, Color textColor)
        {
            this.optionListOrder = optionListOrder;
            this.menuPosition = menuPosition;
            this.width = width;
            this.height = height;
            this.text = text;
            this.textColor = textColor;
            
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.DrawString(LimitsEdgeGame.fonts["courier_new_bold"], text, new Vector2(menuPosition.X, menuPosition.Y - optionListOrder * height), textColor, 0f, Vector2.Zero, textScale, SpriteEffects.None, 0f);
        }
    }
}
