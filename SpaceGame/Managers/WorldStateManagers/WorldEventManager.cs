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
        protected float shotDelay { get { return LimitsEdgeGame.worldStateManager.playerManager.playerShip.shotDelay; } }

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
                    LimitsEdgeGame.SwitchState(GameState.World, GameState.InGameMenu);
                }
                holdingInGameMenu = true;
            }
            else holdingInGameMenu = false;

            // Ship inventory
            if (keyboardState.IsKeyDown(Keys.E))
            {
                if (!holdingShipInv)
                {
                    LimitsEdgeGame.SwitchState(GameState.World, GameState.Inventory);
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
            timeSinceLastShot += t;
            if (keyboardState.IsKeyDown(Keys.Space))
            {
                if (timeSinceLastShot >= shotDelay)
                {
                    timeSinceLastShot = 0;
                    LimitsEdgeGame.worldStateManager.playerManager.playerShip.AddProjectiles();
                }
            }
        }
    }
}
