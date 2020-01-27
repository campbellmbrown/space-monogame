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
        public PlayerShip(Vector2 position, Texture2D texture, float maxAcceleration, float maxSpeed) : base(position, texture, maxAcceleration, maxSpeed)
        {
        }

        public void DetectMovement()
        {
            KeyboardState keyboardState = Keyboard.GetState();
            
            if (keyboardState.IsKeyDown(Keys.A)) 
            {
                velocity.X = -10f;
            }
            else if (keyboardState.IsKeyDown(Keys.D))
            {
                velocity.X = 10f;
            }
            else if (keyboardState.IsKeyDown(Keys.W))
            {
                velocity.Y = 10f;
            }
            else if (keyboardState.IsKeyDown(Keys.S))
            {
                velocity.Y = 10f;
            }
        }

        public override void Update(GameTime gameTime)
        {
            float t = (float)gameTime.ElapsedGameTime.TotalSeconds;
            DetectMovement();
            Move(t);
            base.Update(gameTime);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.DrawRectangle(new Rectangle((int)position.X, (int)position.Y, 10, 10), Color.Red);
            base.Draw(spriteBatch);
        }
    }
}
