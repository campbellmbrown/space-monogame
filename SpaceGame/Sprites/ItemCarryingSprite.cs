using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Extended;
using SpaceGame.Effects;
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
        protected int breakingPieces = 7;

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

        public virtual void AddParticles()
        {
            for (int i = (1 - breakingPieces) / 2; i < (breakingPieces + 1) / 2; ++i)
            {
                for (int j = (1 - breakingPieces) / 2; j < (breakingPieces + 1) / 2; ++j)
                {
                    var relativePosition = new Vector2(i * Width / breakingPieces, j * Height / breakingPieces);
                    var rotatedRelativePosition = new Vector2(
                        relativePosition.X * (float)Math.Cos(rotation) - relativePosition.Y * (float)Math.Sin(rotation),
                        relativePosition.X * (float)Math.Sin(rotation) + relativePosition.Y * (float)Math.Cos(rotation));
                    var tangentialDirection = (i == 0 && j == 0) ? Vector2.Zero : Vector2.Normalize(new Vector2(-rotatedRelativePosition.Y, rotatedRelativePosition.X));

                    Particle particle = new Particle(position + rotatedRelativePosition, texture, false)
                    {
                        textureRectangle = new Rectangle(
                            (i + (breakingPieces - 1) / 2) * Width / breakingPieces,
                            (j + (breakingPieces - 1) / 2) * Height / breakingPieces,
                            Width / breakingPieces,
                            Height / breakingPieces),
                        rotation = this.rotation,
                        angularVelocity = this.angularVelocity,
                        linearVelocity = this.linearVelocity + tangentialDirection * this.angularVelocity * relativePosition.Length()
                    };
                    Game1.particleManager.AddParticle(particle);
                }
            }
        }
    }
}
