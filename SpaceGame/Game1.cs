using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonoGame.Extended;
using SpaceGame.Sprites;
using System.Collections.Generic;

namespace SpaceGame
{
    public class Game1 : Game
    {
        static Dictionary<string, Texture2D> textures;
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Vector2 ScreenSize { get { return new Vector2(GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width, GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height); } }
        Vector2 WindowSize { get { return new Vector2(GraphicsDevice.Viewport.Width, GraphicsDevice.Viewport.Height); } }
        Vector2 ScreenCenter { get { return ScreenSize / 2f; } }
        Vector2 WindowCenter { get { return WindowSize / 2f; } }
        PlayerShip playerShip;
        Camera2D camera;

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
            camera = new Camera2D(GraphicsDevice);
            IsMouseVisible = true;
            IsFixedTimeStep = true;
            graphics.SynchronizeWithVerticalRetrace = true;
            base.Initialize();
            spriteBatch = new SpriteBatch(GraphicsDevice);
        }

        protected override void LoadContent()
        {
            textures = new Dictionary<string, Texture2D>()
            {
                { "basic_ship_main", Content.Load<Texture2D>("Ships/PlayerShips/basic_ship_main") },
            };
            playerShip = new PlayerShip(WindowCenter, textures["basic_ship_main"], 30f, 10f, 10f, 5f);
        }

        protected override void UnloadContent()
        {
        }

        protected override void Update(GameTime gameTime)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            playerShip.Update(gameTime);
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, SamplerState.PointWrap, DepthStencilState.None, RasterizerState.CullCounterClockwise, null, transformMatrix: camera.GetViewMatrix()); 
            playerShip.Draw(spriteBatch);
            GraphicsDevice.Clear(Color.Black);
            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
