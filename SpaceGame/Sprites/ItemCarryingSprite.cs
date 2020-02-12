using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SpaceGame.Items;
using SpaceGame.Managers;
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
        protected WorldManager worldManager;

        public ItemCarryingSprite(Vector2 position, Texture2D texture, Vector2 linearVelocity, float angularVelocity) 
            : base(position, texture)
        {
            base.linearVelocity = linearVelocity;
            base.angularVelocity = angularVelocity;
            this.worldManager = Game1.worldManager;
            _items = new List<Item>();
        }

        public ItemCarryingSprite(Vector2 position, Texture2D texture, bool randomize) : base(position, texture)
        {
            if (randomize)
            {
                linearVelocity = new Vector2(Game1.r.Next(-50, 51), Game1.r.Next(-50, 51));
                angularVelocity = Game1.r.Next(-200, 201) / 100f;
            }
            else
            {
                linearVelocity = Vector2.Zero;
                angularVelocity = 0f;
            }
            _items = new List<Item>();
            this.worldManager = Game1.worldManager;
        }

        public void AddItems(List<Item> items)
        {
            _items.AddRange(items);
        }

        public void DropItems()
        {
            foreach (var item in _items)
            {
                worldManager.itemManager.AddItem(item);
            }
        }
    }
}
