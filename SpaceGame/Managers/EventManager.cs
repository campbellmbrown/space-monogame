using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceGame.Managers
{
    /// <summary>
    /// Class to handle events.
    /// </summary>
    public class EventManager
    {
        protected DebugManager debugManager = LimitsEdgeGame.debugManager;
        protected bool holdingToggleDebug = false;
        protected float timeSinceLastShot = 0f;
        protected float shotDelay { get { return LimitsEdgeGame.playerManager.playerShip.shotDelay; } }

        /// <summary>
        /// Creates an instance of the EventManager class.
        /// </summary>
        public EventManager() { }

        /// <summary>
        /// Updates and checks for events.
        /// </summary>
        /// <param name="gameTime">GameTime instance.</param>
        public void Update(GameTime gameTime)
        {
            float t = (float)gameTime.ElapsedGameTime.TotalSeconds;
            KeyboardState keyboardState = Keyboard.GetState();
            CheckSinglePressKeys(keyboardState);
            CheckHeldKeyPress(keyboardState, t);
        }

        /// <summary>
        /// Checks for the event of single press keys.
        /// </summary>
        /// <param name="keyboardState">Current state of the keyboard.</param>
        public void CheckSinglePressKeys(KeyboardState keyboardState)
        {
            // Debugging toggle
            if (keyboardState.IsKeyDown(Keys.Tab))
            {
                if (!holdingToggleDebug) ToggleDebugLevels();
                holdingToggleDebug = true;
            }
            else holdingToggleDebug = false;
        }

        /// <summary>
        /// Checks for the event of held keys.
        /// </summary>
        /// <param name="keyboardState">Current state of the keyboard.</param>
        /// <param name="t">Time since last tick.</param>
        public void CheckHeldKeyPress(KeyboardState keyboardState, float t)
        {
            // Shooting
            if (keyboardState.IsKeyDown(Keys.Space))
            {
                timeSinceLastShot += t;
                if (timeSinceLastShot >= shotDelay)
                {
                    timeSinceLastShot -= shotDelay;
                    LimitsEdgeGame.playerManager.playerShip.AddProjectiles();
                }
            }
        }

        /// <summary>
        /// Changes the type of debug level.
        /// </summary>
        public void ToggleDebugLevels()
        {
            debugManager.ToggleDebugLevels();
        }
    }
}
