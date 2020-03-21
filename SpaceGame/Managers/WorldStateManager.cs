﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SpaceGame.Items;
using SpaceGame.Sprites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceGame.Managers
{
    public class WorldStateManager
    {
        public EventManager eventManager;

        public ParticleManager particleManager;
        public StarManager starManager;
        public ItemManager itemManager;
        public CrateManager crateManager;

        public WorldStateManager()
        {
            particleManager = new ParticleManager();
            eventManager = new EventManager();
            starManager = new StarManager();
            itemManager = new ItemManager();
            crateManager = new CrateManager();
        }

        public void Update(GameTime gameTime)
        {
            eventManager.Update(gameTime);
            starManager.Update(gameTime);
            itemManager.Update(gameTime);
            crateManager.Update(gameTime);
            particleManager.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            starManager.Draw(spriteBatch);
            itemManager.Draw(spriteBatch);
            crateManager.Draw(spriteBatch);
            particleManager.Draw(spriteBatch);
        }
    }
}