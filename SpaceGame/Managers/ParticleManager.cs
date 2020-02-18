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
    public class ParticleManager
    {
        private List<Particle> _particles;

        public ParticleManager()
        {
            _particles = new List<Particle>();
        }

        public void AddParticle(Particle particle)
        {
            _particles.Add(particle);
        }

        public void Update(GameTime gameTime)
        {
            for (int i = _particles.Count - 1; i >= 0; i--)
            {
                _particles[i].Update(gameTime);
                if (_particles[i].CheckToDestroy())
                {
                    _particles.RemoveAt(i);
                }
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (var particle in _particles)
                particle.Draw(spriteBatch);
        }

        public void DeleteParticle(Particle particle)
        {
            _particles.Remove(particle);
        }
    }
}