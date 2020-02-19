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

        public EventManager() { }

        public void Update(GameTime gameTime)
        {
            KeyboardState keyboardState = Keyboard.GetState();
            CheckSinglePressKeys(keyboardState);
        }

        public void CheckSinglePressKeys(KeyboardState keyboardState)
        {
            if (keyboardState.IsKeyDown(Keys.Tab))
            {
                if (!holdingToggleDebug) ToggleDebugLevels();
                holdingToggleDebug = true;
            }
            else holdingToggleDebug = false;
        }

        public void ToggleDebugLevels()
        {
            debugManager.ToggleDebugLevels();
        }
    }
}
