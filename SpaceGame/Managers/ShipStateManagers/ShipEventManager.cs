using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonoGame.Extended;
using SpaceGame.Utilities;
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
        protected bool holdingLeftClick = true;

        protected float movementBandWidth { get { return 100f / LimitsEdgeGame.currentZoom; } }
        protected Vector2 topLeft { get { return LimitsEdgeGame.topLeft; } }
        protected Vector2 screenSize { get { return LimitsEdgeGame.zoomedScreenSize; } }
        protected RectangleF topRectangle { get { return new RectangleF(topLeft.X, topLeft.Y, screenSize.X, movementBandWidth); } }
        protected RectangleF bottomRectangle { get { return new RectangleF(topLeft.X, topLeft.Y + screenSize.Y - movementBandWidth, screenSize.X, movementBandWidth); } }
        protected RectangleF leftRectangle { get { return new RectangleF(topLeft.X, topLeft.Y, movementBandWidth, screenSize.Y); } }
        protected RectangleF rightRectangle { get { return new RectangleF(topLeft.X + screenSize.X - movementBandWidth, topLeft.Y, movementBandWidth, screenSize.Y); } }
        protected float movementSpeed { get { return 400f / LimitsEdgeGame.currentZoom; } }

        public int previousScrollValue;
        protected float maxZoom = 32f;
        protected float minZoom = 1f;

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
            CheckSingleLeftClick(mouseState);
            CheckScroll(mouseState);
            CheckMovement(t);
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
                        if (camera.Zoom < maxZoom) camera.Zoom += 1;
                        break;
                    case -1:
                        if (camera.Zoom > minZoom) camera.Zoom -= 1;
                        break;
                }
                previousScrollValue = mouseState.ScrollWheelValue;
            }
        }

        public void CheckHeldKeyPress(KeyboardState keyboardState, float t)
        {

        }

        public void CheckMovement(float t)
        {
            Camera2D camera = LimitsEdgeGame.shipCamera;
            Vector2 cameraPosition = camera.Position;
            Point2 mousePosition = Helper.Vector2ToPoint2(LimitsEdgeGame.mousePosition);
            if (topRectangle.Contains(mousePosition)) camera.Position = cameraPosition -= new Vector2(0, movementSpeed * t);
            else if (bottomRectangle.Contains(mousePosition)) camera.Position = cameraPosition += new Vector2(0, movementSpeed * t);
            if (leftRectangle.Contains(mousePosition)) camera.Position = cameraPosition -= new Vector2(movementSpeed * t, 0);
            else if (rightRectangle.Contains(mousePosition)) camera.Position = cameraPosition += new Vector2(movementSpeed * t, 0);
        }

        public void CheckSingleLeftClick(MouseState mouseState)
        {
            if (mouseState.LeftButton == ButtonState.Pressed)
            {
                if (!holdingLeftClick)
                {
                    foreach (var holdingTile in LimitsEdgeGame.shipStateManager.tileManager.holdingTiles)
                    {
                        if (holdingTile.interactionRectangle.Contains(LimitsEdgeGame.mousePosition))
                        {
                            if (LimitsEdgeGame.shipStateManager.activeMenu == holdingTile.menu)
                            {
                                LimitsEdgeGame.shipStateManager.activeMenu = null;
                                continue;
                            }
                            LimitsEdgeGame.shipStateManager.activeMenu = holdingTile.menu;
                        }
                    }
                }
                holdingLeftClick = true;
            }
            else holdingLeftClick = false;
        }
    }
}
