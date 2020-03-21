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
    public enum GameState
    {
        World,
        Spaceship
    }

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
        public static ProjectileManager projectileManager;

        // States
        public static GameState gameState;
        public static WorldStateManager worldStateManager;
        public static ShipStateManager shipStateManager;

        public static DebugManager debugManager;
        public static EventManager eventManager;
        public static GuiManager guiManager;

        Vector2 windowSize { get { return new Vector2(GraphicsDevice.Viewport.Width, GraphicsDevice.Viewport.Height); } }
        Vector2 windowCenter { get { return windowSize / 2f; } }

        public LimitsEdgeGame()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            graphics.PreferredBackBufferWidth = (int)screenSize.X;
            graphics.PreferredBackBufferHeight = (int)screenSize.Y;
            graphics.IsFullScreen = false;
        }

        protected override void Initialize()
        {
            gameState = GameState.World;
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

            // Creating the player manager
            playerManager = new PlayerManager(camera);
            // Creating state managers
            worldStateManager = new WorldStateManager();
            shipStateManager = new ShipStateManager();
            // Other managers
            projectileManager = new ProjectileManager(worldStateManager);
            debugManager = new DebugManager();
            guiManager = new GuiManager();
            worldStateManager.crateManager.TopUpCrates();
        }

        protected override void UnloadContent()
        {
        }

        protected override void Update(GameTime gameTime)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            playerManager.Update(gameTime);
            switch (gameState)
            {
                case GameState.World:
                    worldStateManager.Update(gameTime);
                    break;
                case GameState.Spaceship:
                    shipStateManager.Update(gameTime);
                    break;
            }
            projectileManager.Update(gameTime);
            debugManager.Update(gameTime);
            guiManager.Update(gameTime);
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, SamplerState.PointWrap, DepthStencilState.None, RasterizerState.CullCounterClockwise, null, transformMatrix: camera.GetViewMatrix()); 
            GraphicsDevice.Clear(Color.Black);
            
            switch (gameState)
            {
                case GameState.World:
                    worldStateManager.Draw(spriteBatch);
                    break;
                case GameState.Spaceship:
                    shipStateManager.Draw(spriteBatch);
                    break;
            }
            playerManager.Draw(spriteBatch);
            projectileManager.Draw(spriteBatch);
            debugManager.Draw(spriteBatch);
            guiManager.Draw(spriteBatch);
            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
