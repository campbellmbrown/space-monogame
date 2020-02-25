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
    /// <summary>
    /// Class that defines an asteroid chunk.
    /// </summary>
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

        /// <summary>
        /// Creates an instance of the AsteroidChunk class.
        /// </summary>
        /// <param name="relativePosition">Distance from the center of the asteroid.</param>
        public AsteroidChunk(Vector2 relativePosition)
        {
            this.relativePosition = relativePosition;
            this.relativeRotation = LimitsEdgeGame.r.Next(0, 4) * (float)Math.PI / 2f;
            texture = LimitsEdgeGame.textures["asteroid_chunk"];
        }

        /// <summary>
        /// Updates the asteroid chunk.
        /// </summary>
        /// <param name="gameTime">GameTime instance.</param>
        public void Update(GameTime gameTime)
        {

        }

        /// <summary>
        /// Updates the position of the asteroid chunks.
        /// </summary>
        /// <param name="position">Position of the asteroid body.</param>
        /// <param name="rotation">Rotation of the asteroid body.</param>
        public void UpdatePosition(Vector2 position, float rotation)
        {
            rotatedRelativePosition = Helper.RotateVector(relativePosition, rotation);
            this.position = position;
            this.rotation = rotation;
        }

        /// <summary>
        /// Draws the asteroid chunk.
        /// </summary>
        /// <param name="spriteBatch">SpriteBatch instance.</param>
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, rotatedRelativePosition + position, null, Color.White, relativeRotation + rotation, center, 1f, SpriteEffects.None, 1f);
        }
    }
}
