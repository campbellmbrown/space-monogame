using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using SpaceGame.Sprites.WorldStateSprites;
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
        protected bool holdingSwitchLockOn = true;
        protected bool holdingLockOn = true;

        protected float timeSinceLastShot = 0f;
        protected float shotDelay { get { return LimitsEdgeGame.worldStateManager.playerManager.playerShip.shotDelay; } }

        public WorldEventManager() { }

        public void Update(GameTime gameTime)
        {
            float t = (float)gameTime.ElapsedGameTime.TotalSeconds;
            KeyboardState keyboardState = Keyboard.GetState();
            CheckHeldKeyPress(keyboardState, t);
            CheckSinglePressKeys(keyboardState);
        }

        public void CheckSinglePressKeys(KeyboardState keyboardState)
        {
            PlayerShip playerShip = LimitsEdgeGame.worldStateManager.playerManager.playerShip;

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

            if (keyboardState.IsKeyDown(Keys.Q))
            {
                if (!holdingSwitchLockOn)
                {
                    foreach (var crate in LimitsEdgeGame.worldStateManager.crateManager.crates)
                    {
                        if (playerShip.lockOnSprite != crate && (crate.position - playerShip.position).Length() < playerShip.lockOnRange)
                        {
                            playerShip.SetLockOnSprite(crate);
                            break;
                        }
                    }
                }
                holdingSwitchLockOn = true;
            }
            else holdingSwitchLockOn = false;

            if (keyboardState.IsKeyDown(Keys.R))
            {
                if (!holdingLockOn && playerShip.lockOnSprite != null)
                    playerShip.lockOnDistance = (playerShip.lockOnSprite.position - playerShip.position).Length();
                holdingLockOn = true;
            }
            else holdingLockOn = false;
        }

        public void CheckHeldKeyPress(KeyboardState keyboardState, float t)
        {
            PlayerShip playerShip = LimitsEdgeGame.worldStateManager.playerManager.playerShip;
            playerShip.SetLockOn(false);

            // Shooting
            timeSinceLastShot += t;
            if (keyboardState.IsKeyDown(Keys.Space))
            {
                if (timeSinceLastShot >= shotDelay)
                {
                    timeSinceLastShot = 0;
                    playerShip.AddProjectiles();
                }
            }

            if (keyboardState.IsKeyDown(Keys.R))
            {
                playerShip.SetLockOn(true);
            }
        }
    }
}
