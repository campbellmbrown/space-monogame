using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SpaceGame.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceGame.Managers
{
    /// <summary>
    /// Class to handle items.
    /// </summary>
    public class ItemManager
    {
        public List<Item> items;

        /// <summary>
        /// Creates an instance of the ItemManager class.
        /// </summary>
        public ItemManager()
        {
            items = new List<Item>();
        }

        /// <summary>
        /// Updates the items.
        /// </summary>
        /// <param name="gameTime">GameTime instance.</param>
        public void Update(GameTime gameTime)
        {
            foreach (var item in items) item.Update(gameTime);
        }

        /// <summary>
        /// Draws the items.
        /// </summary>
        /// <param name="spriteBatch">SpriteBatch instance.</param>
        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (var item in items) item.Draw(spriteBatch);
        }
    }
}
