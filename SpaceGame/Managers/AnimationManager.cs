using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SpaceGame.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceGame.Managers
{
    public class AnimationManager
    {
        public enum RotationOrigin
        {
            Center,
            BottomMiddle,
            TopLeft
        }

        public Vector2 position;
        public int frameCount;
        protected float scale;
        public float frameSpeed;
        private int _currentFrame;
        private bool _pause;
        private bool _reverse = false;
        private float _timer;
        private Animation _animation;
        protected Vector2 center { get { return new Vector2(_animation.frameWidth / 2f, _animation.frameHeight / 2f); } }
        protected Vector2 bottomMiddle { get { return new Vector2(_animation.frameWidth / 2f, _animation.frameHeight); } }
        RotationOrigin rotationOrigin;

        public AnimationManager(Animation animation, RotationOrigin rotationOrigin, float scale = 1f)
        {
            this.rotationOrigin = rotationOrigin;
            this.scale = scale;
            _animation = animation;
            frameCount = animation.frameCount;
            frameSpeed = animation.frameSpeed;
            _currentFrame = 0;
            _timer = 0;
        }

        public void Draw(SpriteBatch spriteBatch, float rotation = 0f)
        {
            Draw(spriteBatch, Color.White, rotation);
        }

        public void Draw(SpriteBatch spriteBatch, Color color, float rotation = 0f)
        {
            Rectangle rectangle = new Rectangle(_currentFrame * _animation.frameWidth, 0, _animation.frameWidth, _animation.frameHeight);
            switch (rotationOrigin)
            {
                case RotationOrigin.Center:
                    spriteBatch.Draw(_animation.texture, position, rectangle, color, rotation, center, scale, SpriteEffects.None, 0f);
                    break;
                case RotationOrigin.BottomMiddle:
                    spriteBatch.Draw(_animation.texture, position, rectangle, color, rotation, bottomMiddle, scale, SpriteEffects.None, 0f);
                    break;
                case RotationOrigin.TopLeft:
                    spriteBatch.Draw(_animation.texture, position, rectangle, color, rotation, Vector2.Zero, scale, SpriteEffects.None, 0f);
                    break;
            }
        }

        public void Reset()
        {
            _currentFrame = 0;
        }

        public void Play(Animation animation)
        {
            if (this._animation != animation)
            {
                this._animation = animation;
                frameCount = animation.frameCount;
                frameSpeed = animation.frameSpeed;
                _currentFrame = 0;
                _timer = 0;
            }
        }

        public void Update(GameTime gameTime)
        {
            _timer += (float)gameTime.ElapsedGameTime.TotalSeconds;
            if (_timer > frameSpeed)
            {
                _timer -= frameSpeed;
                if (!_reverse)
                {
                    _currentFrame++;
                    if (_currentFrame >= frameCount) // Reached the end of the animation
                    {
                        _currentFrame = 0; // Reset animation
                        if (!_animation.isLooping) // or stop looping
                        {
                            _pause = true;
                            _currentFrame = frameCount - 1;
                        }
                    }
                }
                else
                {
                    _currentFrame--;
                    if (_currentFrame <= 0)
                    {
                        _currentFrame = frameCount - 1;
                        if (!_animation.isLooping) // or stop looping
                        {
                            _pause = true;
                            _currentFrame = 0;
                        }
                    }
                }
            }
        }
    }
}
