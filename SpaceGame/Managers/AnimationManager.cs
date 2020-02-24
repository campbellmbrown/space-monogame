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
    /// <summary>
    /// Class to handle animation.
    /// </summary>
    public class AnimationManager
    {
        public Vector2 position;
        public int frameCount;
        public float frameSpeed;
        private int _currentFrame;
        private bool _pause;
        private bool _reverse = false;
        private float _timer;
        private Animation _animation;
        private Vector2 _center { get { return new Vector2(_animation.frameWidth / 2f, _animation.frameHeight / 2f); } }
        
        /// <summary>
        /// Creates a new instance of the AnimationManager class.
        /// </summary>
        /// <param name="animation">The animation to manage.</param>
        public AnimationManager(Animation animation)
        {
            _animation = animation;
            frameCount = animation.frameCount;
            frameSpeed = animation.frameSpeed;
            _currentFrame = 0;
            _timer = 0;
        }

        /// <summary>
        /// Draws the animation.
        /// </summary>
        /// <param name="spriteBatch">SpriteBatch instance.</param>  
        public void Draw(SpriteBatch spriteBatch)
        {
            Rectangle rectangle = new Rectangle(_currentFrame * _animation.frameWidth, 0, _animation.frameWidth, _animation.frameHeight);
            spriteBatch.Draw(_animation.texture, position, rectangle, Color.White, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0f);
        }

        /// <summary>
        /// Draws the animation.
        /// </summary>
        /// <param name="spriteBatch">SpriteBatch instance.</param>
        /// <param name="rotation">Rotation of the animation.</param>
        public void Draw(SpriteBatch spriteBatch, float rotation)
        {
            Rectangle rectangle = new Rectangle(_currentFrame * _animation.frameWidth, 0, _animation.frameWidth, _animation.frameHeight);
            spriteBatch.Draw(_animation.texture, position, rectangle, Color.White, rotation, _center, 1f, SpriteEffects.None, 0f);
        }

        /// <summary>
        /// Resets the current animation to it's first frame.
        /// </summary>
        public void Reset()
        {
            _currentFrame = 0;
        }

        /// <summary>
        /// Changes the animation.
        /// </summary>
        /// <param name="animation">Animation to switch to.</param>
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

        /// <summary>
        /// Updates the animation.
        /// </summary>
        /// <param name="gameTime">GameTime instance.</param>
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
