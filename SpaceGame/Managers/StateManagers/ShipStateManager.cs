using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Extended;
using SpaceGame.Managers.EventManagers;
using SpaceGame.Tiles;
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
        public ShipTileManager tileManager;

        public ShipStateManager()
        {
            tileManager = new ShipTileManager(LimitsEdgeGame.textures["ship_layout"]);
            eventManager = new ShipEventManager();

            LimitsEdgeGame.shipCamera.Position += (tileManager.GetShipSize() + new Vector2(Tile.tileSize)) / 2f;
        }

        public void Update(GameTime gameTime)
        {
            eventManager.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            tileManager.Draw(spriteBatch);
        }
    }
}
