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
        private List<Crate> _crates;
        protected RespawnManager respawnManager;
        protected int maxCrates = 5;
        public CrateManager()
        {
            _crates = new List<Crate>();
            respawnManager = new RespawnManager(100, 100, 10);
        }

        public void Update(GameTime gameTime)
        {
            for (int i = _crates.Count - 1; i >= 0; i--)
            {
                _crates[i].Update(gameTime);
                if (respawnManager.OutOfBounds(_crates[i].position))
                {
                    _crates.RemoveAt(i);
                }
            }
            TopUpCrates();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (var crate in _crates) crate.Draw(spriteBatch);
        }

        public void AddCrate(Crate crate)
        {
            _crates.Add(crate);
        }

        public void TopUpCrates()
        {
            for (int i = _crates.Count; i < maxCrates; ++i)
            {
                AddCrate(new Crate(respawnManager.GenerateNewPosition(), true));
            }
        }

        public bool CheckCollision(Rectangle collisionRectangle)
        {
            for (int i = _crates.Count - 1; i >= 0; i--)
            {
                if (_crates[i].CheckCollision(collisionRectangle))
                {
                    _crates[i].BreakAction();
                    _crates.RemoveAt(i);
                    return true;
                }
            }
            return false;
        }

        public int CrateCount()
        {
            return _crates.Count();
        }
    }
}
