using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SpaceGame.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceGame.Managers
{
    /// <summary>
    /// Class to handle GUI.
    /// </summary>
    public class GuiManager
    {
        protected Minimap minimap;

        /// <summary>
        /// Creates an instance of the GuiManager class.
        /// </summary>
        public GuiManager()
        {
            minimap = new Minimap();
        }

        /// <summary>
        /// Updates the GUI.
        /// </summary>
        /// <param name="gameTime">GameTime instance.</param>
        public void Update(GameTime gameTime) { }

        /// <summary>
        /// Draws the GUI.
        /// </summary>
        /// <param name="spriteBatch">SpriteBatch instance.</param>
        public void Draw(SpriteBatch spriteBatch)
        {
            minimap.Draw(spriteBatch);
        }
    }
}
