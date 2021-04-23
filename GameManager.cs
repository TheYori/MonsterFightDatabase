using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using MonsterFightDatabase.Class;
using MonsterFightDatabase.Managers;
using System;
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

        //private Song pumpedUpMusic; 
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

        public List<GameObject> gameObjects = new List<GameObject>();
        private Monster monster;
        private SpriteRenderer renderer;

        public Manager currentWindow;

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

            currentWindow = laboratoryManager;

            GameObject go = new GameObject();

           monster = new Monster();
            renderer = new SpriteRenderer();
            renderer.SetSprite("TestPicture");

            go.AddComponent(renderer);
            go.AddComponent(monster);

            gameObjects.Add(go);

            GameObject UiFrame = new GameObject();
            UiFrame.Transform.Position = new Vector2(0, 0);
            renderer = new SpriteRenderer();
            renderer.SetSprite("Ui/UiFrame");
            UiFrame.AddComponent(renderer);
            gameObjects.Add(UiFrame);

            buttonSetup();

            fightManager.Awake();
            inventoryManager.Awake();
            laboratoryManager.Awake();
            leagueManager.Awake();
            shopManager.Awake();
            teamManager.Awake();

            GameObject CustomMouse = new GameObject();
            CustomMouse mouse = new CustomMouse();
            CustomMouse.AddComponent(mouse);
            gameObjects.Add(CustomMouse);

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
            fightManager.Start();
            inventoryManager.Start();
            laboratoryManager.Start();
            leagueManager.Start();
            shopManager.Start();
            teamManager.Start();
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
            currentWindow.Update(gameTime);
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
            currentWindow.Draw(spriteBatch);
            spriteBatch.End();


            base.Draw(gameTime);
        }

        public void buttonSetup()
        {
            GameObject invButton = new GameObject();
            invButton.Transform.Position = new Vector2(58, 32);
            SpriteRenderer renderer = new SpriteRenderer();
            renderer.SetSprite("Ui/UiButtons/InventoryButton");
            invButton.AddComponent(renderer);
            invButton.AddComponent(new Button(new Action(delegate () { this.currentWindow = inventoryManager; })));
            gameObjects.Add(invButton);

            GameObject labButton = new GameObject();
            labButton.Transform.Position = new Vector2(340, 32);
            renderer = new SpriteRenderer();
            renderer.SetSprite("Ui/UiButtons/CreateButton");
            labButton.AddComponent(renderer);
            labButton.AddComponent(new Button(new Action(delegate () { this.currentWindow = laboratoryManager; })));
            gameObjects.Add(labButton);

            GameObject shopButton = new GameObject();
            shopButton.Transform.Position = new Vector2(620, 32);
            renderer = new SpriteRenderer();
            renderer.SetSprite("Ui/UiButtons/ShopButton");
            shopButton.AddComponent(renderer);
            shopButton.AddComponent(new Button(new Action(delegate () { this.currentWindow = shopManager; })));
            gameObjects.Add(shopButton);

            GameObject leagueButton = new GameObject();
            leagueButton.Transform.Position = new Vector2(900, 32);
            renderer = new SpriteRenderer();
            renderer.SetSprite("Ui/UiButtons/LeagueButton");
            leagueButton.AddComponent(renderer);
            leagueButton.AddComponent(new Button(new Action(delegate () { this.currentWindow = leagueManager; })));
            gameObjects.Add(leagueButton);

            GameObject teamButton = new GameObject();
            teamButton.Transform.Position = new Vector2(1180, 32);
            renderer = new SpriteRenderer();
            renderer.SetSprite("Ui/UiButtons/TeamButton");
            teamButton.AddComponent(renderer);
            teamButton.AddComponent(new Button(new Action(delegate () { this.currentWindow = teamManager; })));
            gameObjects.Add(teamButton);

            GameObject fightButton = new GameObject();
            fightButton.Transform.Position = new Vector2(1468, 800);
            renderer = new SpriteRenderer();
            renderer.SetSprite("Ui/UiButtons/FightButton");
            fightButton.AddComponent(renderer);
            fightButton.AddComponent(new Button(new Action(delegate () { this.currentWindow = fightManager; })));
            gameObjects.Add(fightButton);
        }
    }
}
