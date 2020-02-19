using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonoGame.Extended;
using SpaceGame.Effects;
using SpaceGame.Projectiles;
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
        private float _timeSinceLastShot = 0f;
        private float _shotDelay = 0.2f;

        public PlayerShip(Vector2 position, Texture2D texture, Texture2D wingTexture) 
            : base(position, texture, wingTexture)
        {
        }

        public void SetAccelerations(float t)
        {
            KeyboardState keyboardState = Keyboard.GetState();

            if (keyboardState.IsKeyDown(Keys.A)) MoveAntiClockwise();
            else if (keyboardState.IsKeyDown(Keys.D)) MoveClockwise();
            else angularThrust = 0f;
            if (keyboardState.IsKeyDown(Keys.W)) MoveForward(t);
            else if (keyboardState.IsKeyDown(Keys.S)) MoveBackward(t);
            else linearThrust = 0f;
        }

        public void MoveClockwise()
        { 
            angularThrust = maxAngularThrust; 
        }

        public void MoveAntiClockwise()
        { 
            angularThrust = -maxAngularThrust;
        }

        public void MoveForward(float t)
        {
            RotateWings(t);
            linearThrust = maxLinearThrust;
        }

        public void MoveBackward(float t)
        {
            RotateWings(t);
            linearThrust = -maxLinearThrust;
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
                Vector2 smokePosition = position + Helper.RotateVector(new Vector2(0, Height / 2f), rotation);
                Game1.particleManager.AddParticle(new Smoke(smokePosition, true));
            }
        }

        public void AddProjectles(float t)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Space))
            {
                _timeSinceLastShot += t;
                if (_timeSinceLastShot >= _shotDelay)
                {
                    _timeSinceLastShot -= _shotDelay;
                    Game1.projectileManager.AddProjectile(new Lazer(position, rotation, Color.Red, facing * 300));
                }
            }
        }

        public override void Update(GameTime gameTime)
        {
            float t = (float)gameTime.ElapsedGameTime.TotalSeconds;
            SetAccelerations(t);
            AddProjectles(t);
            if (linearThrust != 0) AddSmoke(t);
            base.Update(gameTime);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);
        }
    }
}
