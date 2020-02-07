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

        public ProjectileManager()
        {
            _projectiles = new List<Projectile>();
        }

        public void Update(GameTime gameTime)
        {
            foreach (var projectile in _projectiles) projectile.Update(gameTime);
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
