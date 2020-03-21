﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Extended;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceGame.Managers
{
    public class DebugMessage
    {
        public string name;
        public string value = "";
        public Vector2 position;
        protected string printableString { get { return name + ": " + value; } }
        protected SpriteFont font = LimitsEdgeGame.fonts["courier_new_bold"];
        public static float height = 8f;

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.DrawString(font, printableString, position, Color.White, 0f, Vector2.Zero, height / font.LineSpacing, SpriteEffects.None, 0f);
        }
    }

    public enum DebugLevel
    {
        Nothing,
        Headings,
        Messages
    }

    public class DebugManager
    {
        protected Vector2 relativeStartingPosition = new Vector2(5, 5 - offsetAmount);
        protected Vector2 startingPosition { get { return LimitsEdgeGame.topLeftCorner + relativeStartingPosition; } }
        protected List<DebugMessage> debugMessages;
        protected static float offsetAmount { get { return DebugMessage.height; } }
        public DebugLevel debugLevel = DebugLevel.Nothing;
        protected PlayerManager playerManager = LimitsEdgeGame.playerManager;
        protected ParticleManager particleManager = LimitsEdgeGame.worldStateManager.particleManager;
        protected CrateManager crateManager = LimitsEdgeGame.worldStateManager.crateManager;
        protected ProjectileManager projectileManager = LimitsEdgeGame.worldStateManager.projectileManager;

        public DebugManager()
        {
            debugMessages = new List<DebugMessage>()
            {
                new DebugMessage { name = "FPS" },
                new DebugMessage { name = "Player position" },
                new DebugMessage { name = "Player linear velocity" },
                new DebugMessage { name = "Player angular velocity" },
                new DebugMessage { name = "Player rotation" },
                new DebugMessage { name = "Particle count" },
                new DebugMessage { name = "Crate count" },
                new DebugMessage { name = "Projectile count" },
            };
        }

        public void Update(GameTime gameTime)
        {
            if (debugLevel == DebugLevel.Nothing) return;
            else if (debugLevel == DebugLevel.Messages)
            {
                debugMessages[0].value = Math.Round(1 / gameTime.ElapsedGameTime.TotalSeconds).ToString();
                debugMessages[1].value = playerManager.playerShip.position.ToString();
                debugMessages[2].value = playerManager.playerShip.linearVelocity.ToString();
                debugMessages[3].value = playerManager.playerShip.angularVelocity.ToString();
                debugMessages[4].value = playerManager.playerShip.rotation.ToString();
                debugMessages[5].value = particleManager.particleCount.ToString();
                debugMessages[6].value = crateManager.crates.Count.ToString();
                debugMessages[7].value = projectileManager.projectiles.Count.ToString();

                Vector2 offsetPosition = startingPosition;
                foreach (var debugMessage in debugMessages)
                {
                    offsetPosition.Y += offsetAmount;
                    debugMessage.position = offsetPosition;
                }
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (debugLevel == DebugLevel.Nothing) return;
            else if (debugLevel == DebugLevel.Messages) foreach (var debugMessage in debugMessages) debugMessage.Draw(spriteBatch);
            else if (debugLevel == DebugLevel.Headings)
            {
                spriteBatch.DrawLine(playerManager.playerShip.position + playerManager.playerShip.facing * 20, playerManager.playerShip.position + playerManager.playerShip.facing * 40, Color.Green);
                spriteBatch.DrawLine(playerManager.playerShip.position + playerManager.playerShip.direction * 20, playerManager.playerShip.position + playerManager.playerShip.direction * (20 + (playerManager.playerShip.linearVelocity.Length()) * 20 / playerManager.playerShip.maxLinearVelocity), Color.Yellow);
                foreach (var projectile in LimitsEdgeGame.worldStateManager.projectileManager.projectiles) spriteBatch.DrawString(LimitsEdgeGame.fonts["courier_new_italic"], projectile.damage.ToString(), projectile.position + new Vector2(6), Color.White, 0f, Vector2.Zero, 0.2f, SpriteEffects.None, 0f);
                foreach (var crate in LimitsEdgeGame.worldStateManager.crateManager.crates) spriteBatch.DrawString(LimitsEdgeGame.fonts["courier_new_italic"], crate.currentHealth.ToString(), crate.position + new Vector2(14), Color.White, 0f, Vector2.Zero, 0.2f, SpriteEffects.None, 0f);
            }
        }

        public void ToggleDebugLevels()
        {
            if (debugLevel == DebugLevel.Nothing) debugLevel = DebugLevel.Headings;
            else if (debugLevel == DebugLevel.Headings) debugLevel = DebugLevel.Messages;
            else if (debugLevel == DebugLevel.Messages) debugLevel = DebugLevel.Nothing;
        }
    }
}
