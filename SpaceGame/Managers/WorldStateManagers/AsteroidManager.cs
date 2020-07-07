using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SpaceGame.Effects;
using SpaceGame.Sprites.WorldStateSprites;
using SpaceGame.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceGame.Managers.WorldStateManagers
{
    public class AsteroidManager
    {
        public List<Asteroid> asteroids;
        protected RespawnManager respawnManager;
        protected int maxCrates = 2;

        public AsteroidManager()
        {
            asteroids = new List<Asteroid>();
            respawnManager = new RespawnManager(100, 100, 10);
        }

        public void Update(GameTime gameTime)
        {
            for (int i = asteroids.Count - 1; i >= 0; i--)
            {
                asteroids[i].Update(gameTime);
                if (respawnManager.OutOfBounds(asteroids[i].position))
                {
                    RemoveAsteroids(i);
                }
            }
            TopUpAsteroids();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (var crate in asteroids) crate.Draw(spriteBatch);
        }

        public void TopUpAsteroids()
        {
            for (int i = asteroids.Count; i < maxCrates; ++i)
            {
                asteroids.Add(new Asteroid(respawnManager.GenerateNewPosition(), true));
            }
        }

        public bool CheckCollision(Rectangle collisionRectangle, Vector2 collisionObjectVelocity, int damage = 0)
        {
            for (int i = asteroids.Count - 1; i >= 0; i--)
            {
                if (asteroids[i].CheckCollision(collisionRectangle))
                {
                    Rectangle crateCollision = asteroids[i].collisionRectangle;
                    asteroids[i].linearVelocity += collisionObjectVelocity;
                    Vector2 crateLinearVelocity = asteroids[i].linearVelocity;
                    if (asteroids[i].DepleteHealth(damage))
                    {
                        asteroids[i].BreakAction();
                        RemoveAsteroids(i);
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

        public void RemoveAsteroids(int i)
        {
            asteroids.RemoveAt(i);
        }
    }
}
