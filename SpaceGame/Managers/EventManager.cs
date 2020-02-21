using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceGame.Managers
{
    public class EventManager
    {
        protected DebugManager debugManager = Game1.debugManager;
        protected bool holdingToggleDebug = false;
        protected float timeSinceLastShot = 0f;
        protected float shotDelay { get { return Game1.playerManager.playerShip.shotDelay; } }

        public EventManager() { }

        public void Update(GameTime gameTime)
        {
            float t = (float)gameTime.ElapsedGameTime.TotalSeconds;
            KeyboardState keyboardState = Keyboard.GetState();
            CheckSinglePressKeys(keyboardState);
            CheckHeldKeyPress(keyboardState, t);
        }

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

        public void CheckHeldKeyPress(KeyboardState keyboardState, float t)
        {
            // Shooting
            if (keyboardState.IsKeyDown(Keys.Space))
            {
                timeSinceLastShot += t;
                if (timeSinceLastShot >= shotDelay)
                {
                    timeSinceLastShot -= shotDelay;
                    Game1.playerManager.playerShip.AddProjectiles();
                }
            }
        }

        public void ToggleDebugLevels()
        {
            debugManager.ToggleDebugLevels();
        }
    }
}
