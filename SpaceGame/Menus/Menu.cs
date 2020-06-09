using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Extended.BitmapFonts;
using SpaceGame.Managers.InventoryStateManagers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceGame.Menus
{
    public class Menu
    {
        protected Vector2 selectionBarPosition;
        protected string selectionBarName;
        protected Texture2D selectedTexture;
        protected Texture2D unselectedTexture;
        protected Rectangle selectionRectangle { get { return new Rectangle((int)selectionBarPosition.X, (int)selectionBarPosition.Y, 128, 20); } }
        protected Vector2 selectionBarTextPos;
        protected InventoryType inventoryType;
        public bool selected { get { return inventoryType == LimitsEdgeGame.inventoryStateManager.inventoryType; } }
        protected Vector2 menuOffset = new Vector2(140, 0);

        public Menu(Vector2 selectionBarPosition, string selectionBarName, InventoryType inventoryType)
        {
            selectedTexture = LimitsEdgeGame.textures["selection_bar"];
            unselectedTexture = LimitsEdgeGame.textures["selection_bar_dark"];
            this.selectionBarPosition = selectionBarPosition;
            this.selectionBarName = selectionBarName;
            this.inventoryType = inventoryType;
            selectionBarTextPos = selectionBarPosition + new Vector2((20 - 16) / 2f);
        }

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw((selected) ? selectedTexture : unselectedTexture, selectionBarPosition, null, Color.White, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0f);
            spriteBatch.DrawString(LimitsEdgeGame.bitmapFonts["game_font_16"], selectionBarName, selectionBarTextPos + Vector2.One, Color.Black);
            spriteBatch.DrawString(LimitsEdgeGame.bitmapFonts["game_font_16"], selectionBarName, selectionBarTextPos, (selected) ? Color.White : Color.LightGray);
        }

        public virtual void Click(Vector2 mousePosition)
        {
            if (selectionRectangle.Contains(mousePosition))
            {
                LimitsEdgeGame.inventoryStateManager.inventoryType = inventoryType;
            }
        }
    }
}
