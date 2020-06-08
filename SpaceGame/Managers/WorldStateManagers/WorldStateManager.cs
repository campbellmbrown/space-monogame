using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SpaceGame.Items;
using SpaceGame.Managers.WorldStateManagers;
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
        public CloudManager cloudManager;
        public ItemManager itemManager;
        public CrateManager crateManager;
        public GuiManager guiManager;
        public DebugManager debugManager;
        public PlayerManager playerManager;

        public WorldStateManager()
        {
            projectileManager = new ProjectileManager();
            particleManager = new ParticleManager();
            eventManager = new WorldEventManager();
            starManager = new StarManager();
            cloudManager = new CloudManager();
            itemManager = new ItemManager();
            crateManager = new CrateManager();
            guiManager = new GuiManager();
            debugManager = new DebugManager();
            playerManager = new PlayerManager(LimitsEdgeGame.worldCamera);
            crateManager.TopUpCrates();
            cloudManager.TopUpClouds();
        }

        public void Update(GameTime gameTime)
        {
            playerManager.Update(gameTime);
            eventManager.Update(gameTime);
            starManager.Update(gameTime);
            itemManager.Update(gameTime);
            crateManager.Update(gameTime);
            particleManager.Update(gameTime);
            cloudManager.Update(gameTime);
            projectileManager.Update(gameTime);
            guiManager.Update(gameTime);
            debugManager.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            cloudManager.Draw(spriteBatch);
            starManager.Draw(spriteBatch);
            itemManager.Draw(spriteBatch);
            crateManager.Draw(spriteBatch);
            particleManager.Draw(spriteBatch);
            projectileManager.Draw(spriteBatch);
            playerManager.Draw(spriteBatch);
            guiManager.Draw(spriteBatch);
            debugManager.Draw(spriteBatch);
        }
    }
}
