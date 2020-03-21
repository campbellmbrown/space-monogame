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
    public class CrateManager
    {
        public List<Crate> crates;
        protected RespawnManager respawnManager;
        protected int maxCrates = 2;

        public CrateManager()
        {
            crates = new List<Crate>();
            respawnManager = new RespawnManager(100, 100, 10);
        }

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

        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (var crate in crates) crate.Draw(spriteBatch);
        }

        public void TopUpCrates()
        {
            for (int i = crates.Count; i < maxCrates; ++i)
            {
                crates.Add(new Crate(respawnManager.GenerateNewPosition(), true));
            }
        }

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

        public void AddSmallExplosion(Rectangle rectangle, Vector2 linearVelocity)
        {
            Vector2 explosionPosition = Helper.RandomPosInRectangle(rectangle);
            for (int i = 0; i < 3; ++i) LimitsEdgeGame.worldStateManager.particleManager.particles.Add(new Smoke(explosionPosition, true));
            LimitsEdgeGame.worldStateManager.particleManager.particles.Add(new SmallExplosion(explosionPosition, false) { linearVelocity = linearVelocity });
        }
    }
}