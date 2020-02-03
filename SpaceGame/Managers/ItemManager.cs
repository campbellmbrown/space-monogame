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
        private List<Item> _items;

        public ItemManager()
        {
            _items = new List<Item>();
        }

        public void Update(GameTime gameTime)
        {
            foreach (var item in _items) item.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (var item in _items) item.Draw(spriteBatch);
        }

        public void AddItem(Item item)
        {
            _items.Add(item);
        }
    }
}
