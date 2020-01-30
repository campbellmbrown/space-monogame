using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceGame.Managers
{
    public class WorldManager
    {
        StarManager starManager;

        public WorldManager()
        {
            starManager = new StarManager();
        }

        public void Update(GameTime gameTime)
        {
            starManager.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            starManager.Draw(spriteBatch);
        }
    }
}
