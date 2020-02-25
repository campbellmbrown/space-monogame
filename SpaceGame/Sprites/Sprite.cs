using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceGame.Sprites
{
    /// <summary>
    /// Base class for all sprites.
    /// </summary>
    public class Sprite
    {
        public Vector2 position;
        protected Texture2D texture;
        protected readonly float scale = 1f;
        public float rotation = 0f;
        protected int Width { get { return texture.Width; } }
        protected int Height { get { return texture.Height; } }
        protected Vector2 Center { get { return new Vector2(Width / 2f, Height / 2f); } }
        public float mass = 10f;

        /// <summary>
        /// Creates an instance of the Sprite class.
        /// </summary>
        /// <param name="position">X and Y positions of the sprite.</param>
        /// <param name="texture">Texture of the sprite.</param>
        public Sprite(Vector2 position, Texture2D texture)
        {
            this.position = position;
            this.texture = texture;
        }

        /// <summary>
        /// Updates the sprite.
        /// </summary>
        /// <param name="gameTime">GameTime instance.</param>
        public virtual void Update(GameTime gameTime)
        {

        }

        /// <summary>
        /// Draws the sprite.
        /// </summary>
        /// <param name="spriteBatch">SpriteBatch instance.</param>
        public virtual void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, position, null, Color.White, rotation, Center, scale, SpriteEffects.None, 0f);
        }
    }
}
