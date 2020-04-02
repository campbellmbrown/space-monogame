using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceGame.Items
{
    public class Item
    {
        protected Vector2 position;
        protected int count;
        protected Vector2 linearAcceleration = Vector2.Zero;
        protected Vector2 linearVelocity = Vector2.Zero;
        protected float angularAcceleration = 0f;
        protected float angularVelocity = 0f;
        protected float rotation = 0f;
        public Vector2 linearDirection { get { return (linearVelocity.Length() == 0) ? Vector2.Zero : Vector2.Normalize(linearVelocity); } }
        protected float angularDirection { get { return Math.Sign(angularVelocity); } }

        protected Texture2D texture;
        protected float width { get { return texture.Width; } }
        protected float height { get { return texture.Height; } }
        protected Vector2 center { get { return new Vector2(width / 2f, height / 2f); } }
        protected Vector2 bottomMiddle { get { return new Vector2(width / 2f, height); } }

        public float linearDragCoefficient = 0f;
        public float angularDragCoefficient = 0f;

        public Item(Texture2D texture, Vector2 position, int count, bool randomize)
        {
            this.position = position;
            this.texture = texture;
            this.count = count;
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

        public Item(Texture2D texture, Vector2 position, int count, Vector2 linearVelocity, float angularVelocity)
        {
            this.position = position;
            this.texture = texture;
            this.count = count;
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

        public void DrawPreview(SpriteBatch spriteBatch, Vector2 pPosition, float previewSize, bool bottomMiddle = false)
        {
            spriteBatch.Draw(texture, pPosition, null, Color.White, 0f,
                bottomMiddle ? this.bottomMiddle : center, 
                previewSize / texture.Width, 
                SpriteEffects.None, 1f);
        }

        public void Move(float t)
        {
            // Friction
            linearAcceleration = -linearDragCoefficient * (float)Math.Pow(linearVelocity.Length(), 2f) * linearDirection;
            angularAcceleration = -linearDragCoefficient * (float)Math.Pow(angularVelocity, 2f) * angularDirection;
            // Velocities and positions
            linearVelocity += linearAcceleration * t;
            angularVelocity += angularAcceleration * t;
            position += linearVelocity * t;
            rotation += angularVelocity * t;
        }
    }
}
