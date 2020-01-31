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
            var deltaAngle = Helper.SimplifyRadians(wingRotation - rotation);
            if (deltaAngle < 0.1f) return;
            if (deltaAngle >= Math.PI) wingRotation = Helper.SimplifyRadians(wingRotation + wingAngularSpeed * t);
            else wingRotation = Helper.SimplifyRadians(wingRotation - wingAngularSpeed * t);
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
            spriteBatch.DrawLine(position + facing * 20, position + facing * 40, Color.Green);
            spriteBatch.DrawLine(position + direction * 20, position + direction * 40, Color.Blue);
            base.Draw(spriteBatch);
        }
    }
}
