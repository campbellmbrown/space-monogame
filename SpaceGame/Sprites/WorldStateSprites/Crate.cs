using Microsoft.Xna.Framework;
using SpaceGame.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceGame.Sprites.WorldStateSprites
{
    public class Crate : ItemCarryingSprite
    {
        public Vector2 relativeToPlayer { get { return position - LimitsEdgeGame.playerManager.playerShip.position; } }

        public Crate(Vector2 position, bool randomize) 
            : base(position, LimitsEdgeGame.textures["crate"])
        {
            if (randomize) RandomizeVelocities(50, 2);
            maxHealth = 20;
            currentHealth = 20;
        }

        public override void BreakAction()
        {
            AddBreakingParticles();
            for (int i = 0; i < LimitsEdgeGame.r.Next(0, 2); ++i) LimitsEdgeGame.worldStateManager.itemManager.items.Add(new Metal(position, 1, true));
            for (int i = 0; i < LimitsEdgeGame.r.Next(0, 2); ++i) LimitsEdgeGame.worldStateManager.itemManager.items.Add(new Plants(position, 1, true));
            for (int i = 0; i < LimitsEdgeGame.r.Next(0, 2); ++i) LimitsEdgeGame.worldStateManager.itemManager.items.Add(new Plastic(position, 1, true));
            base.BreakAction();
        }
    }
}