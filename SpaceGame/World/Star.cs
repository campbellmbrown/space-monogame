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
    /// <summary>
    /// Class that defines a star.
    /// </summary>
    public class Star
    {
        Color color;
        Vector2 position;
        int depth;
        float transparency { get { return (10 - depth) / 10f; } }
        float screenWidth { get { return LimitsEdgeGame.zoomedScreenSize.X; } }
        float screenHeight { get { return LimitsEdgeGame.zoomedScreenSize.Y; } }
        PlayerManager playerManager = LimitsEdgeGame.playerManager;

        /// <summary>
        /// Creates an instance of the Star class.
        /// </summary>
        public Star()
        {
            depth = LimitsEdgeGame.r.Next(0, 11);
            color = new Color(LimitsEdgeGame.r.Next(150, 256), LimitsEdgeGame.r.Next(150, 256), LimitsEdgeGame.r.Next(150, 256));
            position = new Vector2(LimitsEdgeGame.r.Next((int)(-screenWidth / 2f), (int)(screenWidth / 2 + 1)), 
                LimitsEdgeGame.r.Next((int)(-screenHeight / 2), (int)(screenHeight / 2 + 1)));
        }

        /// <summary>
        /// Updates the star based on the players position.
        /// </summary>
        /// <param name="gameTime">GameTime instance.</param>
        public void Update(GameTime gameTime)
        {
            float t = (float)gameTime.ElapsedGameTime.TotalSeconds;
            position += playerManager.playerShip.linearVelocity * t * depth / 10f;
            if (position.X > LimitsEdgeGame.positionCenter.X + screenWidth / 2f) position.X -= screenWidth;
            else if (position.X < LimitsEdgeGame.positionCenter.X - screenWidth / 2f) position.X += screenWidth;
            else if (position.Y > LimitsEdgeGame.positionCenter.Y + screenHeight / 2f) position.Y -= screenHeight;
            else if (position.Y < LimitsEdgeGame.positionCenter.Y - screenHeight / 2f) position.Y += screenHeight;
        }

        /// <summary>
        /// Draws the star.
        /// </summary>
        /// <param name="spriteBatch">SpriteBatch instance.</param>
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.DrawPoint(position, color * transparency);
        }
    }
}
