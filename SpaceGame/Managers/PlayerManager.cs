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
    /// <summary>
    /// Class to manager the player.
    /// </summary>
    public class PlayerManager
    {
        public PlayerShip playerShip;
        Camera2D camera;

        /// <summary>
        /// Creates an instance of the PlayerManager class.
        /// </summary>
        /// <param name="camera">The camera that follows the player.</param>
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

        /// <summary>
        /// Updates the player.
        /// </summary>
        /// <param name="gameTime">GameTime instance.</param>
        public void Update(GameTime gameTime)
        {
            playerShip.Update(gameTime);
            camera.Position = playerShip.position - LimitsEdgeGame.screenSize / 2f;
        }

        /// <summary>
        /// Draws the player.
        /// </summary>
        /// <param name="spriteBatch">SpriteBatch instance.</param>
        public void Draw(SpriteBatch spriteBatch)
        {
            playerShip.Draw(spriteBatch);
        }
    }
}
