using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Extended;
using SpaceGame.Managers.ShipStateManagers;
using SpaceGame.Models;
using SpaceGame.Tiles;
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
        public ShipTileManager tileManager;
        public PeopleManager peopleManager;
        public SmallMenu activeMenu;

        public ShipStateManager()
        {
            tileManager = new ShipTileManager(LimitsEdgeGame.textures["ship_display_tiles"]);
            eventManager = new ShipEventManager();
            peopleManager = new PeopleManager(tileManager);

            LimitsEdgeGame.shipCamera.Position += (tileManager.GetShipSize() + new Vector2(Tile.tileSize)) / 2f;
        }

        public void Update(GameTime gameTime)
        {
            eventManager.Update(gameTime);
            peopleManager.Update(gameTime);

            // Prevent flickering by rounding camera position
            LimitsEdgeGame.shipCamera.Position = Helper.RoundVector2(LimitsEdgeGame.shipCamera.Position, 1);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            tileManager.Draw(spriteBatch);
            peopleManager.Draw(spriteBatch);
            if (activeMenu != null) activeMenu.Draw(spriteBatch);
        }
    }
}
