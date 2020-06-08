using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceGame.World
{
    public class Cloud
    {
        Color color;
        public Vector2 position;
        int depth;
        Texture2D texture;
        float rotation;
        Vector2 center { get { return new Vector2(texture.Width / 2f, texture.Height / 2f); } }
        
        public Cloud(Vector2 position)
        {
            texture = LimitsEdgeGame.textures["large_cloud_1"];
            this.position = position;
            depth = LimitsEdgeGame.r.Next(1, 6);
            color = new Color(LimitsEdgeGame.r.Next(0, 256), LimitsEdgeGame.r.Next(0, 256), LimitsEdgeGame.r.Next(0, 256));
            rotation = LimitsEdgeGame.r.Next(0, 629) / 100;
        }

        public void Update(GameTime gameTime)
        {
            float t = (float)gameTime.ElapsedGameTime.TotalSeconds;
            position += LimitsEdgeGame.worldStateManager.playerManager.playerShip.linearVelocity * t * depth / 10f;
        }

        public void Draw(SpriteBatch spriteBatch)
        { 
            spriteBatch.Draw(texture, position, null, color * 0.02f, rotation, center, 1f, SpriteEffects.None, 0f);
        }
    }
}
