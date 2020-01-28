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
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        PlayerShip playerShip;
        Dictionary<string, Texture2D> textures;
        Vector2 ScreenCenter { get { return new Vector2(graphics.PreferredBackBufferWidth / 2f, graphics.PreferredBackBufferHeight / 2f); } }

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        protected override void Initialize()
        {
            textures = new Dictionary<string, Texture2D>()
            {
                { "basic_ship_main", Content.Load<Texture2D>("Ships/PlayerShips/basic_ship_main") },
            };
            base.Initialize();
        }

        protected override void LoadContent()
        {
            playerShip = new PlayerShip(ScreenCenter, textures["basic_ship_main"], 30f, 10f, 10f, 5f);
            spriteBatch = new SpriteBatch(GraphicsDevice);
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
            GraphicsDevice.Clear(Color.Black);
            spriteBatch.Begin();
            playerShip.Draw(spriteBatch);
            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
