using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceGame.Managers.EventManagers
{
    public class ShipEventManager
    {
        protected bool holdingExitShip = true;

        public ShipEventManager() { }

        public void Update(GameTime gameTime)
        {
            float t = (float)gameTime.ElapsedGameTime.TotalSeconds;
            KeyboardState keyboardState = Keyboard.GetState();
            CheckSinglePressKeys(keyboardState);
            CheckHeldKeyPress(keyboardState, t);
        }

        public void CheckSinglePressKeys(KeyboardState keyboardState)
        {
            // Exit ship
            if (keyboardState.IsKeyDown(Keys.E))
            {
                if (!holdingExitShip) LimitsEdgeGame.gameState = GameState.World;
                holdingExitShip = true;
            }
            else holdingExitShip = false;
        }

        public void CheckHeldKeyPress(KeyboardState keyboardState, float t)
        {

        }
    }
}
