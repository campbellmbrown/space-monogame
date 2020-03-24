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
        public WorldEventManager eventManager;
        public ProjectileManager projectileManager;
        public ParticleManager particleManager;
        public StarManager starManager;
        public ItemManager itemManager;
        public CrateManager crateManager;
        public GuiManager guiManager;
        public DebugManager debugManager;

        public WorldStateManager()
        {
            projectileManager = new ProjectileManager();
            particleManager = new ParticleManager();
            eventManager = new WorldEventManager();
            starManager = new StarManager();
            itemManager = new ItemManager();
            crateManager = new CrateManager();
            guiManager = new GuiManager();
            debugManager = new DebugManager();
            crateManager.TopUpCrates();
        }

        public void Update(GameTime gameTime)
        {
            eventManager.Update(gameTime);
            starManager.Update(gameTime);
            itemManager.Update(gameTime);
            crateManager.Update(gameTime);
            particleManager.Update(gameTime);
            projectileManager.Update(gameTime);
            guiManager.Update(gameTime);
            debugManager.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            starManager.Draw(spriteBatch);
            itemManager.Draw(spriteBatch);
            crateManager.Draw(spriteBatch);
            particleManager.Draw(spriteBatch);
            projectileManager.Draw(spriteBatch);
            guiManager.Draw(spriteBatch);
            debugManager.Draw(spriteBatch);
        }
    }
}