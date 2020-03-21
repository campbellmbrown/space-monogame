using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceGame.Managers.EventManagers
{
    public class InGameMenuEventManager
    {
        public bool holdingExitMenu = true;

        public InGameMenuEventManager() { }

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
                if (!holdingExitMenu) LimitsEdgeGame.gameState = GameState.World;
                holdingExitMenu = true;
            }
            else holdingExitMenu = false;
        }

        public void CheckHeldKeyPress(KeyboardState keyboardState, float t)
        {

        }
    }
}
