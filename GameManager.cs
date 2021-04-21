using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using MonsterFightDatabase.Class;
using MonsterFightDatabase.Managers;
using System.Collections.Generic;
using System.Data.SQLite;

namespace MonsterFightDatabase
{
    public enum CurrentWindow { Fight, Inventory, Laboratory, League, Shop, Team}
    public class GameManager : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch spriteBatch;
        private static GameManager instance;

        private Song pumpedUpMusic;
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
        private SpriteRenderer renderer;

        private CurrentWindow currentWindow = CurrentWindow.Laboratory;

        private FightManager fightManager;
        private InventoryManager inventoryManager;
        private LaboratoryManager laboratoryManager;
        private LeagueManager leagueManager;
        private ShopManager shopManager;
        private TeamManager teamManager;


        public GameManager()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            _graphics.PreferredBackBufferWidth = 1920;
            _graphics.PreferredBackBufferHeight = 1080;
            _graphics.ApplyChanges();

            fightManager = new FightManager();
            inventoryManager = new InventoryManager();
            laboratoryManager = new LaboratoryManager();
            leagueManager = new LeagueManager();
            shopManager = new ShopManager();
            teamManager = new TeamManager();

            GameObject go = new GameObject();

            monster = new Monster();
            renderer = new SpriteRenderer();
            renderer.SetSprite("TestPicture");

            go.AddComponent(renderer);
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

            //pumpedUpMusic = Content.Load<Song>("ElectroMusic");
            //MediaPlayer.Play(pumpedUpMusic);
            //MediaPlayer.IsRepeating = true;
            //MediaPlayer.Volume = 0.01f;
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
            switch (currentWindow)
            {
                case CurrentWindow.Fight:
                    {
                        fightManager.Update(gameTime);
                        break;
                    }
                case CurrentWindow.Inventory:
                    {
                        inventoryManager.Update(gameTime);
                        break;
                    }
                case CurrentWindow.Laboratory:
                    {
                        laboratoryManager.Update(gameTime);
                        break;
                    }
                case CurrentWindow.League:
                    {
                        leagueManager.Update(gameTime);
                        break;
                    }
                case CurrentWindow.Shop:
                    {
                        shopManager.Update(gameTime);
                        break;
                    }
                case CurrentWindow.Team:
                    {
                        teamManager.Update(gameTime);
                        break;
                    }
                default: break;
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
            switch (currentWindow)
            {
                case CurrentWindow.Fight:
                    {
                        fightManager.Draw(spriteBatch);
                        break;
                    }
                case CurrentWindow.Inventory:
                    {
                        inventoryManager.Draw(spriteBatch);
                        break;
                    }
                case CurrentWindow.Laboratory:
                    {
                        laboratoryManager.Draw(spriteBatch);
                        break;
                    }
                case CurrentWindow.League:
                    {
                        leagueManager.Draw(spriteBatch);
                        break;
                    }
                case CurrentWindow.Shop:
                    {
                        shopManager.Draw(spriteBatch);
                        break;
                    }
                case CurrentWindow.Team:
                    {
                        teamManager.Draw(spriteBatch);
                        break;
                    }
                default: break;
            }
            spriteBatch.End();


            base.Draw(gameTime);
        }
    }
}
