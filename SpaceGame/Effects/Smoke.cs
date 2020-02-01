using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceGame.Effects
{
    public class Smoke : Particle
    {
        public Smoke(Vector2 position) : base(position, Game1.textures["smoke"], 5f)
        {
        }
    }
}
