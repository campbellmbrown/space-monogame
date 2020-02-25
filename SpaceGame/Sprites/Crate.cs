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
    /// <summary>
    /// Class that defines a crate. Inherits the ItemCarryingSprite class.
    /// </summary>
    public class Crate : ItemCarryingSprite
    {
        public Vector2 relativeToPlayer { get { return position - LimitsEdgeGame.playerManager.playerShip.position; } }

        /// <summary>
        /// Creates an instance of the crate class.
        /// </summary>
        /// <param name="position">X and Y position of the crate.</param>
        /// <param name="randomize">If the velocities should be randomized.</param>
        public Crate(Vector2 position, bool randomize) 
            : base(position, LimitsEdgeGame.textures["crate"])
        {
            if (randomize) RandomizeVelocities(50, 2);
            maxHealth = 20;
            currentHealth = 20;
        }

        /// <summary>
        /// Action to be taken when the crate is broken.
        /// </summary>
        public override void BreakAction()
        {
            AddBreakingParticles();
            for (int i = 0; i < LimitsEdgeGame.r.Next(0, 2); ++i) worldManager.itemManager.items.Add(new Metal(position, 1, true));
            for (int i = 0; i < LimitsEdgeGame.r.Next(0, 2); ++i) worldManager.itemManager.items.Add(new Plants(position, 1, true));
            for (int i = 0; i < LimitsEdgeGame.r.Next(0, 2); ++i) worldManager.itemManager.items.Add(new Plastic(position, 1, true));
            base.BreakAction();
        }
    }
}