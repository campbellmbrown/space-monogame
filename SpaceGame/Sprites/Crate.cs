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
        public Vector2 relativeToPlayer { get { return position - Game1.playerManager.playerShip.position; } }

        public Crate(Vector2 position, Vector2 linearVelocity, float angularVelocity) 
            : base(position, Game1.textures["crate"], linearVelocity, angularVelocity)
        {
        }

        public Crate(Vector2 position, bool randomize) 
            : base(position, Game1.textures["crate"], randomize)
        {
        }

        public override void BreakAction()
        {
            AddBreakingParticles();
            for (int i = 0; i < 4; ++i) worldManager.itemManager.AddItem(new Metal(position, 1, true));
            for (int i = 0; i < 4; ++i) worldManager.itemManager.AddItem(new Plants(position, 1, true));
            for (int i = 0; i < 4; ++i) worldManager.itemManager.AddItem(new Plastic(position, 1, true));
            base.BreakAction();
        }
    }
}