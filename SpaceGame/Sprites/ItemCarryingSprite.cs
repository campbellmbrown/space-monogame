using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SpaceGame.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceGame.Sprites
{
    public class ItemCarryingSprite : MovingSprite
    {
        private List<Item> _items;

        public ItemCarryingSprite(Vector2 position, Texture2D texture, Vector2 linearVelocity, float angularVelocity) 
            : base(position, texture)
        {
            base.linearVelocity = linearVelocity;
            base.angularVelocity = angularVelocity;
            _items = new List<Item>();
        }

        public ItemCarryingSprite(Vector2 position, Texture2D texture, bool randomize) : base(position, texture)
        {
            if (randomize)
            {
                linearVelocity = new Vector2(Game1.r.Next(-50, 51), Game1.r.Next(-50, 51));
                angularVelocity = Game1.r.Next(-628, 629) / 100f;
            }
            else
            {
                linearVelocity = Vector2.Zero;
                angularVelocity = 0f;
            }
            _items = new List<Item>();
        }

        public void AddItems(List<Item> items)
        {
            _items.AddRange(items);
        }

        public void DropItems()
        {
            foreach (var item in _items)
            {
                Game1.worldManager.itemManager.AddItem(item);
            }
        }
    }
}
