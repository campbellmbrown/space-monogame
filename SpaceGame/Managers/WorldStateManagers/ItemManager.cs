using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SpaceGame.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceGame.Managers
{
    public class ItemManager
    {
        public List<Item> items;

        public ItemManager()
        {
            items = new List<Item>();
        }

        public void Update(GameTime gameTime)
        {
            foreach (var item in items) item.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (var item in items) item.Draw(spriteBatch);
        }

        public List<Item> GetItemsInRange(Rectangle range)
        {
            List<Item> itemsInRange = new List<Item>();
            foreach (var item in items)
            {
                if (range.Contains(item.position)) {
                    itemsInRange.Add(item);
                }
            }
            return itemsInRange;
        }
    }
}
