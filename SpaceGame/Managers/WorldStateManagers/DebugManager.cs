using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Extended;
using MonoGame.Extended.BitmapFonts;
using SpaceGame.Sprites;
using SpaceGame.Sprites.WorldStateSprites;
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
        protected BitmapFont font = LimitsEdgeGame.bitmapFonts["game_font_16"];
        public static float height = 16f;

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.DrawString(font, printableString, position, Color.White, 0f, Vector2.Zero, height / font.LineHeight, SpriteEffects.None, 0f);
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
        protected Vector2 startingPosition { get { return LimitsEdgeGame.topLeft + relativeStartingPosition; } }
        protected List<DebugMessage> debugMessages;
        protected static float offsetAmount { get { return DebugMessage.height; } }
        public DebugLevel debugLevel = DebugLevel.Nothing;

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
                new DebugMessage { name = "Item count" },
            };
        }

        public void Update(GameTime gameTime)
        {
            if (debugLevel == DebugLevel.Nothing) return;
            else if (debugLevel == DebugLevel.Messages)
            {
                PlayerShip playerShip = LimitsEdgeGame.worldStateManager.playerManager.playerShip;
                debugMessages[0].value = Math.Round(1 / gameTime.ElapsedGameTime.TotalSeconds).ToString();
                debugMessages[1].value = playerShip.position.ToString();
                debugMessages[2].value = playerShip.linearVelocity.ToString();
                debugMessages[3].value = playerShip.angularVelocity.ToString();
                debugMessages[4].value = playerShip.rotation.ToString();
                debugMessages[5].value = LimitsEdgeGame.worldStateManager.particleManager.particleCount.ToString();
                debugMessages[6].value = LimitsEdgeGame.worldStateManager.crateManager.crates.Count.ToString();
                debugMessages[7].value = LimitsEdgeGame.worldStateManager.projectileManager.projectiles.Count.ToString();
                debugMessages[8].value = LimitsEdgeGame.worldStateManager.itemManager.items.Count.ToString();

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
                PlayerShip playerShip = LimitsEdgeGame.worldStateManager.playerManager.playerShip;
                spriteBatch.DrawLine(playerShip.position + playerShip.facing * 20, playerShip.position + playerShip.facing * 40, Color.Green);
                spriteBatch.DrawLine(playerShip.position + playerShip.direction * 20, playerShip.position + playerShip.direction * (20 + (playerShip.linearVelocity.Length()) * 20 / playerShip.maxLinearVelocity), Color.Yellow);
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
