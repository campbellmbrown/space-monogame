using Microsoft.Xna.Framework;
using SpaceGame.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceGame.Sprites.WorldStateSprites
{
    public class Asteroid : ItemCarryingSprite
    {
        public Vector2 relativeToPlayer { get { return position - LimitsEdgeGame.worldStateManager.playerManager.playerShip.position; } }

        public Asteroid(Vector2 position, bool randomize)
            : base(position, LimitsEdgeGame.textures["asteroid_chunk"])
        {
            if (randomize) RandomizeVelocities(50, 2);
            maxHealth = 10;
            currentHealth = 10;
        }

        public override void BreakAction()
        {
            AddBreakingParticles(3);
            for (int i = 0; i < LimitsEdgeGame.r.Next(0, 4); ++i) LimitsEdgeGame.worldStateManager.itemManager.items.Add(new Metal(position, true));
            base.BreakAction();
        }
    }
}