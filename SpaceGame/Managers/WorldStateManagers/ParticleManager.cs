using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SpaceGame.Effects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceGame.Managers
{
    /// <summary>
    /// Class to handle particles.
    /// </summary>
    public class ParticleManager
    {
        public List<Particle> particles;
        public int particleCount { get { return particles.Count; } }
        
        /// <summary>
        /// Creates an instance of the ParticleManager class.
        /// </summary>
        public ParticleManager()
        {
            particles = new List<Particle>();
        }

        /// <summary>
        /// Updates the particles.
        /// </summary>
        /// <param name="gameTime">GameTime instance.</param>
        public void Update(GameTime gameTime)
        {
            for (int i = particles.Count - 1; i >= 0; i--)
            {
                particles[i].Update(gameTime);
                if (particles[i].CheckToDestroy())
                {
                    particles.RemoveAt(i);
                }
            }
        }

        /// <summary>
        /// Draws the particles.
        /// </summary>
        /// <param name="spriteBatch">SpriteBatch instance.</param>
        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (var particle in particles)
                particle.Draw(spriteBatch);
        }
    }
}