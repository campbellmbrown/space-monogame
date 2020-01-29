using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SpaceGame.Sprites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceGame.Managers
{
    public class PlayerManager
    {
        PlayerShip playerShip;

        public PlayerManager()
        {
            playerShip = new PlayerShip(Game1.ScreenCenter, Game1.textures["basic_ship_main"], 30f, 10f, 10f, 5f);
        }

        public void Update(GameTime gameTime)
        {
            playerShip.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            playerShip.Draw(spriteBatch);
        }
    }
}
