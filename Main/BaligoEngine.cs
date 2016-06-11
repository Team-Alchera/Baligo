using Baligo.Content.Fonts;
using Baligo.Entity.Custom_Mouse;
using Baligo.Graphics;
using Baligo.Input;
using Baligo.States;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Baligo.Main
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class BaligoEngine : Game
    {
        private readonly GraphicsDeviceManager graphicsDeviceManager;
        private SpriteBatch spriteBatch;

        // States
        public static DeadMenu DeadMenuState;
        public static MainMenu MainMenuState;
        public static MainGame MainGameState;
        public static PauseMenu PauseMenuState;
        public static StatsMenu StatsMenuState;

        // Window
        public static int Height = 768;
        public static int Width = 1344;

        // Debug Mode
        public static bool IsDebugModeActive;

        public BaligoEngine()
        {
            graphicsDeviceManager = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            SetBorderless();
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.LoadAssets will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // Load all assets
            Assets.LoadAssets(Content);

            // Load states
            DeadMenuState = new DeadMenu();
            MainMenuState = new MainMenu();
            MainGameState = new MainGame();
            PauseMenuState = new PauseMenu();
            StatsMenuState = new StatsMenu();

            // Set Default EnterIsPressed State
            State.SetCurrentState(MainGameState);
            MainGameState.Init();

            // Set default state for debug mode
            IsDebugModeActive = false;

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            LoadTextures();
            LoadFonts();
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {

        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        private int waitTime = 15;
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // Update current state
            if (State.GetCurrentState() != null)
                State.GetCurrentState().Update(gameTime);

            // Update input
            InputManager.Update();

            // Update Debug Mode State
            if (InputManager.F1IsPressed && waitTime == 0)
            {
                IsDebugModeActive = !IsDebugModeActive;
                waitTime = 15;
            }

            // Do not touch
            if (waitTime - 1 >= 0)
                waitTime--;
            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            spriteBatch.Begin();

            // Draw State Frame
            if (State.GetCurrentState() != null)
                State.GetCurrentState().Draw(spriteBatch);

            // Draw CursorNormal
            CustomMaouse.Draw(spriteBatch);

            // Debug Mode Show
            if (IsDebugModeActive)
            {
                spriteBatch.DrawString(
                    Fonts.Arial,
                    "Debug",
                    new Vector2(0, 0),
                    Color.Red);
            }

            spriteBatch.End();

            // Do not touch
            base.Draw(gameTime);
        }

        /// <summary>
        /// This Method will set the window to full screen borderless
        /// </summary>
        private void SetBorderless()
        {
            graphicsDeviceManager.PreferredBackBufferHeight = Height;
            graphicsDeviceManager.PreferredBackBufferWidth = Width;

            // Full screen
            graphicsDeviceManager.IsFullScreen = true;
        }

        /// <summary>
        /// Loads all the textures
        /// </summary>
        public void LoadTextures()
        {

        }

        /// <summary>
        /// Load all the fonts
        /// </summary>
        public void LoadFonts()
        {
            Fonts.Arial = this.Content.Load<SpriteFont>("Fonts/Arial");
        }
    }
}
