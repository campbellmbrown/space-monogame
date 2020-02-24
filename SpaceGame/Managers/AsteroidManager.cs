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
    /// Class to handle asteroids.
    /// </summary>
    public class AsteroidManager
    {
        public List<Asteroid> asteroids;

        /// <summary>
        /// Creates an instance of the AsteroidManager class.
        /// </summary>
        public AsteroidManager()
        {
            asteroids = new List<Asteroid>();
        }

        /// <summary>
        /// Updates the asteroids.
        /// </summary>
        /// <param name="gameTime">GameTime instance.</param>
        public void Update(GameTime gameTime)
        {
            foreach (var asteroid in asteroids)
            {
                asteroid.Update(gameTime);
            }
        }

        /// <summary>
        /// Draws the asteroids.
        /// </summary>
        /// <param name="spriteBatch">SpriteBatch instance.</param>
        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (var asteroid in asteroids)
            {
                asteroid.Draw(spriteBatch);
            }
        }
    }
}
