using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using MonoGame.Extended;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceGame.Managers
{
    public class ShipEventManager
    {
        protected bool holdingExitShip = true;
        protected bool holdingZoomIn = true;
        protected bool holdingZoomOut = true;

        public int previousScrollValue;
        protected float maxZoom = 20f;
        protected float minZoom = 0.6f;
        protected float zoomIncrement = 0.2f;

        public ShipEventManager() 
        { 
            previousScrollValue = Mouse.GetState().ScrollWheelValue; 
        }

        public void Update(GameTime gameTime)
        {
            float t = (float)gameTime.ElapsedGameTime.TotalSeconds;
            KeyboardState keyboardState = Keyboard.GetState();
            MouseState mouseState = Mouse.GetState();
            CheckSinglePressKeys(keyboardState);
            CheckHeldKeyPress(keyboardState, t);
            CheckScroll(mouseState);
        }

        public void CheckSinglePressKeys(KeyboardState keyboardState)
        {
            // Exit ship
            if (keyboardState.IsKeyDown(Keys.E))
            {
                if (!holdingExitShip)
                {
                    LimitsEdgeGame.SwitchState(GameState.Spaceship, GameState.World);
                    LimitsEdgeGame.currentCamera = LimitsEdgeGame.worldCamera;
                }
                holdingExitShip = true;
            }
            else holdingExitShip = false;
        }

        public void CheckScroll(MouseState mouseState)
        {
            int difference = mouseState.ScrollWheelValue - previousScrollValue;
            if (difference != 0)
            {
                Camera2D camera = LimitsEdgeGame.shipCamera;
                switch (Math.Sign(difference))
                {
                    case 1:
                        if (camera.Zoom < maxZoom) camera.Zoom += zoomIncrement;
                        break;
                    case -1:
                        if (camera.Zoom > minZoom) camera.Zoom -= zoomIncrement;
                        break;
                }
                previousScrollValue = mouseState.ScrollWheelValue;
            }
        }

        public void CheckHeldKeyPress(KeyboardState keyboardState, float t)
        {

        }
    }
}
