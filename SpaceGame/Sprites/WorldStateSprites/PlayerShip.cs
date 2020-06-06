using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonoGame.Extended;
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
        protected int pickupDistance = 5;
        protected Rectangle pickupRange { get { return new Rectangle((int)position.X - pickupDistance, (int)position.Y - pickupDistance, 2 * pickupDistance, 2 * pickupDistance); } }
        public List<Item> heldItems;

        public PlayerShip(Vector2 position, Texture2D texture, Texture2D wingTexture) 
            : base(position, texture, wingTexture)
        {
            heldItems = new List<Item>();
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
        }

        protected void PickupItems()
        {
            List<Item> itemsInRange = LimitsEdgeGame.worldStateManager.itemManager.GetItemsInRange(pickupRange);
            for (int i = itemsInRange.Count - 1; i >= 0; i--)
            {
                heldItems.Add(itemsInRange[i]);
                LimitsEdgeGame.worldStateManager.itemManager.items.Remove(itemsInRange[i]);
            }
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.DrawRectangle(pickupRange, Color.White);
            base.Draw(spriteBatch);
        }
    }
}
