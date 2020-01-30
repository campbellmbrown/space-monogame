using Microsoft.Xna.Framework.Graphics;
using SpaceGame.World;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceGame.Managers
{
    public class StarManager
    {
        static readonly int starCount = 100;
        List<Star> stars;

        public StarManager()
        {
            stars = new List<Star>();
            for (int i = 0; i < starCount; ++i)
            {
                stars.Add(new Star());
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (var star in stars) star.Draw(spriteBatch);
        }
    }
}
