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
    public class AsteroidManager
    {
        protected List<Asteroid> asteroids;

        public AsteroidManager()
        {
            asteroids = new List<Asteroid>();
        }

        public void Update(GameTime gameTime)
        {
            foreach (var asteroid in asteroids)
            {
                asteroid.Update(gameTime);
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (var asteroid in asteroids)
            {
                asteroid.Draw(spriteBatch);
            }
        }

        public void AddAsteroid(Asteroid asteroid)
        {
            asteroids.Add(asteroid);
        }
    }
}
