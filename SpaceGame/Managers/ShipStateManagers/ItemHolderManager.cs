using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SpaceGame.Items;
using SpaceGame.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceGame.Managers.ShipStateManagers
{
    public class ItemHolderManager
    {
        protected List<ItemHolder> itemHolders;

        public ItemHolderManager()
        {
            itemHolders = new List<ItemHolder>();
            itemHolders.Add(new ItemHolder(LimitsEdgeGame.textures["item_holder"], Vector2.Zero) { item = new Metal(Vector2.Zero, 1, true) });
        }

        public void Update(GameTime gameTime)
        {
            foreach (var itemHolder in itemHolders) itemHolder.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (var itemHolder in itemHolders) itemHolder.Draw(spriteBatch);
        }
    }
}
