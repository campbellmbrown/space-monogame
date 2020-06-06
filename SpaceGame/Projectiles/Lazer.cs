using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SpaceGame.Effects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceGame.Projectiles
{
    public class Lazer : Projectile 
    {
        protected float particleTime = 0.2f;
        protected float currentParticleTime = 0f;

        public Lazer(Vector2 position, float rotation, Color color, Vector2 linearVelocity, int damage)
            : base(position, LimitsEdgeGame.textures["lazer"], rotation, linearVelocity, damage)
        {
            base.color = color;
        }

        public override void Update(GameTime gameTime)
        {
            currentParticleTime += (float)gameTime.ElapsedGameTime.TotalSeconds;

            if (currentParticleTime >= particleTime)
            {
                LaserParticle laserParticle = new LaserParticle(position, true, color);
                LimitsEdgeGame.worldStateManager.particleManager.particles.Add(laserParticle);
                currentParticleTime = 0f;
                particleTime = LimitsEdgeGame.r.Next(0, 21) / 100f;
            }
            base.Update(gameTime);
        }
    }
}
