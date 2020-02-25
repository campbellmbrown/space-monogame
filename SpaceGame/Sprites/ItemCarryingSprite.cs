using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Extended;
using SpaceGame.Effects;
using SpaceGame.Items;
using SpaceGame.Managers;
using SpaceGame.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceGame.Sprites
{
    /// <summary>
    /// Class that defines a sprite carrying items. Inherits the MovingSprite class.
    /// </summary>
    public class ItemCarryingSprite : MovingSprite
    {
        private List<Item> _items;
        protected WorldManager worldManager;
        protected int breakingPieces = 5;

        /// <summary>
        /// Creates an instance of the ItemCarryingSprite class.
        /// </summary>
        /// <param name="position">X and Y positions of the sprite.</param>
        /// <param name="texture">Texture of the sprite.</param>
        public ItemCarryingSprite(Vector2 position, Texture2D texture) : base(position, texture)
        {
            _items = new List<Item>();
            worldManager = LimitsEdgeGame.worldManager;
        }

        /// <summary>
        /// Add items to the sprite.
        /// </summary>
        /// <param name="items"></param>
        public void AddItems(List<Item> items)
        {
            _items.AddRange(items);
        }

        /// <summary>
        /// Drops the items into the world.
        /// </summary>
        public void DropItems()
        {
            foreach (var item in _items)
            {
                worldManager.itemManager.items.Add(item);
            }
        }

        /// <summary>
        /// Adds breaking particles to the sprite.
        /// </summary>
        public virtual void AddBreakingParticles()
        {
            if (breakingPieces <= 0) return;
            for (int i = 1 - breakingPieces; i < breakingPieces + 1; i+=2)
            {
                for (int j = 1 - breakingPieces; j < breakingPieces + 1; j+=2)
                {
                    var relativePosition = new Vector2((i / 2f) * Width / breakingPieces, (j / 2f) * Height / breakingPieces);
                    var rotatedRelativePosition = Helper.RotateVector(relativePosition, rotation);
                    var tangentialDirection = (rotatedRelativePosition == Vector2.Zero) ? Vector2.Zero : Vector2.Normalize(new Vector2(-rotatedRelativePosition.Y, rotatedRelativePosition.X));

                    Particle particle = new Particle(position + rotatedRelativePosition, texture, false, ParticleDestroyType.Fade)
                    {
                        fadeTime = 2f,
                        textureRectangle = new Rectangle((i + breakingPieces - 1) * Width / (2 * breakingPieces), (j + breakingPieces - 1) * Height / (2 * breakingPieces), Width / breakingPieces, Height / breakingPieces),
                        rotation = this.rotation,
                        angularVelocity = this.angularVelocity,
                        linearVelocity = this.linearVelocity + Helper.Vector2RandomDirecAndLength(5) + tangentialDirection * this.angularVelocity * relativePosition.Length()
                    };
                    LimitsEdgeGame.particleManager.particles.Add(particle);
                }
            }
        }
    }
}