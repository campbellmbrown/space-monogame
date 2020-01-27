using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceGame.Sprites
{
    public class Spaceship : MovingSprite
    {
        public Spaceship(Vector2 position, Texture2D texture, float maxAcceleration, float maxSpeed) : base(position, texture, maxAcceleration, maxSpeed)
        {
        }
    }
}
