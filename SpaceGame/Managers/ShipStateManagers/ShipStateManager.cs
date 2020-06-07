using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Extended;
using SpaceGame.Managers.ShipStateManagers;
using SpaceGame.Models;
using SpaceGame.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceGame.Managers
{
    public class ShipStateManager
    {
        public ShipEventManager eventManager;
        protected PlayerManager playerManager;
        public ShipMenuManager menuManager;

        public ShipStateManager()
        {
            eventManager = new ShipEventManager();
            playerManager = LimitsEdgeGame.worldStateManager.playerManager;
            menuManager = new ShipMenuManager();
            // LimitsEdgeGame.shipCamera.Position += (tileManager.GetShipSize() + new Vector2(Tile.tileSize)) / 2f;
        }

        public void Update(GameTime gameTime)
        {
            eventManager.Update(gameTime);

            // Prevent flickering by rounding camera position
            LimitsEdgeGame.shipCamera.Position = Helper.RoundVector2(LimitsEdgeGame.shipCamera.Position, 1);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            menuManager.Draw(spriteBatch);
        }
    }
}
