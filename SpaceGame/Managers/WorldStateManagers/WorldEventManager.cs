using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceGame.Managers
{
    public class WorldEventManager
    {
        protected bool holdingToggleDebug = true;
        protected bool holdingInGameMenu = true;
        protected bool holdingShipInv = true;

        protected float timeSinceLastShot = 0f;
        protected float shotDelay { get { return LimitsEdgeGame.playerManager.playerShip.shotDelay; } }

        public WorldEventManager() { }

        public void Update(GameTime gameTime)
        {
            float t = (float)gameTime.ElapsedGameTime.TotalSeconds;
            KeyboardState keyboardState = Keyboard.GetState();
            CheckSinglePressKeys(keyboardState);
            CheckHeldKeyPress(keyboardState, t);
        }

        public void CheckSinglePressKeys(KeyboardState keyboardState)
        {
            // In-game menu
            if (keyboardState.IsKeyDown(Keys.Escape))
            {
                if (!holdingInGameMenu)
                {
                    LimitsEdgeGame.gameState = GameState.InGameMenu;
                    LimitsEdgeGame.currentCamera = LimitsEdgeGame.inGameMenuCamera;
                }
                holdingInGameMenu = true;
            }
            else holdingInGameMenu = false;

            // Ship inventory
            if (keyboardState.IsKeyDown(Keys.E))
            {
                if (!holdingShipInv)
                {
                    LimitsEdgeGame.gameState = GameState.Spaceship;
                    LimitsEdgeGame.currentCamera = LimitsEdgeGame.shipCamera;
                }
                holdingShipInv = true;
            }
            else holdingShipInv = false;

            // Debugging toggle
            if (keyboardState.IsKeyDown(Keys.Tab))
            {
                if (!holdingToggleDebug) LimitsEdgeGame.worldStateManager.debugManager.ToggleDebugLevels();
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
                    LimitsEdgeGame.playerManager.playerShip.AddProjectiles();
                }
            }
        }
    }
}
