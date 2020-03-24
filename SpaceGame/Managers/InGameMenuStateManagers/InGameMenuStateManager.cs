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
    public class InGameMenuStateManager
    {
        public InGameMenuEventManager eventManager;

        public InGameMenuStateManager()
        {
            eventManager = new InGameMenuEventManager();
        }

        public void Update(GameTime gameTime)
        {
            eventManager.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.DrawRectangle(new RectangleF(-50, -50, 100, 100), Color.LightBlue);
        }
    }
}
