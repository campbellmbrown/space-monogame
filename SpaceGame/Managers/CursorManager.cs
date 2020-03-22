using Microsoft.Xna.Framework.Graphics;
using SpaceGame.Effects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceGame.Managers
{
    public class CursorManager
    {
        protected Cursor cursor;
        
        public CursorManager()
        {
            cursor = new Cursor(LimitsEdgeGame.textures["arrow_cursor"]);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            cursor.Draw(spriteBatch);
        }
    }
}
