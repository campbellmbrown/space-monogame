using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonoGame.Extended;
using MonoGame.Extended.BitmapFonts;
using SpaceGame.Effects;
using SpaceGame.Managers;
using SpaceGame.Managers.InventoryStateManagers;
using SpaceGame.Models;
using SpaceGame.Sprites;
using SpaceGame.Utilities;
using SpaceGame.World;
using System;
using System.Collections.Generic;

namespace SpaceGame
{
    public enum GameState
    {
        World,
        Inventory,
        InGameMenu
    }

    public class LimitsEdgeGame : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        public static Camera2D currentCamera;
        public static Camera2D worldCamera;
        public static Camera2D inGameMenuCamera;
        public static Camera2D inventoryCamera;

        public static Random r;
        public static Dictionary<string, Texture2D> textures;
        public static Dictionary<string, Animation> animations;
        public static Dictionary<string, SpriteFont> fonts;
        public static Dictionary<string, BitmapFont> bitmapFonts;

        public static Vector2 screenSize { get { return new Vector2(GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width, GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height); } }
        public static Vector2 zoomedScreenSize { get { return screenSize / currentZoom; } }
        public static Vector2 topLeft { get { return Vector2.Transform(Vector2.Zero, currentCamera.GetInverseViewMatrix()); } }
        //public static Vector2 topLeft { get { return currentCamera.Position + (screenSize - zoomedScreenSize) / 2f; } }
        public static Vector2 mousePosition { get { return Vector2.Transform(Helper.PointToVector2(Mouse.GetState().Position), currentCamera.GetInverseViewMatrix()); } }
        public static float currentZoom { get { return currentCamera.Zoom; } }

        public static CursorManager cursorManager;

        // States
        public static GameState gameState;
        public static WorldStateManager worldStateManager;
        public static InventoryStateManager inventoryStateManager;
        public static InGameMenuStateManager inGameMenuStateManager;

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
            worldCamera = new Camera2D(GraphicsDevice) { Zoom = 2, Position = -screenSize / 2f };
            inGameMenuCamera = new Camera2D(GraphicsDevice) { Zoom = 2, Position = -screenSize / 2f };
            inventoryCamera = new Camera2D(GraphicsDevice) { Zoom = 2, Position = -screenSize / 2f };
            currentCamera = worldCamera;
            IsMouseVisible = false;
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
                // World
                { "basic_ship_main", Content.Load<Texture2D>("Ships/basic_ship_main") },
                { "basic_ship_wings", Content.Load<Texture2D>("Ships/basic_ship_wings") },
                { "stranded_1", Content.Load<Texture2D>("Sprites/stranded_1") },
                { "lazer", Content.Load<Texture2D>("Projectiles/lazer") },
                { "asteroid_chunk", Content.Load<Texture2D>("World/asteroid_chunk") },
                { "large_cloud_1", Content.Load<Texture2D>("World/large_cloud_1") },
                { "crate", Content.Load<Texture2D>("Sprites/crate") },
                // Items
                { "metal", Content.Load<Texture2D>("Items/metal") },
                { "plants", Content.Load<Texture2D>("Items/plants") },
                { "plastic", Content.Load<Texture2D>("Items/plastic") },
                { "asteroid_rock", Content.Load<Texture2D>("Items/asteroid_rock") },
                { "ridoxium_gear", Content.Load<Texture2D>("Items/ridoxium_gear") },
                // General
                { "arrow_cursor", Content.Load<Texture2D>("Effects/arrow_cursor") },
                { "shadow_1", Content.Load<Texture2D>("Effects/shadow_1") },
                // GUI
                { "selection_bar", Content.Load<Texture2D>("GUI/selection_bar") },
                { "selection_bar_dark", Content.Load<Texture2D>("GUI/selection_bar_dark") },
                { "selection_bar_dark_highlighted", Content.Load<Texture2D>("GUI/selection_bar_dark_highlighted") },
                { "item_slot", Content.Load<Texture2D>("GUI/item_slot") },
                { "crew_menu", Content.Load<Texture2D>("GUI/crew_menu") },
                { "label", Content.Load<Texture2D>("GUI/label") },
                { "equipment_icons", Content.Load<Texture2D>("GUI/equipment_icons") }
            };

            animations = new Dictionary<string, Animation>()
            {
                { "smoke", new Animation(Content.Load<Texture2D>("Effects/smoke"), 5,  0.2f) },
                { "small_explosion", new Animation(Content.Load<Texture2D>("Effects/small_explosion"), 7,  0.1f) },
                { "laser_particle", new Animation(Content.Load<Texture2D>("Effects/laser_particle"), 8,  0.1f) },
                { "crew", new Animation(Content.Load<Texture2D>("Crew/Crew"), 2, 1f) },
                { "scientist_1_walk_down", new Animation(Content.Load<Texture2D>("Crew/scientist_1_walk_down"), 10, 0.1f) },
                { "scientist_1_walk_up", new Animation(Content.Load<Texture2D>("Crew/scientist_1_walk_up"), 10, 0.1f) },
            };

            fonts = new Dictionary<string, SpriteFont>()
            {
                { "courier_new", Content.Load<SpriteFont>("Fonts/courier_new") },
                { "courier_new_bold", Content.Load<SpriteFont>("Fonts/courier_new_bold") },
                { "courier_new_italic", Content.Load<SpriteFont>("Fonts/courier_new_italic") }
            };

            bitmapFonts = new Dictionary<string, BitmapFont>()
            {
                { "game_font_16", Content.Load<BitmapFont>("Fonts/gameFont") }
            };


            // Creating state managers
            worldStateManager = new WorldStateManager();
            inventoryStateManager = new InventoryStateManager();
            inGameMenuStateManager = new InGameMenuStateManager();
            // Other managers
            cursorManager = new CursorManager();
        }

        protected override void UnloadContent()
        {
        }

        public static void SwitchState(GameState currentGameState, GameState nextGameState)
        {
            switch (nextGameState) {
                case GameState.World:
                    currentCamera = worldCamera;
                    break;
                case GameState.InGameMenu:
                    currentCamera = inGameMenuCamera;
                    break;
                case GameState.Inventory:
                    currentCamera = inventoryCamera;
                    break;
            }


            gameState = nextGameState;
        }

        protected override void Update(GameTime gameTime)
        {
            switch (gameState)
            {
                case GameState.World:
                    worldStateManager.Update(gameTime);
                    break;
                case GameState.Inventory:
                    inventoryStateManager.Update(gameTime);
                    break;
                case GameState.InGameMenu:
                    inGameMenuStateManager.Update(gameTime);
                    break;
            }
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, SamplerState.PointWrap, DepthStencilState.None, RasterizerState.CullCounterClockwise, null, transformMatrix: currentCamera.GetViewMatrix()); 
            GraphicsDevice.Clear(Color.Black);
            
            switch (gameState)
            {
                case GameState.World:
                    worldStateManager.Draw(spriteBatch);
                    break;
                case GameState.Inventory:
                    inventoryStateManager.Draw(spriteBatch);
                    break;
                case GameState.InGameMenu:
                    inGameMenuStateManager.Draw(spriteBatch);
                    break;
            }
            cursorManager.Draw(spriteBatch);
            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
