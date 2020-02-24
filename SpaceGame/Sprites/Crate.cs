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
    public class Crate : ItemCarryingSprite
    {
        public Vector2 relativeToPlayer { get { return position - LimitsEdgeGame.playerManager.playerShip.position; } }

        public Crate(Vector2 position, Vector2 linearVelocity, float angularVelocity) 
            : base(position, LimitsEdgeGame.textures["crate"], linearVelocity, angularVelocity)
        {
        }

        public Crate(Vector2 position, bool randomize) 
            : base(position, LimitsEdgeGame.textures["crate"], randomize)
        {
        }

        public override void BreakAction()
        {
            AddBreakingParticles();
            for (int i = 0; i < LimitsEdgeGame.r.Next(0, 2); ++i) worldManager.itemManager.AddItem(new Metal(position, 1, true));
            for (int i = 0; i < LimitsEdgeGame.r.Next(0, 2); ++i) worldManager.itemManager.AddItem(new Plants(position, 1, true));
            for (int i = 0; i < LimitsEdgeGame.r.Next(0, 2); ++i) worldManager.itemManager.AddItem(new Plastic(position, 1, true));
            base.BreakAction();
        }
    }
}