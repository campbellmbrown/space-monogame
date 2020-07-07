using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Extended;
using SpaceGame.Effects;
using SpaceGame.Items;
using SpaceGame.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceGame.Sprites.WorldStateSprites
{
    public class ItemCarryingSprite : MovingSprite
    {
        private List<Item> _items;

        public ItemCarryingSprite(Vector2 position, Texture2D texture) : base(position, texture)
        {
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
                LimitsEdgeGame.worldStateManager.itemManager.items.Add(item);
            }
        }

        public virtual void AddBreakingParticles(int breakingPieces)
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
                    LimitsEdgeGame.worldStateManager.particleManager.particles.Add(particle);
                }
            }
        }
    }
}