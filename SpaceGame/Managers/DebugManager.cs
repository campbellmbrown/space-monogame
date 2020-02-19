using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
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
        protected SpriteFont font = Game1.fonts["courier_new"];
        public static float height = 9f;

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.DrawString(font, printableString, position, Color.White, 0f, Vector2.Zero, height / font.LineSpacing, SpriteEffects.None, 0f);
        }
    }

    public class DebugManager
    {
        protected Vector2 relativeStartingPosition = new Vector2(5, 5 - offsetAmount);
        protected Vector2 startingPosition { get { return Game1.topLeftCorner + relativeStartingPosition; } }
        protected List<DebugMessage> debugMessages;
        protected static float offsetAmount { get { return DebugMessage.height; } }

        public DebugManager()
        {
            debugMessages = new List<DebugMessage>()
            {
                new DebugMessage { name = "Player position" },
                new DebugMessage { name = "Player linear velocity" },
                new DebugMessage { name = "Player angular velocity" },
                new DebugMessage { name = "Player rotation" },
                new DebugMessage { name = "Particle count" },
            };
        }

        public void Update(GameTime gameTime)
        {
            debugMessages[0].value = Game1.playerManager.playerPosition.ToString();
            debugMessages[1].value = Game1.playerManager.playerLinearVelocity.ToString();
            debugMessages[2].value = Game1.playerManager.playerAngularVelocity.ToString();
            debugMessages[3].value = Game1.playerManager.playerRotation.ToString();
            debugMessages[4].value = Game1.particleManager.particleCount.ToString();

            Vector2 offsetPosition = startingPosition;
            foreach (var debugMessage in debugMessages)
            {
                offsetPosition.Y += offsetAmount;
                debugMessage.position = offsetPosition;
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (var debugMessage in debugMessages) debugMessage.Draw(spriteBatch);
        }
    }
}
