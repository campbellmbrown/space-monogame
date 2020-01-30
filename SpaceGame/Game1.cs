using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonoGame.Extended;
using SpaceGame.Managers;
using SpaceGame.Sprites;
using System;
using System.Collections.Generic;

namespace SpaceGame
{
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Camera2D camera;

        public static Random r;
        public static float zoom = 3f;
        public static Dictionary<string, Texture2D> textures;
        public static Vector2 ScreenSize { get { return new Vector2(GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width, GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height); } }
        public static Vector2 ScreenCenter { get { return ScreenSize / 2f; } }
        
        Vector2 WindowSize { get { return new Vector2(GraphicsDevice.Viewport.Width, GraphicsDevice.Viewport.Height); } }
        Vector2 WindowCenter { get { return WindowSize / 2f; } }

        private PlayerManager _playerManager;
        private WorldManager _worldManager;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            graphics.PreferredBackBufferWidth = (int)ScreenSize.X;
            graphics.PreferredBackBufferHeight = (int)ScreenSize.Y;
            graphics.IsFullScreen = true;
        }

        protected override void Initialize()
        {
            camera = new Camera2D(GraphicsDevice)
            {
                Zoom = zoom,
                Position = -ScreenSize / 2f
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
            };
            
            _playerManager = new PlayerManager(camera);
            _worldManager = new WorldManager();
        }

        protected override void UnloadContent()
        {
        }

        protected override void Update(GameTime gameTime)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            _playerManager.Update(gameTime);
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, SamplerState.PointWrap, DepthStencilState.None, RasterizerState.CullCounterClockwise, null, transformMatrix: camera.GetViewMatrix()); 
            GraphicsDevice.Clear(Color.Black);
            spriteBatch.DrawRectangle(new Rectangle(-10, -10, 20, 20), Color.Red);
            _worldManager.Draw(spriteBatch);
            _playerManager.Draw(spriteBatch);
            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
