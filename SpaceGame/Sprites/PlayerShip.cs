using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonoGame.Extended;
using SpaceGame.Effects;
using SpaceGame.Projectiles;
using SpaceGame.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceGame.Sprites
{
    /// <summary>
    /// Class that defines a player's ship.
    /// </summary>
    public class PlayerShip : Spaceship
    {
        public float shotDelay = 0.2f;

        /// <summary>
        /// Creates an instance of the PlayerShip class.
        /// </summary>
        /// <param name="position">X and Y positions of the player ship.</param>
        /// <param name="texture">Texture of the player ship's body.</param>
        /// <param name="wingTexture">Texture of the player ship's wings.</param>
        public PlayerShip(Vector2 position, Texture2D texture, Texture2D wingTexture) 
            : base(position, texture, wingTexture)
        {
        }

        /// <summary>
        /// Sets the accelerations based on key inputs.
        /// </summary>
        /// <param name="t">Time since last tick.</param>
        public void SetAccelerations(float t)
        {
            KeyboardState keyboardState = Keyboard.GetState();

            if (keyboardState.IsKeyDown(Keys.A)) MoveAntiClockwise();
            else if (keyboardState.IsKeyDown(Keys.D)) MoveClockwise();
            else angularThrust = 0f;
            if (keyboardState.IsKeyDown(Keys.W)) MoveForward(t);
            else if (keyboardState.IsKeyDown(Keys.S)) MoveBackward(t);
            else linearThrust = 0f;
        }

        /// <summary>
        /// Gives the player ship positive rotational thrust.
        /// </summary>
        public void MoveClockwise()
        { 
            angularThrust = maxAngularThrust; 
        }

        /// <summary>
        /// Gives the player negative rotational thrust.
        /// </summary>
        public void MoveAntiClockwise()
        { 
            angularThrust = -maxAngularThrust;
        }

        /// <summary>
        /// Gives the player positive linear thrust.
        /// </summary>
        /// <param name="t">Time since last tick.</param>
        public void MoveForward(float t)
        {
            RotateWings(t);
            linearThrust = maxLinearThrust;
        }

        /// <summary>
        /// Gives the player negative linear thrust.
        /// </summary>
        /// <param name="t">Time since last tick.</param>
        public void MoveBackward(float t)
        {
            RotateWings(t);
            linearThrust = -maxLinearThrust;
        }

        /// <summary>
        /// Rotates the wings to align with the body.
        /// </summary>
        /// <param name="t">Time since last tick.</param>
        public void RotateWings(float t)
        {
            var deltaAngle = Helper.SimplifyRadians(wingRotation - rotation);
            if (deltaAngle < 0.1f) return;
            if (deltaAngle >= Math.PI) wingRotation = Helper.SimplifyRadians(wingRotation + wingAngularSpeed * t);
            else wingRotation = Helper.SimplifyRadians(wingRotation - wingAngularSpeed * t);
        }

        /// <summary>
        /// Adds smoke to the back of the ship (if permittable)
        /// </summary>
        /// <param name="t"></param>
        public void AddSmoke(float t)
        {
            currentSmokeDelay += t;
            if (currentSmokeDelay >= smokeDelay)
            {
                currentSmokeDelay -= smokeDelay;
                Vector2 smokePosition = position + Helper.RotateVector(new Vector2(0, Height / 2f), rotation);
                LimitsEdgeGame.particleManager.particles.Add(new Smoke(smokePosition, true));
            }
        }

        /// <summary>
        /// Shoots a lazer, matching ship rotation.
        /// </summary>
        public void AddProjectiles()
        {
            LimitsEdgeGame.projectileManager.projectiles.Add(new Lazer(position, rotation, Color.Red, facing * 300, 5));
        }

        /// <summary>
        /// Updates the player ship.
        /// </summary>
        /// <param name="gameTime">GameTime instance.</param>
        public override void Update(GameTime gameTime)
        {
            float t = (float)gameTime.ElapsedGameTime.TotalSeconds;
            SetAccelerations(t);
            if (linearThrust != 0) AddSmoke(t);
            base.Update(gameTime);
        }

        /// <summary>
        /// Draws the player ship.
        /// </summary>
        /// <param name="spriteBatch">SpriteBatch instance.</param>
        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);
        }
    }
}
