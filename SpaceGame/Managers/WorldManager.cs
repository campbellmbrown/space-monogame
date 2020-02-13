using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SpaceGame.Items;
using SpaceGame.Sprites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceGame.Managers
{
    public class WorldManager
    {
        public StarManager starManager;
        public ItemManager itemManager;
        public CrateManager crateManager;
        public AsteroidManager asteroidManager;

        public WorldManager()
        {
            starManager = new StarManager();
            itemManager = new ItemManager();
            crateManager = new CrateManager();
            asteroidManager = new AsteroidManager();
        }

        public void Update(GameTime gameTime)
        {
            starManager.Update(gameTime);
            itemManager.Update(gameTime);
            crateManager.Update(gameTime);
            asteroidManager.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            starManager.Draw(spriteBatch);
            itemManager.Draw(spriteBatch);
            crateManager.Draw(spriteBatch);
            asteroidManager.Draw(spriteBatch);
        }
    }
}
