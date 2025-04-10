using DesignPatterns.CommandPattern;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace DesignPatterns
{
    public class GameWorld : Game
    {
        private static GameWorld instance;

        public static GameWorld Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new GameWorld();
                }

                return instance;
            }
        }

        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private Player player;

        InputHandler inputHandler = InputHandler.Instance;

        public float DeltaTime { get; private set; } 

        public static int Height { get; set; }
        public static int Width { get; set; }

        private GameWorld()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            GameWorld.Height = _graphics.PreferredBackBufferHeight;
            GameWorld.Width = _graphics.PreferredBackBufferWidth;
            player = new Player(new Vector2(GameWorld.Width / 2, GameWorld.Height));
            inputHandler.AddUpdateCommand(Keys.A, new MoveCommand(player, new Vector2(-1, 0)));
            inputHandler.AddUpdateCommand(Keys.D, new MoveCommand(player, new Vector2(1, 0)));
            inputHandler.AddButtonDownCommand(Keys.Q, new TeleportCommand(player, new Vector2(-1, -1) * 10));
            inputHandler.AddButtonDownCommand(Keys.E, new TeleportCommand(player, new Vector2(1, -1) * 10));
            inputHandler.AddButtonDownCommand(Keys.Z, new TeleportCommand(player, new Vector2(-1, 1) * 10));
            inputHandler.AddButtonDownCommand(Keys.C, new TeleportCommand(player, new Vector2(1, 1) * 10));
            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            player.LoadContent(Content);
            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            DeltaTime = (float)gameTime.ElapsedGameTime.TotalSeconds;
            inputHandler.Execute();

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here

            _spriteBatch.Begin();
            player.Draw(_spriteBatch);
            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
