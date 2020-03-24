using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SpaceGame.World;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceGame.Managers
{
    /// <summary>
    /// Class to handle stars.
    /// </summary>
    public class StarManager
    {
        static readonly int starCount = 100;
        List<Star> stars;

        /// <summary>
        /// Creates an instance of the StarManager class.
        /// </summary>
        public StarManager()
        {
            stars = new List<Star>();
            for (int i = 0; i < starCount; ++i)
            {
                stars.Add(new Star());
            }
        }

        /// <summary>
        /// Updates the stars.
        /// </summary>
        /// <param name="gameTime">GameTime instance.</param>
        public void Update(GameTime gameTime)
        {
            foreach (var star in stars) star.Update(gameTime);
        }

        /// <summary>
        /// Draws the stars.
        /// </summary>
        /// <param name="spriteBatch">SpriteBatch instance.</param>
        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (var star in stars) star.Draw(spriteBatch);
        }
    }
}
