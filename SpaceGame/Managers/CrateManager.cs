﻿using Microsoft.Xna.Framework;
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

        public CrateManager()
        {
            _crates = new List<Crate>();
            _crates.Add(new Crate(Vector2.Zero, true));
        }

        public void Update(GameTime gameTime)
        {
            foreach (var crate in _crates) crate.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (var crate in _crates) crate.Draw(spriteBatch);
        }

        public void AddCrate(Crate crate)
        {
            _crates.Add(crate);
        }
    }
}
