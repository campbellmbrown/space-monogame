using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SpaceGame.Projectiles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceGame.Managers
{
    public class ProjectileManager
    {
        public List<Projectile> projectiles;
        private WorldManager worldManager = LimitsEdgeGame.worldManager;

        public ProjectileManager(WorldManager worldManager)
        {
            projectiles = new List<Projectile>();
        }

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

        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (var projectile in projectiles) projectile.Draw(spriteBatch);
        }
    }
}
