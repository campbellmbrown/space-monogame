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
    /// <summary>
    /// Class to handle the world.
    /// </summary>
    public class WorldManager
    {
        public StarManager starManager;
        public ItemManager itemManager;
        public CrateManager crateManager;

        /// <summary>
        /// Creates an instance of the WorldManager class.
        /// </summary>
        public WorldManager()
        {
            starManager = new StarManager();
            itemManager = new ItemManager();
            crateManager = new CrateManager();
        }

        /// <summary>
        /// Updates the world.
        /// </summary>
        /// <param name="gameTime">GameTime instance.</param>
        public void Update(GameTime gameTime)
        {
            starManager.Update(gameTime);
            itemManager.Update(gameTime);
            crateManager.Update(gameTime);
        }

        /// <summary>
        /// Draws the world.
        /// </summary>
        /// <param name="spriteBatch">SpriteBatch instance.</param>
        public void Draw(SpriteBatch spriteBatch)
        {
            starManager.Draw(spriteBatch);
            itemManager.Draw(spriteBatch);
            crateManager.Draw(spriteBatch);
        }
    }
}
