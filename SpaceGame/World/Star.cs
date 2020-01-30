using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Extended;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceGame.World
{
    public class Star
    {
        Color color;
        Vector2 position;

        public Star()
        {
            int screenWidth = (int)Game1.ScreenSize.X;
            int screenHeight = (int)Game1.ScreenSize.Y;
            color = new Color(Game1.r.Next(0, 256), Game1.r.Next(0, 256), Game1.r.Next(0, 256));
            position = new Vector2(Game1.r.Next(-screenWidth / 2, screenWidth / 2 + 1), Game1.r.Next(-screenHeight / 2, screenHeight / 2 + 1)) / Game1.zoom;
        }

        public void Update(GameTime gameTime)
        {

        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.DrawPoint(position, color);
        }
    }
}
