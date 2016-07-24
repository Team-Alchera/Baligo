using Baligo.Console;
using Baligo.ConsoleDebug;
using Baligo.Content.Fonts;
using Baligo.Entity.Characters.Players;
using Baligo.Entity.Custom_Mouse;
using Baligo.Graphics;
using Baligo.Input;
using Baligo.States;
using Baligo.World;
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
        public readonly GraphicsDeviceManager GraphicsDeviceManager;
        private SpriteBatch _spriteBatch;

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
        public static bool IsConsoleActive;
        public static bool IsPlayerInGodMode;

        public BaligoEngine()
        {
            GraphicsDeviceManager = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            SetBorderless();
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling LoadAssets will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // Init console
            BaligoConsole.Init();

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
            BaligoConsole.WriteLine("All states initialized !", Color.Magenta);
            BaligoConsole.WriteLine("Current state is: Main Game", Color.Magenta);
            BaligoConsole.WriteLine("=======", Color.Yellow);

            // Set default state for debug mode
            IsDebugModeActive = false;
            IsConsoleActive = false;
            IsPlayerInGodMode = false;

            // Init worlds
            WorldManager.Init();

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            _spriteBatch = new SpriteBatch(GraphicsDevice);

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
        private int _waitTime = 15;
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
            if (InputManager.F1IsPressed && _waitTime == 0)
            {
                IsDebugModeActive = !IsDebugModeActive;
                IsPlayerInGodMode = !IsPlayerInGodMode;
                BaligoConsole.WriteLine(IsDebugModeActive ? "Debug mode: ACTIVE" : "Debug mode: DISABLED", Color.Magenta);

                _waitTime = 15;
            }

            // Update Console State 
            if (InputManager.ConsoleKey && _waitTime == 0)
            {
                IsConsoleActive = !IsConsoleActive;
                _waitTime = 15;
            }

            // Debug Mode Update
            DebugMode.Update();

            // Do not touch
            if (_waitTime - 1 >= 0)
                _waitTime--;
            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            _spriteBatch.Begin();

            // Draw State Frame
            if (State.GetCurrentState() != null)
                State.GetCurrentState().Draw(_spriteBatch);

            // Draw CursorNormal
            CustomMaouse.Draw(_spriteBatch);

            // Console Show
            if (IsConsoleActive)
            {
                BaligoConsole.Draw(_spriteBatch);
            }

            // Debug Mode Show
            if (IsDebugModeActive)
            {
                DebugMode.Draw(_spriteBatch);
            }
            _spriteBatch.End();

            // Do not touch
            base.Draw(gameTime);
        }

        /// <summary>
        /// This Method will set the window to full screen borderless
        /// </summary>
        private void SetBorderless()
        {
            GraphicsDeviceManager.PreferredBackBufferHeight = 768;
            GraphicsDeviceManager.PreferredBackBufferWidth = 1366;

            // Full screen
            // GraphicsDeviceManager.IsFullScreen = true;

            Window.IsBorderless = true;
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
            Fonts.Arial = Content.Load<SpriteFont>("Fonts/Arial");
            Fonts.Console = Content.Load<SpriteFont>("Fonts/Console");
            Fonts.HealthFont = Content.Load<SpriteFont>("Fonts/Health");
        }
    }
}
