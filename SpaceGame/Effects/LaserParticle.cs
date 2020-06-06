using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceGame.Effects
{
    public class LaserParticle : Particle
    {
        Color color;

        public LaserParticle(Vector2 position, bool randomize, Color color) : base(position, LimitsEdgeGame.animations["laser_particle"], randomize)
        {
            this.color = color;
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            animationManager.Draw(spriteBatch, color, rotation);
        }
    }
}
