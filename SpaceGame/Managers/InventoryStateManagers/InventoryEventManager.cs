using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using MonoGame.Extended;
using SpaceGame.Models;
using SpaceGame.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceGame.Managers.InventoryStateManagers
{
    public class InventoryEventManager
    {
        protected bool holdingExitInventory = true;
        protected bool holdingZoomIn = true;
        protected bool holdingZoomOut = true;
        protected bool holdingLeftClick = true;

        public InventoryEventManager()
        {
        }

        public void Update(GameTime gameTime)
        {
            float t = (float)gameTime.ElapsedGameTime.TotalSeconds;
            KeyboardState keyboardState = Keyboard.GetState();
            MouseState mouseState = Mouse.GetState();
            CheckSinglePressKeys(keyboardState);
            CheckHeldKeyPress(keyboardState, t);
            CheckSingleLeftClick(mouseState);
            LimitsEdgeGame.inventoryStateManager.Hover(LimitsEdgeGame.mousePosition);
        }

        public void CheckSinglePressKeys(KeyboardState keyboardState)
        {
            // Exit ship
            if (keyboardState.IsKeyDown(Keys.E))
            {
                if (!holdingExitInventory)
                {
                    LimitsEdgeGame.SwitchState(GameState.Inventory, GameState.World);
                    LimitsEdgeGame.currentCamera = LimitsEdgeGame.worldCamera;
                }
                holdingExitInventory = true;
            }
            else holdingExitInventory = false;
        }

        public void CheckHeldKeyPress(KeyboardState keyboardState, float t)
        {

        }

        public void CheckSingleLeftClick(MouseState mouseState)
        {
            if (mouseState.LeftButton == ButtonState.Pressed)
            {
                if (!holdingLeftClick)
                {
                    LimitsEdgeGame.inventoryStateManager.Click(LimitsEdgeGame.mousePosition);
                }
                holdingLeftClick = true;
            }
            else holdingLeftClick = false;
        }
    }
}
