using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonoGame.Extended;
using SpaceGame.Effects;
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
        private bool _holdingInfoToggle = false;
        private bool _showInfo = false;

        public PlayerShip(Vector2 position, Texture2D texture, Texture2D wingTexture) 
            : base(position, texture, wingTexture)
        {
        }

        public void SetAccelerations(float t)
        {
            KeyboardState keyboardState = Keyboard.GetState();

            if (keyboardState.IsKeyDown(Keys.A)) 
            {
                angularThrust = -maxAngularThrust;
            }
            else if (keyboardState.IsKeyDown(Keys.D))
            {
                angularThrust = maxAngularThrust;
            } else
            {
                angularThrust = 0f;
            }
            if (keyboardState.IsKeyDown(Keys.W))
            {
                RotateWings(t);
                linearThrust = maxLinearThrust;
            }
            else if (keyboardState.IsKeyDown(Keys.S))
            {
                RotateWings(t);
                linearThrust = -maxLinearThrust;
            }
            else
            {
                linearThrust = 0f;
            }
            if (keyboardState.IsKeyDown(Keys.Tab))
            {
                if (!_holdingInfoToggle)
                    _showInfo = !_showInfo;
                _holdingInfoToggle = true;
            }
            else
                _holdingInfoToggle = false;
        }

        public void RotateWings(float t)
        {
            var deltaAngle = Helper.SimplifyRadians(wingRotation - rotation);
            if (deltaAngle < 0.1f) return;
            if (deltaAngle >= Math.PI) wingRotation = Helper.SimplifyRadians(wingRotation + wingAngularSpeed * t);
            else wingRotation = Helper.SimplifyRadians(wingRotation - wingAngularSpeed * t);
        }

        public void AddSmoke(float t)
        {
            currentSmokeDelay += t;
            if (currentSmokeDelay >= smokeDelay)
            {
                currentSmokeDelay -= smokeDelay;
                Game1.particleManager.AddParticle(new Smoke(position));
            }
        }

        public override void Update(GameTime gameTime)
        {
            float t = (float)gameTime.ElapsedGameTime.TotalSeconds;
            SetAccelerations(t);
            if (linearThrust != 0) AddSmoke(t);
            Move(t);
            base.Update(gameTime);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            if (_showInfo)
            {
                spriteBatch.DrawLine(position + facing * 20, position + facing * 40, Color.Green);
                spriteBatch.DrawLine(position + direction * 20, position + direction * (20 + (linearVelocity.Length()) * 20 / maxLinearVelocity), Color.Blue);
            }                                                   
            base.Draw(spriteBatch);
        }
    }
}
