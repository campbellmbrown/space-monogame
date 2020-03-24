using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceGame.Models
{
    public class Animation
    {
        public int frameCount;
        public float frameSpeed;
        public int frameHeight { get { return texture.Height; } }
        public int frameWidth { get { return texture.Width / frameCount; } }
        public bool isLooping;
        public Texture2D texture;

        public Animation(Texture2D texture, int frameCount, float frameSpeed)
        {
            this.texture = texture;
            this.frameCount = frameCount;
            this.frameSpeed = frameSpeed;
            isLooping = true;
        }
    }
}
