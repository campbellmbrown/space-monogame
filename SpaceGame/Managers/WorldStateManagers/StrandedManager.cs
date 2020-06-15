using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SpaceGame.Sprites.WorldStateSprites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceGame.Managers.WorldStateManagers
{
    public class StrandedManager
    {
        public List<Stranded> strandeds;
        protected RespawnManager respawnManager;
        protected float maxStrandeds = 2;

        public StrandedManager()
        {
            strandeds = new List<Stranded>();
            respawnManager = new RespawnManager(100, 100, 10);
        }

        public void Update(GameTime gameTime)
        {
            for (int i = strandeds.Count - 1; i >= 0; i--)
            {
                strandeds[i].Update(gameTime);
                if (respawnManager.OutOfBounds(strandeds[i].position))
                {
                    strandeds.RemoveAt(i);
                }
            }
            TopUpStrandeds();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (var stranded in strandeds) stranded.Draw(spriteBatch);
        }

        public void TopUpStrandeds()
        {
            for (int i = strandeds.Count; i < maxStrandeds; ++i)
            {
                strandeds.Add(new Stranded(respawnManager.GenerateNewPosition(), true));
            }
        }
    }
}
