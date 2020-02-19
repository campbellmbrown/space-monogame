using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SpaceGame.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceGame.World
{
    public class AsteroidChunk
    {
        protected Vector2 rotatedRelativePosition;
        public Vector2 relativePosition;
        protected Vector2 position;
        protected float relativeRotation;
        protected float rotation;
        protected Texture2D texture;
        protected int width { get { return texture.Width; } }
        protected int height { get { return texture.Height; } }
        protected Vector2 center { get { return new Vector2(width / 2f, height / 2f); } }

        public AsteroidChunk(Vector2 relativePosition)
        {
            this.relativePosition = relativePosition;
            this.relativeRotation = Game1.r.Next(0, 4) * (float)Math.PI / 2f;
            texture = Game1.textures["asteroid_chunk"];
        }

        public void Update(GameTime gameTime)
        {

        }

        public void UpdatePosition(Vector2 position, float rotation)
        {
            rotatedRelativePosition = Helper.RotateVector(relativePosition, rotation);
            this.position = position;
            this.rotation = rotation;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, rotatedRelativePosition + position, null, Color.White, relativeRotation + rotation, center, 1f, SpriteEffects.None, 1f);
        }
    }
}
