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
    /// Class that defines a spaceship. Inherits the MovingSprite class.
    /// </summary>
    public class Spaceship : ItemCarryingSprite
    {
        public float wingAngularSpeed = 0f;
        protected Texture2D wingTexture;
        protected float wingRotation = 0f;
        protected int WingWidth { get { return wingTexture.Width; } }
        protected int WingHeight { get { return wingTexture.Height; } }
        protected Vector2 WingCenter { get { return new Vector2(WingWidth / 2f, WingHeight / 2f); } }
        protected float smokeDelay = 0.05f;
        protected float currentSmokeDelay = 0f;

        /// <summary>
        /// Creates an instance of the SpaceShip class.
        /// </summary>
        /// <param name="position">X and Y positions of the spaceship.</param>
        /// <param name="texture">Texture of the spaceship body.</param>
        /// <param name="wingTexture">Texture of the spaceship wings.</param>
        public Spaceship(Vector2 position, Texture2D texture, Texture2D wingTexture) 
            : base(position, texture)
        {
            this.wingTexture = wingTexture;
        }

        /// <summary>
        /// Draws the spaceship.
        /// </summary>
        /// <param name="spriteBatch">SpriteBatch instance.</param>
        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(wingTexture, position, null, Color.White, wingRotation, WingCenter, scale, SpriteEffects.None, 0f);
            base.Draw(spriteBatch);
        }
    }
}
