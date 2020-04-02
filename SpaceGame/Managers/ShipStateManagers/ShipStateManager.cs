using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Extended;
using SpaceGame.Managers.ShipStateManagers;
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
        public PeopleManager peopleManager;
        protected ItemHolderManager itemHolderManager;

        public ShipStateManager()
        {
            tileManager = new ShipTileManager(LimitsEdgeGame.textures["ship_layout"]);
            eventManager = new ShipEventManager();
            peopleManager = new PeopleManager(tileManager);
            itemHolderManager = new ItemHolderManager();

            LimitsEdgeGame.shipCamera.Position += (tileManager.GetShipSize() + new Vector2(Tile.tileSize)) / 2f;
        }

        public void Update(GameTime gameTime)
        {
            eventManager.Update(gameTime);
            peopleManager.Update(gameTime);
            itemHolderManager.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            tileManager.Draw(spriteBatch);
            peopleManager.Draw(spriteBatch);
            itemHolderManager.Draw(spriteBatch);
        }
    }
}
