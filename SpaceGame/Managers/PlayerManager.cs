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
        public PlayerShip playerShip;
        Camera2D camera;

        public PlayerManager(Camera2D camera)
        {
            this.camera = camera;
            playerShip = new PlayerShip(Vector2.Zero, LimitsEdgeGame.textures["basic_ship_main"], LimitsEdgeGame.textures["basic_ship_wings"])
            {
                maxLinearThrust = 100000f,
                maxAngularThrust = 5000f,
                maxLinearVelocity = 250f,
                maxAngularVelocity = 3f,
                mass = 1000f,
                linearDragCoefficient = 10f,
                angularDragCoefficient = 600f,
                wingAngularSpeed = 2f
            };
        }

        public void Update(GameTime gameTime)
        {
            playerShip.Update(gameTime);
            camera.Position = playerShip.position - LimitsEdgeGame.screenSize / 2f;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            playerShip.Draw(spriteBatch);
        }
    }
}
