using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Extended;
using MonoGame.Extended.BitmapFonts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceGame.Items
{
    public class Item
    {
        public Vector2 position;
        protected Vector2 linearAcceleration = Vector2.Zero;
        protected Vector2 linearVelocity = Vector2.Zero;
        protected float angularAcceleration = 0f;
        protected float angularVelocity = 0f;
        protected float rotation = 0f;
        public Vector2 linearDirection { get { return (linearVelocity.Length() == 0) ? Vector2.Zero : Vector2.Normalize(linearVelocity); } }
        protected float angularDirection { get { return Math.Sign(angularVelocity); } }
        protected Vector2 distanceToPlayer { get { return LimitsEdgeGame.worldStateManager.playerManager.playerShip.position - position; } }
        public Texture2D texture;
        protected float width { get { return texture.Width; } }
        protected float height { get { return texture.Height; } }
        public Vector2 center { get { return new Vector2(width / 2f, height / 2f); } }
        protected Vector2 bottomMiddle { get { return new Vector2(width / 2f, height); } }
        protected float collectionThreshold = 120;
        protected float maxCollectionSpeed = 350;
        public float linearDragCoefficient = 0.01f;

        public Item(Texture2D texture, Vector2 position, bool randomize)
        {
            this.position = position;
            this.texture = texture;
            if (randomize)
            {
                linearVelocity = new Vector2(LimitsEdgeGame.r.Next(-50, 51), LimitsEdgeGame.r.Next(-50, 51));
                angularVelocity = LimitsEdgeGame.r.Next(-628, 629) / 100f;
            }
            else
            {
                linearVelocity = Vector2.Zero;
                angularVelocity = 0f;
            }
        }

        public Item(Texture2D texture, Vector2 position, Vector2 linearVelocity, float angularVelocity)
        {
            this.position = position;
            this.texture = texture;
            this.linearVelocity = linearVelocity;
            this.angularVelocity = angularVelocity;
        }

        public void Update(GameTime gameTime)
        {
            float t = (float)gameTime.ElapsedGameTime.TotalSeconds;
            Move(t);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, position, null, Color.White, rotation, center, 1f, SpriteEffects.None, 1f);
        }

        public void DrawPreview(SpriteBatch spriteBatch, Vector2 pPosition, float previewSize)
        {
            spriteBatch.Draw(texture, pPosition, null, Color.White, 0f, center, previewSize / texture.Width, SpriteEffects.None, 1f);
        }

        public void Move(float t)
        {
            // Friction
            linearAcceleration = -linearDragCoefficient * (float)Math.Pow(linearVelocity.Length(), 2f) * linearDirection;
            // Collection
            if (distanceToPlayer.Length() < collectionThreshold)
            {
                Vector2 temp = linearAcceleration;
                linearAcceleration += (collectionThreshold - distanceToPlayer.Length()) / collectionThreshold * maxCollectionSpeed * Vector2.Normalize(distanceToPlayer);
            }
            // Velocities and positions
            linearVelocity += linearAcceleration * t;
            angularVelocity += angularAcceleration * t;
            position += linearVelocity * t;
            rotation += angularVelocity * t;
        }
    }
}
