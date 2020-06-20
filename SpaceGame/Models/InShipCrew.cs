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
        protected enum MovementDirec
        {
            Horizontal,
            Vertical
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
        protected MovementDirec movementDirec;
        protected bool horizontalMet = false;
        protected bool verticalMet = false;

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
                        movementDirec = LimitsEdgeGame.r.Next(0, 2) == 0 ? MovementDirec.Horizontal : MovementDirec.Vertical;
                        desiredPosition = GenerateNewPosition();
                        Console.WriteLine("Set: {0}", desiredPosition);
                    }
                    break;
                // Moving state
                case MovementStatus.Moving:
                    if (movementDirec == MovementDirec.Horizontal)
                    {
                        position += new Vector2(movementSpeed, 0) * Math.Sign(desiredPosition.X - position.X) * t;

                        // Temp
                        animationManager.Play(LimitsEdgeGame.animations["crew"]);

                        if (Math.Abs(desiredPosition.X - position.X) < destinationThreshold)
                        {
                            Console.WriteLine((desiredPosition.X - position.X));
                            movementDirec = MovementDirec.Vertical;
                            horizontalMet = true;
                        }
                    }
                    else
                    {
                        position += new Vector2(0, movementSpeed) * Math.Sign(desiredPosition.Y - position.Y) * t;

                        // Temp
                        if (Math.Sign(desiredPosition.Y - position.Y) == 1)
                            animationManager.Play(LimitsEdgeGame.animations["scientist_1_walk_down"]);
                        else
                            animationManager.Play(LimitsEdgeGame.animations["crew"]);

                        if (Math.Abs(desiredPosition.Y - position.Y) < destinationThreshold)
                        {
                            Console.WriteLine((desiredPosition.Y - position.Y));
                            movementDirec = MovementDirec.Horizontal;
                            verticalMet = true;
                        }
                    }
                    if (verticalMet && horizontalMet)
                    {
                        Console.WriteLine("Met: {0}", position);
                        animationManager.Play(LimitsEdgeGame.animations["crew"]);
                        stillTime = GenerateStillTime();
                        movementStatus = MovementStatus.Still;
                        horizontalMet = false;
                        verticalMet = false;
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
