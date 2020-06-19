using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Extended;
using SpaceGame.Effects;
using SpaceGame.Managers;
using System;
using System.Collections.Generic;
using System.IO.Pipes;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace SpaceGame.Models
{
    public class InShipCrew
    {
        protected enum MovementStatus
        {
            Moving,
            Still
        }
        public Vector2 position { get { return _position; } set { animationManager.position = value; _position = value; } }
        protected Vector2 _position;
        protected AnimationManager animationManager;
        protected Animation animation;
        protected Vector2 maxPosition = new Vector2(174, 126);
        protected int width { get { return animation.frameWidth; } }
        protected int height { get { return animation.frameHeight; } }
        protected Rectangle hoverRectangle { get { return new Rectangle((int)position.X - width / 2, (int)position.Y - height, width, height); } }
        protected Shadow shadow;
        public string name;
        protected List<string> maleNames = new List<string> { "Liam", "Noah", "William", "James", "Logan", "Billy" };
        protected Vector2 offsetPosition;
        // Movement
        protected Vector2 desiredPosition;
        protected float stillTime;
        protected float currentStillTime = 0;
        protected float movementSpeed = 18;
        protected float destinationThreshold = 1;
        protected MovementStatus movementStatus = MovementStatus.Still;

        public InShipCrew(Animation animation, Vector2 offsetPosition)
        {
            this.animation = animation;
            this.offsetPosition = offsetPosition;
            animationManager = new AnimationManager(animation, AnimationManager.RotationOrigin.BottomMiddle);
            position = offsetPosition + new Vector2(LimitsEdgeGame.r.Next(0, (int)maxPosition.X), LimitsEdgeGame.r.Next(0, (int)maxPosition.Y));
            shadow = new Shadow(LimitsEdgeGame.textures["shadow_1"], 0.2f);
            name = maleNames[LimitsEdgeGame.r.Next(0, maleNames.Count)];
            stillTime = GenerateStillTime();
        }

        public void Update(GameTime gameTime)
        {
            Move((float)gameTime.ElapsedGameTime.TotalSeconds);
            shadow.Update(position, animation.frameWidth);
            animationManager.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            shadow.Draw(spriteBatch);
            animationManager.Draw(spriteBatch);
        }

        public void Move(float t)
        {
            switch (movementStatus)
            {
                // Still state
                case MovementStatus.Still:
                    currentStillTime += t;
                    if (currentStillTime >= stillTime)
                    {
                        currentStillTime = 0;
                        movementStatus = MovementStatus.Moving;
                        desiredPosition = GenerateNewPosition();
                    }
                    break;
                // Moving state
                case MovementStatus.Moving:
                    position += movementSpeed * (Vector2.Normalize(desiredPosition - position)) * t;
                    if ((desiredPosition - position).Length() < destinationThreshold)
                    {
                        stillTime = GenerateStillTime();
                        movementStatus = MovementStatus.Still;
                    }
                    break;
            }

        }

        public bool CheckHover(Vector2 mousePosition)
        {
            return (hoverRectangle.Contains(mousePosition));
        }

        protected Vector2 GenerateNewPosition()
        {
            return offsetPosition + new Vector2(LimitsEdgeGame.r.Next(0, (int)maxPosition.X), LimitsEdgeGame.r.Next(0, (int)maxPosition.Y));
        }

        protected float GenerateStillTime()
        {
            // Stands still for between 1 and 20 seconds
            return LimitsEdgeGame.r.Next(1000, 20000) / 1000;
        }
    }
}
