using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonoGame.Extended;
using SpaceGame.Effects;
using SpaceGame.Managers;
using SpaceGame.Models;
using SpaceGame.Sprites;
using SpaceGame.World;
using System;
using System.Collections.Generic;

namespace SpaceGame
{
    /// <summary>
    /// Class where the main game loop is occurring. Inherits the Game class.
    /// </summary>
    public class LimitsEdgeGame : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        public static Camera2D camera;
        public static Random r;
        public static float zoom = 3f;
        public static Dictionary<string, Texture2D> textures;
        public static Dictionary<string, Animation> animations;
        public static Dictionary<string, SpriteFont> fonts;
        public static Vector2 screenSize { get { return new Vector2(GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width, GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height); } }
        public static Vector2 zoomedScreenSize { get { return screenSize / zoom; } }
        public static Vector2 positionCenter { get { return playerManager.playerShip.position; } }
        public static Vector2 screenCenter { get { return screenSize / 2f; } }
        public static Vector2 topLeftCorner { get { return positionCenter - screenCenter / camera.Zoom; } }
        
        public static PlayerManager playerManager;
        public static ParticleManager particleManager;
        public static ProjectileManager projectileManager;
        public static WorldManager worldManager;
        public static DebugManager debugManager;
        public static EventManager eventManager;
        public static GuiManager guiManager;

        Vector2 windowSize { get { return new Vector2(GraphicsDevice.Viewport.Width, GraphicsDevice.Viewport.Height); } }
        Vector2 windowCenter { get { return windowSize / 2f; } }

        /// <summary>
        /// Creates an instance of the LimitsEdgeGame class.
        /// </summary>
        public LimitsEdgeGame()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            graphics.PreferredBackBufferWidth = (int)screenSize.X;
            graphics.PreferredBackBufferHeight = (int)screenSize.Y;
            graphics.IsFullScreen = false;
        }

        /// <summary>
        /// Initializes the game.
        /// </summary>
        protected override void Initialize()
        {
            camera = new Camera2D(GraphicsDevice)
            {
                Zoom = zoom,
                Position = -screenSize / 2f
            };
            IsMouseVisible = true;
            IsFixedTimeStep = true;
            graphics.SynchronizeWithVerticalRetrace = true;
            r = new Random();
            base.Initialize();
            spriteBatch = new SpriteBatch(GraphicsDevice);
        }

        /// <summary>
        /// Loads the content for the game.
        /// </summary>
        protected override void LoadContent()
        {
            textures = new Dictionary<string, Texture2D>()
            {
                { "basic_ship_main", Content.Load<Texture2D>("Ships/PlayerShips/basic_ship_main") },
                { "basic_ship_wings", Content.Load<Texture2D>("Ships/PlayerShips/basic_ship_wings") },
                { "plastic", Content.Load<Texture2D>("Items/plastic") },
                { "metal", Content.Load<Texture2D>("Items/metal") },
                { "plants", Content.Load<Texture2D>("Items/plants") },
                { "crate", Content.Load<Texture2D>("Sprites/crate") },
                { "lazer", Content.Load<Texture2D>("Projectiles/lazer") },
                { "asteroid_chunk", Content.Load<Texture2D>("World/asteroid_chunk") },
            };

            animations = new Dictionary<string, Animation>()
            {
                { "smoke", new Animation(Content.Load<Texture2D>("Effects/smoke"), 5,  0.2f) },
                { "small_explosion", new Animation(Content.Load<Texture2D>("Effects/small_explosion"), 7,  0.1f) },
            };

            fonts = new Dictionary<string, SpriteFont>()
            {
                { "courier_new", Content.Load<SpriteFont>("Fonts/courier_new") },
                { "courier_new_bold", Content.Load<SpriteFont>("Fonts/courier_new_bold") },
                { "courier_new_italic", Content.Load<SpriteFont>("Fonts/courier_new_italic") }
            };

            playerManager = new PlayerManager(camera);
            worldManager = new WorldManager();
            particleManager = new ParticleManager();
            projectileManager = new ProjectileManager(worldManager);
            debugManager = new DebugManager();
            eventManager = new EventManager();
            guiManager = new GuiManager();
            worldManager.crateManager.TopUpCrates();
            worldManager.asteroidManager.asteroids.Add(new Asteroid(Vector2.Zero, 10, 20));
            worldManager.asteroidManager.asteroids.Add(new Asteroid(Vector2.Zero, 10, 20));
            worldManager.asteroidManager.asteroids.Add(new Asteroid(Vector2.Zero, 10, 20));

        }

        /// <summary>
        /// Unloads the content for the game.
        /// </summary>
        protected override void UnloadContent()
        {
        }

        /// <summary>
        /// Updates the game.
        /// </summary>
        /// <param name="gameTime">GameTime instance.</param>
        protected override void Update(GameTime gameTime)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            eventManager.Update(gameTime);
            playerManager.Update(gameTime);
            worldManager.Update(gameTime);
            particleManager.Update(gameTime);
            projectileManager.Update(gameTime);
            debugManager.Update(gameTime);
            guiManager.Update(gameTime);
            base.Update(gameTime);
        }

        /// <summary>
        /// Draws the game.
        /// </summary>
        /// <param name="gameTime">GameTime instance.</param>
        protected override void Draw(GameTime gameTime)
        {
            spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, SamplerState.PointWrap, DepthStencilState.None, RasterizerState.CullCounterClockwise, null, transformMatrix: camera.GetViewMatrix()); 
            GraphicsDevice.Clear(Color.Black);
            worldManager.Draw(spriteBatch);
            particleManager.Draw(spriteBatch);
            playerManager.Draw(spriteBatch);
            projectileManager.Draw(spriteBatch);
            debugManager.Draw(spriteBatch);
            guiManager.Draw(spriteBatch);
            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
