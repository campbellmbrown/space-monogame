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
        protected Vector2 position;
        protected int width;
        protected int height;
        protected Color textColor;
        protected string text;
        protected Vector2 textSize { get { return LimitsEdgeGame.fonts["courier_new_bold"].MeasureString(text); } }
        protected float textScale { get { return height / textSize.Y; } }
        public Rectangle interactionRectangle;
        public Action clickAction;

        public SmallMenuOption(int optionListOrder, Vector2 menuPosition, int width, int height, string text, Color textColor, Action clickAction)
        {
            this.optionListOrder = optionListOrder;
            position = new Vector2(menuPosition.X, menuPosition.Y - optionListOrder * height);
            interactionRectangle = new Rectangle((int)position.X, (int)position.Y, width, height);
            this.width = width;
            this.height = height;
            this.text = text;
            this.textColor = textColor;
            this.clickAction = clickAction;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.DrawString(LimitsEdgeGame.fonts["courier_new_bold"], text, position, textColor, 0f, Vector2.Zero, textScale, SpriteEffects.None, 0f);
            spriteBatch.DrawRectangle(interactionRectangle, textColor);
        }

        public void ClickAction()
        {
            clickAction();
        }
    }
}
