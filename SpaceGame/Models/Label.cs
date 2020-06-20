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
        protected int segmentWidth { get { return texture.Width / 3; } }
        protected int segmentHeight { get { return texture.Height; } }
        protected int segments { get { return (int)(fontSize.Width / segmentWidth) + 1; } }
        protected Rectangle firstSegmentRect { get { return new Rectangle(0, 0, segmentWidth, segmentHeight); } }
        protected Rectangle middleSegmentRect { get { return new Rectangle(segmentWidth, 0, segmentWidth, segmentHeight); } }
        protected Rectangle lastSegmentRect { get { return new Rectangle(2 * segmentWidth, 0, segmentWidth, segmentHeight); } }
        public bool active = false;
        protected Vector2 textOffset = new Vector2(4, 0);
        protected List<string> subtext;

        public Label()
        {
            texture = LimitsEdgeGame.textures["label"];
            font = LimitsEdgeGame.bitmapFonts["game_font_16"];
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
                // Draw first segment
                spriteBatch.Draw(texture, position, firstSegmentRect, Color.White, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0f);
                // Draw middle segments
                for (int i = 1; i < segments; ++i)
                    spriteBatch.Draw(texture, position + new Vector2(i * segmentWidth, 0), middleSegmentRect, Color.White, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0f);
                // Draw last segment
                spriteBatch.Draw(texture, position + new Vector2(segments * segmentWidth, 0), lastSegmentRect, Color.White, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0f);
                // Draw text
                spriteBatch.DrawString(font, text, position + textOffset + Vector2.One, Color.Black);
                spriteBatch.DrawString(font, text, position + textOffset, Color.White);
                for (int i = 0; i < subtext.Count; ++i)
                {
                    Vector2 subtextOffset = new Vector2(0, (i + 1) * fontSize.Height);
                    spriteBatch.DrawString(font, subtext[i], position + textOffset + Vector2.One + subtextOffset, Color.Black);
                    spriteBatch.DrawString(font, subtext[i], position + textOffset + subtextOffset, Color.Cyan);
                }
            }
        }
    }
}
