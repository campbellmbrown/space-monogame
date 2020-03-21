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

        public ProjectileManager()
        {
            projectiles = new List<Projectile>();
        }

        public void Update(GameTime gameTime)
        {
            for (int i = projectiles.Count - 1; i >= 0; i--)
            {
                projectiles[i].Update(gameTime);
                bool collided = LimitsEdgeGame.worldStateManager.crateManager.CheckCollision(projectiles[i].collisionRectangle, projectiles[i].explosionVelocity, projectiles[i].damage);
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
