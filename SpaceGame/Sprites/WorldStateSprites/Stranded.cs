using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceGame.Sprites.WorldStateSprites
{
    public class Stranded : MovingSprite
    {
        protected Rectangle textureRectangle;

        public Stranded(Vector2 position, bool randomize) : base(position, LimitsEdgeGame.textures["stranded_1"])
        {
            if (randomize) RandomizeVelocities(50, 2);
        }

        public override void Update(GameTime gameTime)
        {
            textureRectangle = new Rectangle(0, 0, texture.Width / 2, texture.Height);
            base.Update(gameTime);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, position, textureRectangle, Color.White, rotation, Center, scale, SpriteEffects.None, 0f);
        }
    }
}
