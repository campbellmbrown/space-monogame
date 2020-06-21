using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Extended;
using MonoGame.Extended.BitmapFonts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace SpaceGame.Models
{
    public class Label
    {
        protected Texture2D texture;
        protected Vector2 position;
        protected string text;
        protected BitmapFont font;
        protected Size2 fontSize { get { return font.MeasureString(text); } }
        protected int labelTextWidth 
        { 
            get 
            {
                int size = (int)fontSize.Width;
                foreach (var subtxt in subtext)
                {
                    int subtextSize = (int)font.MeasureString(subtxt).Width;
                    if (subtextSize > size)
                        size = subtextSize;
                }
                return size;
            } 
        }
        protected int segments { get { return (labelTextWidth / middleSize) + 1; } }
        /*  __________________
         * | ________________ | 2
         * |2|      16      |2|
         * | |              | |
         * | |              | |
         * | |              | | 16
         * | |              | |
         * | |              | |
         * | |______________| |
         * |__________________| 2
         */
        protected const int edgeThickness = 2;
        protected const int middleSize = 16;
        protected Rectangle topLeftSeg { get { return new Rectangle(0, 0, edgeThickness, edgeThickness); } }
        protected Rectangle topMidSeg { get { return new Rectangle(edgeThickness, 0, middleSize, edgeThickness); } }
        protected Rectangle topRightSeg { get { return new Rectangle(edgeThickness + middleSize, 0, edgeThickness, edgeThickness); } }
        protected Rectangle midLeftSeg { get { return new Rectangle(0, edgeThickness, edgeThickness, middleSize); } }
        protected Rectangle midMidSeg { get { return new Rectangle(edgeThickness, edgeThickness, middleSize, middleSize); } }
        protected Rectangle midRightSeg { get { return new Rectangle(edgeThickness + middleSize, edgeThickness, edgeThickness, middleSize); } }
        protected Rectangle bottomLeftSeg { get { return new Rectangle(0, edgeThickness + middleSize, edgeThickness, edgeThickness); } }
        protected Rectangle bottomMidSeg { get { return new Rectangle(edgeThickness, edgeThickness + middleSize, middleSize, edgeThickness); } }
        protected Rectangle bottomRightSeg { get { return new Rectangle(edgeThickness + middleSize, edgeThickness + middleSize, edgeThickness, edgeThickness); } }
        protected float opacity = 1f;
        public bool active = false;
        protected Vector2 textOffset = new Vector2(edgeThickness);
        protected List<string> subtext;
        // Colors
        protected Color mainTextColor = new Color(255, 255, 255); // White
        protected Color subtextColor = new Color(59, 186, 213); // Blue
        protected Color mainTextShadowColor = new Color(48, 48, 48); // Grey
        protected Color subtextShadowColor = new Color(19, 60, 68); // Dark grey

        public Label()
        {
            texture = LimitsEdgeGame.textures["label"];
            font = LimitsEdgeGame.bitmapFonts["game_font_16"];
            subtext = new List<string>();
        }

        public void Update(Vector2 position, string text)
        {
            this.text = text;
            this.position = position + new Vector2(8);
            subtext.Clear();
        }

        public void Update(Vector2 position, string text, List<string> subtext)
        {
            this.text = text;
            this.position = position + new Vector2(8);
            this.subtext = subtext;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (active)
            {
                DrawTop(spriteBatch);
                DrawMiddle(spriteBatch, 0);
                for (int i = 0; i < subtext.Count; ++i)
                    DrawMiddle(spriteBatch, i + 1);
                DrawBottom(spriteBatch, subtext.Count);
                // Draw text
                spriteBatch.DrawString(font, text, position + textOffset + Vector2.One, mainTextShadowColor);
                spriteBatch.DrawString(font, text, position + textOffset, mainTextColor);
                for (int i = 0; i < subtext.Count; ++i)
                {
                    Vector2 subtextOffset = new Vector2(0, (i + 1) * middleSize);
                    spriteBatch.DrawString(font, subtext[i], position + textOffset + Vector2.One + subtextOffset, subtextShadowColor);
                    spriteBatch.DrawString(font, subtext[i], position + textOffset + subtextOffset, subtextColor);
                }
            }
        }

        protected void DrawTop(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, position, topLeftSeg, Color.White * opacity);
            spriteBatch.Draw(texture, position + new Vector2(edgeThickness, 0), topMidSeg, Color.White * opacity, 0f, Vector2.Zero, new Vector2(labelTextWidth / (float)middleSize, 1), SpriteEffects.None, 0f);
            spriteBatch.Draw(texture, position + new Vector2(labelTextWidth + edgeThickness, 0), topRightSeg, Color.White * opacity);
        }

        protected void DrawMiddle(SpriteBatch spriteBatch, int row)
        {
            Vector2 vertOffsetVect = new Vector2(0, edgeThickness + middleSize * row);
            spriteBatch.Draw(texture, position + vertOffsetVect, midLeftSeg, Color.White * opacity);
            spriteBatch.Draw(texture, position + new Vector2(edgeThickness, 0) + vertOffsetVect, midMidSeg, Color.White * opacity, 0f, Vector2.Zero, new Vector2(labelTextWidth / (float)middleSize, 1), SpriteEffects.None, 0f);
            spriteBatch.Draw(texture, position + new Vector2(labelTextWidth + edgeThickness, 0) + vertOffsetVect, midRightSeg, Color.White * opacity);
        }

        protected void DrawBottom(SpriteBatch spriteBatch, int row)
        {
            Vector2 vertOffsetVect = new Vector2(0, edgeThickness + middleSize * (row + 1));
            spriteBatch.Draw(texture, position + vertOffsetVect, bottomLeftSeg, Color.White * opacity);
            spriteBatch.Draw(texture, position + new Vector2(edgeThickness, 0) + vertOffsetVect, bottomMidSeg, Color.White * opacity, 0f, Vector2.Zero, new Vector2(labelTextWidth / (float)middleSize, 1), SpriteEffects.None, 0f);
            spriteBatch.Draw(texture, position + new Vector2(labelTextWidth + edgeThickness, 0) + vertOffsetVect, bottomRightSeg, Color.White * opacity);
        }
    }
}
