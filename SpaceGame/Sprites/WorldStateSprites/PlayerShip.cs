using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonoGame.Extended;
using MonoGame.Extended.BitmapFonts;
using MonoGame.Extended.Sprites;
using SpaceGame.Effects;
using SpaceGame.Items;
using SpaceGame.Projectiles;
using SpaceGame.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceGame.Sprites.WorldStateSprites
{
    public class PlayerShip : Spaceship
    {
        public float shotDelay = 0.2f;
        protected int pickupDistance = 8;
        protected Rectangle pickupRange { get { return new Rectangle((int)position.X - pickupDistance, (int)position.Y - pickupDistance, 2 * pickupDistance, 2 * pickupDistance); } }
        public MovingSprite lockOnSprite;
        public float lockOnRange = 240;
        public bool lockOn = false;
        public float lockOnDistance;

        public PlayerShip(Vector2 position, Texture2D texture, Texture2D wingTexture) 
            : base(position, texture, wingTexture)
        {
        }

        float prevDistanceError = 0;
        float prevAngleError = 0;

        public void SetAccelerations(float t)
        {
            KeyboardState keyboardState = Keyboard.GetState();

            linearThrust = 0f;
            angularThrust = 0f;
            sidewaysThrust = 0f;
            if (keyboardState.IsKeyDown(Keys.A)) MoveAntiClockwise();
            else if (keyboardState.IsKeyDown(Keys.D)) MoveClockwise();
            if (keyboardState.IsKeyDown(Keys.W)) MoveForward(t);
            else if (keyboardState.IsKeyDown(Keys.S)) MoveBackward(t);

            // Used to angle the ship to the object when lock-on is active
            if (lockOn && lockOnSprite != null)
            {
                // Distance between locked on sprite and ship
                Vector2 relativePos = lockOnSprite.position - position;
                // Angular velocity correction
                float angleError = (float)(Math.Atan2(relativePos.X, -relativePos.Y) - rotation);
                if (angleError > (float)Math.PI)
                    angleError = angleError - 2*(float)Math.PI;
                else if (angleError < -(float)Math.PI)
                    angleError = angleError + 2*(float)Math.PI;
                angularThrust = angleError * 50000 + (angleError - prevAngleError) * 10000 / t;
                prevAngleError = angleError;
                // Linear velocity correction
                float distanceError = relativePos.Length() - lockOnDistance;
                linearThrust = distanceError * 50000 + (distanceError - prevDistanceError) * 10000 / t;
                sidewaysThrust = angularVelocity * 1000;
                prevDistanceError = distanceError;
            }
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
                LimitsEdgeGame.worldStateManager.particleManager.particles.Add(new Smoke(smokePosition, true));
            }
        }

        public void AddProjectiles()
        {
            LimitsEdgeGame.worldStateManager.projectileManager.projectiles.Add(new Lazer(position, rotation, Color.Red, facing * 300, 5) {maxLifeTime = 5});
        }

        public override void Update(GameTime gameTime)
        {
            float t = (float)gameTime.ElapsedGameTime.TotalSeconds;
            SetAccelerations(t);
            if (linearThrust != 0) AddSmoke(t);
            PickupItems();
            base.Update(gameTime);
            if (lockOnSprite != null && (lockOnSprite.position - position).Length() >= lockOnRange || !LimitsEdgeGame.worldStateManager.crateManager.crates.Contains(lockOnSprite))
            {
                lockOnSprite = null;
            }
        }

        protected void PickupItems()
        {
            List<Item> itemsInRange = LimitsEdgeGame.worldStateManager.itemManager.GetItemsInRange(pickupRange);
            for (int i = itemsInRange.Count - 1; i >= 0; i--)
            {
                LimitsEdgeGame.inventoryStateManager.itemMenu.AddItem(itemsInRange[i], 1);
                LimitsEdgeGame.worldStateManager.itemManager.items.Remove(itemsInRange[i]);
            }
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            if (lockOnSprite != null) spriteBatch.DrawLine(position, lockOnSprite.position, Color.White);
            spriteBatch.DrawCircle(position, lockOnRange, 30, Color.White * 0.1f);
            base.Draw(spriteBatch);
        }

        public void SetLockOnSprite(MovingSprite sprite)
        {
            lockOnSprite = sprite;
        }

        public void RemoveLockOnSprite()
        {
            lockOnSprite = null;
        }

        public void SetLockOn(bool condition)
        {
            lockOn = condition;
        }
    }
}
