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
