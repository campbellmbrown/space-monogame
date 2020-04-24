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
        protected int _width;
        protected float width { get { return _width / LimitsEdgeGame.currentZoom; } }
        protected int _height;
        protected float height { get { return _height / LimitsEdgeGame.currentZoom; } }
        protected Color textColor;
        protected string text;
        protected Vector2 menuPosition;
        protected Vector2 textSize { get { return LimitsEdgeGame.fonts["courier_new_bold"].MeasureString(text); } }
        
        // Background texture variables
        protected float textScale { get { return height / textSize.Y; } }
        protected float textureScale { get { return height / texture.Height; } }
        protected int segWidth { get { return texture.Width / 3; } }
        protected int middleSections { get { return (_width / _height) - 2; } }

        protected Vector2 position { get { return menuPosition + new Vector2(0, -optionListOrder * height); } }
        public RectangleF interactionRectangle { get { return new RectangleF(position.X, position.Y, width, height); } }
        public Action clickAction;

        protected Texture2D texture;

        public SmallMenuOption(int optionListOrder, Vector2 menuPosition, int width, int height, string text, Color textColor, Action clickAction)
        {
            texture = LimitsEdgeGame.textures["small_menu"];
            this.optionListOrder = optionListOrder;
            this.menuPosition = menuPosition;
            _width = width;
            _height = height;
            this.text = text;
            this.textColor = textColor;
            this.clickAction = clickAction;
        }

        public void Draw(SpriteBatch spriteBatch)
        {

            DrawSegment(spriteBatch, 0, 0);
            for (int i = 1; i <= middleSections; ++i)
                DrawSegment(spriteBatch, 1, i);
            DrawSegment(spriteBatch, 2, middleSections + 1);
            spriteBatch.DrawString(LimitsEdgeGame.fonts["courier_new_bold"], text, position, textColor, 0f, Vector2.Zero, textScale, SpriteEffects.None, 0f);
        }
        
        public void DrawSegment(SpriteBatch spriteBatch, int segment, int offsetIndex)
        {
            spriteBatch.Draw(texture, 
                position + new Vector2(segWidth * height / texture.Height * offsetIndex, 0), 
                new Rectangle(segment * segWidth, 0, segWidth, texture.Height), 
                Color.White, 0f, Vector2.Zero, textureScale, SpriteEffects.None, 1f);
        }

        public void ClickAction()
        {
            clickAction();
        }
    }
}
