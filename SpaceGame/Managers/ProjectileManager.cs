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
        private List<Projectile> _projectiles;
        private WorldManager _worldManager = Game1.worldManager;

        public ProjectileManager(WorldManager worldManager)
        {
            _projectiles = new List<Projectile>();
        }

        public void Update(GameTime gameTime)
        {
            for (int i = _projectiles.Count - 1; i >= 0; i--)
            {
                _projectiles[i].Update(gameTime);
                bool collided = _worldManager.crateManager.CheckCollision(_projectiles[i].collisionRectangle);
                if (collided)
                {
                    _projectiles.Remove(_projectiles[i]);
                }
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (var projectile in _projectiles) projectile.Draw(spriteBatch);
        }

        public void AddProjectile(Projectile projectile)
        {
            _projectiles.Add(projectile);
        }
    }
}
