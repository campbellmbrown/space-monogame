﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SpaceGame.Projectiles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceGame.Managers
{
    /// <summary>
    /// Class to handle projectiles.
    /// </summary>
    public class ProjectileManager
    {
        public List<Projectile> projectiles;
        private WorldManager worldManager = LimitsEdgeGame.worldManager;

        /// <summary>
        /// Creates an instance of the ProjectileManager class.
        /// </summary>
        /// <param name="worldManager"></param>
        public ProjectileManager(WorldManager worldManager)
        {
            projectiles = new List<Projectile>();
        }

        /// <summary>
        /// Updates the projectiles.
        /// </summary>
        /// <param name="gameTime">GameTime instance.</param>
        public void Update(GameTime gameTime)
        {
            for (int i = projectiles.Count - 1; i >= 0; i--)
            {
                projectiles[i].Update(gameTime);
                bool collided = worldManager.crateManager.CheckCollision(projectiles[i].collisionRectangle);
                if (collided)
                {
                    projectiles.Remove(projectiles[i]);
                }
            }
        }

        /// <summary>
        /// Draws the projectiles.
        /// </summary>
        /// <param name="spriteBatch">SpriteBatch instance.</param>
        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (var projectile in projectiles) projectile.Draw(spriteBatch);
        }
    }
}
