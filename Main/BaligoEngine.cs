using Baligo.Content.Fonts;
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
        public static int Height = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height;
        public static int Width = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width;

        public BaligoEngine()
        {
            graphicsDeviceManager = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            SetBorderless();
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // Initialize states
            DeadMenuState = new DeadMenu();
            MainMenuState = new MainMenu();
            MainGameState = new MainGame();
            PauseMenuState = new PauseMenu();
            StatsMenuState = new StatsMenu();

            // Set Default Enter State
            if (State.GetCurrentState() == null)
                State.SetCurrentState(MainMenuState);

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
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // Update current state
            if (State.GetCurrentState() != null)
                State.GetCurrentState().Update();

            // Update input
            InputManager.Update();

            // Do not touch
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

            if (State.GetCurrentState() != null)
                State.GetCurrentState().Draw(spriteBatch);

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
            /* Fullscreen
             graphicsDeviceManager.IsFullScreen = true;
            */
            Window.IsBorderless = true;
        }

        /// <summary>
        /// Loads all the textures
        /// </summary>
        public static void LoadTextures()
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
