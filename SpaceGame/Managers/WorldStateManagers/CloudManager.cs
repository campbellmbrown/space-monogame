using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SpaceGame.World;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceGame.Managers.WorldStateManagers
{
    public class CloudManager
    {
        public List<Cloud> clouds;
        protected RespawnManager respawnManager;
        protected int maxClouds = 5;

        public CloudManager()
        {
            clouds = new List<Cloud>();
            respawnManager = new RespawnManager(100, 100, 10);
        }

        public void Update(GameTime gameTime)
        {
            for (int i = clouds.Count - 1; i >= 0; i--)
            {
                clouds[i].Update(gameTime);
                if (respawnManager.OutOfBounds(clouds[i].position))
                {
                    clouds.RemoveAt(i);
                }
            }
            TopUpClouds();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (var cloud in clouds) cloud.Draw(spriteBatch);
        }

        public void TopUpClouds()
        {
            for (int i = clouds.Count; i < maxClouds; ++i)
            {
                clouds.Add(new Cloud(respawnManager.GenerateNewPosition()));
            }
        }
    }
}
