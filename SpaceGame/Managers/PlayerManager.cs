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
        public Vector2 playerVelocity { get { return playerShip.direction * playerShip.linearVelocity; } }
        public Vector2 playerPosition { get { return playerShip.position; } }
        Camera2D camera;

        public PlayerManager(Camera2D camera)
        {
            this.camera = camera;
            playerShip = new PlayerShip(Vector2.Zero, Game1.textures["basic_ship_main"], Game1.textures["basic_ship_wings"])
            {
                maxLinearThrust = 50000f,
                maxAngularThrust = 5000f,
                maxLinearVelocity = 80f,
                maxAngularVelocity = 3f,
                mass = 1000f,
                linearDragCoefficient = 0f,
                angularDragCoefficient = 0f
            };
        }

        public void Update(GameTime gameTime)
        {
            playerShip.Update(gameTime);
            camera.Position = playerShip.position - Game1.screenSize / 2f;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            playerShip.Draw(spriteBatch);
        }
    }
}
