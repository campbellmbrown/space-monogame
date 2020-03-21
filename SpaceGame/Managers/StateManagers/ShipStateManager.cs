using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Extended;
using SpaceGame.Managers.EventManagers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceGame.Managers
{
    public class ShipStateManager
    {
        public ShipEventManager eventManager;
        protected Texture2D texture = LimitsEdgeGame.textures["ship_layout"];
        protected Vector2 center { get { return new Vector2(texture.Width / 2f, texture.Height / 2f); } }

        public ShipStateManager()
        {
            eventManager = new ShipEventManager();
        }

        public void Update(GameTime gameTime)
        {
            eventManager.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, Vector2.Zero, null, Color.White, 0f, center, 1f, SpriteEffects.None, 0f);
        }
    }
}
