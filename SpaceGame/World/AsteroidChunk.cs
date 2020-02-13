using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceGame.World
{
    public class AsteroidChunk
    {
        public Vector2 relativePosition;
        protected Vector2 position;
        protected float rotation;
        protected Texture2D texture;
        protected int width { get { return texture.Width; } }
        protected int height { get { return texture.Height; } }
        protected Vector2 center { get { return new Vector2(width / 2f, height / 2f); } }

        public AsteroidChunk(Vector2 relativePosition)
        {
            this.relativePosition = relativePosition;
            this.rotation = Game1.r.Next(0, 4) * (float)Math.PI / 2f;
            texture = Game1.textures["asteroid_chunk"];
        }

        public void Update(GameTime gameTime)
        {

        }

        public void UpdatePosition(Vector2 position, float rotation)
        {
            // Don't do anything with rotation at first
            this.position = position + relativePosition;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, position, null, Color.White, rotation, center, 1f, SpriteEffects.None, 1f);
        }
    }
}
