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
        public PlayerShip(Vector2 position, Texture2D texture, float maxAcceleration, float maxVelocity, float maxAngularVelocity, float maxAngularAcceleration) 
            : base(position, texture, maxAcceleration, maxVelocity, maxAngularVelocity, maxAngularAcceleration)
        {
        }

        public void SetAccelerations(float t)
        {
            KeyboardState keyboardState = Keyboard.GetState();
            
            if (keyboardState.IsKeyDown(Keys.A)) 
            {
                angularAcceleration = -maxAngularAcceleration;
            }
            else if (keyboardState.IsKeyDown(Keys.D))
            {
                angularAcceleration = maxAngularAcceleration;
            }
            else if (keyboardState.IsKeyDown(Keys.W))
            {
                acceleration = maxAcceleration * Direction;
            }
            else if (keyboardState.IsKeyDown(Keys.S))
            {
                acceleration = -maxAcceleration * Direction;
            }
            else
            {
                angularAcceleration = 0f;
                acceleration = Vector2.Zero;
            }
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
