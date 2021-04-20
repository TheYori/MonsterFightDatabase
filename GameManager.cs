﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonsterFightDatabase.Class;
using System.Collections.Generic;

namespace MonsterFightDatabase
{
    public class GameManager : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch spriteBatch;

        private static GameManager instance;

        public static GameManager Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new GameManager();
                }

                return instance;
            }
        }

        private List<GameObject> gameObjects = new List<GameObject>();
        private Monster monster;

        public GameManager()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            GameObject go = new GameObject();

            monster = new Monster();
            go.AddComponent(new SpriteRenderer());
            go.AddComponent(monster);
            
            gameObjects.Add(go);

            foreach (GameObject gameObject in gameObjects)
            {
                gameObject.Awake();
            }

            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            foreach (GameObject gameObject in gameObjects)
            {
                gameObject.Start();
            }
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            foreach (GameObject gameObject in gameObjects)
            {
                gameObject.Update(gameTime);
            }
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            spriteBatch.Begin();
            foreach (GameObject gameObject in gameObjects)
            {
                gameObject.Draw(spriteBatch);
            }
            spriteBatch.End();


            base.Draw(gameTime);
        }
    }
}
