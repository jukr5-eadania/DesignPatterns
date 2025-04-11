using DesignPatterns.CommandPattern;
using DesignPatterns.ComponentPattern;
using DesignPatterns.Factory;
using DesignPatterns.ObjectPool;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Diagnostics;

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

        private List<GameObject> gameObjects = new();
        private List<GameObject> newGameObjects = new();
        private List<GameObject> destroyedGameObjects = new();

        private InputHandler inputHandler = InputHandler.Instance;

        float lastSpawn;
        float spawnTime = 3;

        public float DeltaTime { get; private set; } 

        public int Height { get; set; }
        public int Width { get; set; }

        private GameWorld()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            Height = _graphics.PreferredBackBufferHeight;
            Width = _graphics.PreferredBackBufferWidth;

            GameObject playerGo = new();
            Player player = playerGo.AddComponent<Player>();
            playerGo.AddComponent<SpriteRenderer>();
            gameObjects.Add(playerGo);

            
            //gameObjects.Add(EnemyFactory.Instance.CreateEnemy(EnemyType.SLOW));
            //gameObjects.Add(EnemyFactory.Instance.CreateEnemy(EnemyType.FAST));
            //gameObjects.Add(EnemyFactory.Instance.CreateEnemy(EnemyType.MULTIPLE));


            foreach (var gameObject in gameObjects)
            {
                gameObject.Awake();
            }

            inputHandler.AddUpdateCommand(Keys.A, new MoveCommand(player, new Vector2(-1, 0)));
            inputHandler.AddUpdateCommand(Keys.D, new MoveCommand(player, new Vector2(1, 0)));
            inputHandler.AddButtonDownCommand(Keys.Q, new TeleportCommand(player, new Vector2(-1, -1) * 10));
            inputHandler.AddButtonDownCommand(Keys.E, new TeleportCommand(player, new Vector2(1, -1) * 10));
            inputHandler.AddButtonDownCommand(Keys.Z, new TeleportCommand(player, new Vector2(-1, 1) * 10));
            inputHandler.AddButtonDownCommand(Keys.C, new TeleportCommand(player, new Vector2(1, 1) * 10));
            inputHandler.AddButtonDownCommand(Keys.Space, new ShootCommand(player));
            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            foreach (var gameObject in gameObjects)
            {
                gameObject.Start();
            }
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            DeltaTime = (float)gameTime.ElapsedGameTime.TotalSeconds;
            inputHandler.Execute();
            foreach (var gameObject in gameObjects)
            {
                gameObject.Update();
            }

            SpawnEnemies();
            base.Update(gameTime);
            Cleanup();
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            _spriteBatch.Begin();
            foreach (var gameObject in gameObjects)
            {
                gameObject.Draw(_spriteBatch);
            }
            _spriteBatch.End();

            base.Draw(gameTime);
        }

        internal void instantiate(GameObject gameObjectToinstantiate)
        {
            newGameObjects.Add(gameObjectToinstantiate);
        }

        internal void Destroy(GameObject gameObjectToDestroy)
        {
            Debug.WriteLine("Destroyed gameobject");
            destroyedGameObjects.Add(gameObjectToDestroy);
        }

        private void Cleanup()
        {
            for (int i = 0; i < newGameObjects.Count; i++)
            {
                gameObjects.Add(newGameObjects[i]);
                newGameObjects[i].Awake();
            }
            for (int i = 0; i < newGameObjects.Count; i++)
            {
                newGameObjects[i].Start();
            }
            for (int i = 0; i < destroyedGameObjects.Count; i++)
            {
                gameObjects.Remove(destroyedGameObjects[i]);
            }
            destroyedGameObjects.Clear();
            newGameObjects.Clear();
        }

        private void SpawnEnemies()
        {
            lastSpawn += DeltaTime;
            if (lastSpawn > spawnTime)
            {
                GameObject go = EnemyGameObjectPool.Instance.GetGameObject();
                instantiate(go);
                lastSpawn = 0;
            }
        }
    }
}
