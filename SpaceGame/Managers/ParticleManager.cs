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
        private List<Particle> _particleList;

        public ParticleManager()
        {
            _particleList = new List<Particle>();
        }

        public void AddParticle(Particle particle)
        {
            _particleList.Add(particle);
        }

        public void Update(GameTime gameTime)
        {
            for (int i = _particleList.Count - 1; i >= 0; i--)
            {
                _particleList[i].Update(gameTime);
                if (_particleList[i].ExceedsLifeTime())
                {
                    _particleList.Remove(_particleList[i]);
                }
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (var particle in _particleList)
                particle.Draw(spriteBatch);
        }

        public void DeleteParticle(Particle particle)
        {
            _particleList.Remove(particle);
        }
    }
}