using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SpaceGame.Sprites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceGame.Managers
{
    /// <summary>
    /// Class to handle crates.
    /// </summary>
    public class CrateManager
    {
        public List<Crate> crates;
        protected RespawnManager respawnManager;
        protected int maxCrates = 2;

        /// <summary>
        /// Creates an instance of the CrateManager class.
        /// </summary>
        public CrateManager()
        {
            crates = new List<Crate>();
            respawnManager = new RespawnManager(100, 100, 10);
        }

        /// <summary>
        /// Updates the crates.
        /// </summary>
        /// <param name="gameTime">GameTime instance.</param>
        public void Update(GameTime gameTime)
        {
            for (int i = crates.Count - 1; i >= 0; i--)
            {
                crates[i].Update(gameTime);
                if (respawnManager.OutOfBounds(crates[i].position))
                {
                    crates.RemoveAt(i);
                }
            }
            TopUpCrates();
        }

        /// <summary>
        /// Draws the crates.
        /// </summary>
        /// <param name="spriteBatch">SpriteBatch instance.</param>
        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (var crate in crates) crate.Draw(spriteBatch);
        }

        /// <summary>
        /// Creates new crates until the maxCrates limit is reached.
        /// </summary>
        public void TopUpCrates()
        {
            for (int i = crates.Count; i < maxCrates; ++i)
            {
                crates.Add(new Crate(respawnManager.GenerateNewPosition(), true));
            }
        }

        /// <summary>
        /// Returns true if a collision is detected and damages the crates.
        /// </summary>
        /// <param name="collisionRectangle"></param>
        public bool CheckCollision(Rectangle collisionRectangle)
        {
            for (int i = crates.Count - 1; i >= 0; i--)
            {
                if (crates[i].CheckCollision(collisionRectangle))
                {
                    crates[i].BreakAction();
                    crates.RemoveAt(i);
                    return true;
                }
            }
            return false;
        }
    }
}
