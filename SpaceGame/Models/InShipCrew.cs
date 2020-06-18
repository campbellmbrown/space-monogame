﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Extended;
using SpaceGame.Effects;
using SpaceGame.Managers;
using System;
using System.Collections.Generic;
using System.IO.Pipes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceGame.Models
{
    public class InShipCrew
    {
        protected Vector2 position { get { return _position; } set { animationManager.position = value; _position = value; } }
        protected Vector2 _position;
        protected AnimationManager animationManager;
        protected Animation animation;
        protected Vector2 maxPosition = new Vector2(174, 126);
        protected Shadow shadow;

        public InShipCrew(Animation animation, Vector2 offsetPosition)
        {
            this.animation = animation;
            animationManager = new AnimationManager(animation, AnimationManager.RotationOrigin.BottomMiddle);
            position = offsetPosition + new Vector2(LimitsEdgeGame.r.Next(0, (int)maxPosition.X), LimitsEdgeGame.r.Next(0, (int)maxPosition.Y));
            shadow = new Shadow(LimitsEdgeGame.textures["shadow_1"], 0.2f);
        }

        public void Update(GameTime gameTime)
        {
            shadow.Update(position, animation.frameWidth);
            animationManager.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            shadow.Draw(spriteBatch);
            animationManager.Draw(spriteBatch);
        }
    }
}
