using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Extended;
using SpaceGame.Managers;
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
        int depth;
        float transparency { get { return (10 - depth) / 10f; } }
        float screenWidth { get { return Game1.zoomedScreenSize.X; } }
        float screenHeight { get { return Game1.zoomedScreenSize.Y; } }
        PlayerManager playerManager = Game1.playerManager;

        public Star()
        {
            depth = Game1.r.Next(0, 11);
            color = new Color(Game1.r.Next(150, 256), Game1.r.Next(150, 256), Game1.r.Next(150, 256));
            position = new Vector2(Game1.r.Next((int)(-screenWidth / 2f), (int)(screenWidth / 2 + 1)), 
                Game1.r.Next((int)(-screenHeight / 2), (int)(screenHeight / 2 + 1)));
        }

        public void Update(GameTime gameTime)
        {
            float t = (float)gameTime.ElapsedGameTime.TotalSeconds;
            position += playerManager.playerShip.linearVelocity * t * depth / 10f;
            if (position.X > Game1.positionCenter.X + screenWidth / 2f) position.X -= screenWidth;
            else if (position.X < Game1.positionCenter.X - screenWidth / 2f) position.X += screenWidth;
            else if (position.Y > Game1.positionCenter.Y + screenHeight / 2f) position.Y -= screenHeight;
            else if (position.Y < Game1.positionCenter.Y - screenHeight / 2f) position.Y += screenHeight;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.DrawPoint(position, color * transparency);
        }
    }
}
