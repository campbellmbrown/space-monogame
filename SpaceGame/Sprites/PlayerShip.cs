using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonoGame.Extended;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceGame.Sprites
{
    public class PlayerShip : Spaceship
    {
        public PlayerShip(Vector2 position, Texture2D texture, Texture2D wingTexture) 
            : base(position, texture, wingTexture)
        {
        }

        public void SetAccelerations(float t)
        {
            KeyboardState keyboardState = Keyboard.GetState();
            bool holdingKey = false;

            if (keyboardState.IsKeyDown(Keys.A)) 
            {
                angularThrust = -maxAngularThrust;
                holdingKey = true;
            }
            else if (keyboardState.IsKeyDown(Keys.D))
            {
                angularThrust = maxAngularThrust;
                holdingKey = true;
            }
            if (keyboardState.IsKeyDown(Keys.W))
            {
                RotateWings(t);
                linearThrust = maxLinearThrust;
                holdingKey = true;
            }
            else if (keyboardState.IsKeyDown(Keys.S))
            {
                RotateWings(t);
                linearThrust = -maxLinearThrust;
                holdingKey = true;
            }
            if (!holdingKey)
            {
                angularThrust = 0f;
                linearThrust = 0f;
            }
        }

        public void RotateWings(float t)
        {
            var deltaAngle = wingRotation - rotation;
            if (deltaAngle < 0) deltaAngle += 2 * (float)Math.PI;
            //if ((deltaAngle < 0.1 * Math.PI) || (deltaAngle > 1.9 * Math.PI)) return; 
            if (deltaAngle >= Math.PI) wingRotation += 0.01f * linearVelocity * t;
            else wingRotation -= 0.01f * linearVelocity * t;
        }

        public override void Update(GameTime gameTime)
        {
            float t = (float)gameTime.ElapsedGameTime.TotalSeconds;
            SetAccelerations(t);
            Move(t);
            base.Update(gameTime);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.DrawLine(position + Direction * 20, position + Direction * 40, Color.Green);
            base.Draw(spriteBatch);
        }
    }
}
