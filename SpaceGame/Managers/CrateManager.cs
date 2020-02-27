using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SpaceGame.Effects;
using SpaceGame.Sprites;
using SpaceGame.Utilities;
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
        /// <param name="collisionRectangle">Collision area to check.</param>
        /// <param name="collisionObjectVelocity">Velocity of the object being collided with.</param>
        /// <param name="damage">Amount of damage the crate will take.</param>
        public bool CheckCollision(Rectangle collisionRectangle, Vector2 collisionObjectVelocity, int damage = 0)
        {
            for (int i = crates.Count - 1; i >= 0; i--)
            {
                if (crates[i].CheckCollision(collisionRectangle))
                {
                    Rectangle crateCollision = crates[i].collisionRectangle;
                    crates[i].linearVelocity += collisionObjectVelocity;
                    Vector2 crateLinearVelocity = crates[i].linearVelocity;
                    if (crates[i].DepleteHealth(damage))
                    {
                        crates[i].BreakAction();
                        crates.RemoveAt(i);
                    }
                    AddSmallExplosion(crateCollision, crateLinearVelocity);
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Adds a small explosion on the crate.
        /// </summary>
        /// <param name="rectangle">Rectangle to create explosion inside of.</param>
        /// <param name="linearVelocity">Linear velocity of the explosion.</param>
        public void AddSmallExplosion(Rectangle rectangle, Vector2 linearVelocity)
        {
            Vector2 explosionPosition = Helper.RandomPosInRectangle(rectangle);
            for (int i = 0; i < 3; ++i) LimitsEdgeGame.particleManager.particles.Add(new Smoke(explosionPosition, true));
            LimitsEdgeGame.particleManager.particles.Add(new SmallExplosion(explosionPosition, false) { linearVelocity = linearVelocity });
        }
    }
}