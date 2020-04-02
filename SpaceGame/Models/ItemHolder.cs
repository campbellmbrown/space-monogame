using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SpaceGame.Items;
using SpaceGame.Tiles;
using SpaceGame.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceGame.Models
{
    public class ItemHolder
    {
        protected Texture2D texture;
        protected Vector2 position;
        
        protected float lifeTimeRadians;
        protected float heightOffset;
        protected float bounceHeight = 1f;
        protected float timePerBounceCycle = 1f;
        protected Vector2 positionOffset { get { return new Vector2(0, heightOffset - bounceHeight); } }
        
        protected Vector2 center { get { return new Vector2(texture.Width / 2f, texture.Height / 2f); } }
        
        public Item item;

        public ItemHolder(Texture2D texture, Vector2 position)
        {
            this.texture = texture;
            this.position = position;
        }

        public void SetItem(Item item)
        {
            this.item = item;
        }

        public void Update(GameTime gameTime)
        {
            float t = (float)gameTime.ElapsedGameTime.TotalSeconds;
            lifeTimeRadians += t;
            heightOffset = bounceHeight * (float)Math.Cos(lifeTimeRadians * 2 * Math.PI / timePerBounceCycle);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, position, null, Color.White, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0f);
            if (item != null) item.DrawPreview(spriteBatch, center + positionOffset, Tile.tileSize, true);
        }
    }
}
