using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Extended;
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
        Camera2D camera;

        public PlayerManager(Camera2D camera)
        {
            this.camera = camera;
            playerShip = new PlayerShip(Vector2.Zero, Game1.textures["basic_ship_main"], 30f, 10f, 10f, 5f);
        }

        public void Update(GameTime gameTime)
        {
            playerShip.Update(gameTime);
            camera.Position = playerShip.position - Game1.ScreenSize / 2f;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            playerShip.Draw(spriteBatch);
        }
    }
}
