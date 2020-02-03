﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SpaceGame.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceGame.Managers
{
    public class WorldManager
    {
        StarManager starManager;
        ItemManager itemManager;

        public WorldManager()
        {
            starManager = new StarManager();
            itemManager = new ItemManager();
        }

        public void Update(GameTime gameTime)
        {
            starManager.Update(gameTime);
            itemManager.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            starManager.Draw(spriteBatch);
            itemManager.Draw(spriteBatch);
        }
    }
}
