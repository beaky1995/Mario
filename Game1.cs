using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;




using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework.Audio;

namespace Spaghetti
{
    public class Game1 : Game
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        readonly GraphicsDeviceManager graphics; //warning says to take this out...but it breaks the game so...
        SpriteBatch spriteBatch;

        public List<IBackground> BackgroundList;
        public List<IBlock> BlockList;
        public List<IEnemy> EnemyList;
        public List<IProjectile> FireballList;
        public List<IItem> ItemList;
        public List<IPipe> PipeList;
        public List<IPlayer> PlayerList;
        public List<IProjectile> ProjectileList;
        public List<IObjective> ObjectiveList;
        public List<IObstacle> ObstacleList;
        public StartMenu menu;
        public List<PopUpScore> PopUpScoreList;

        public LivesCounter marioLives;
        public List<IBlock> blocksToAdd;
        public GameTimer gameTimer;


        private MasterCollisionDetector AllCollisions;
        private CameraCollisionDetector cameraCollisionDetector;
        private List<IController> ControllerList;

        private Camera camera;
        private CameraController cameraController;
        private HUD headsUpDisplay;
        private bool needsIntroScreen = true;
        private bool gameOver = false;

        private int introTimer = 0;
        private int deathTimer = 0;
        public string path;
        private IController newController;
        public LevelLoader level;
        public LevelLoaderOneOne levelOneOne;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this); //warning says to take this out...but it breaks the game so...
            Content.RootDirectory = "Content";
        }

        protected override void Initialize()
        {
            path = Directory.GetCurrentDirectory().Substring(0, Directory.GetCurrentDirectory().Length - GameUtil.fileLocationOffset);

            graphics.PreferredBackBufferWidth = 360; // To view the whole level, change width to ~350O.
            graphics.PreferredBackBufferHeight = 240;
            graphics.ApplyChanges();

            BackgroundList = new List<IBackground>();
            BlockList = new List<IBlock>();
            EnemyList = new List<IEnemy>();
            FireballList = new List<IProjectile>();
            ItemList = new List<IItem>();
            PipeList = new List<IPipe>();
            PlayerList = new List<IPlayer>();
            ProjectileList = new List<IProjectile>();
            ObjectiveList = new List<IObjective>();
            blocksToAdd = new List<IBlock>();
            ObstacleList = new List<IObstacle>();
            PopUpScoreList = new List<PopUpScore>();

            ControllerList = new List<IController>
            {
                new KeyboardController(this),
                new MouseController(this)
            };
            newController = new KeyBoardControllerStartMenu(this);

            base.Initialize();
        }

        protected override void LoadContent()
        {
            BackgroundSpriteFactory.Instance.LoadAllTextures(Content);
            ItemSpriteFactory.Instance.LoadAllTextures(Content);
            EnemySpriteFactory.Instance.LoadAllTextures(Content);
            BlockSpriteFactory.Instance.LoadAllTextures(Content);
            PipeSpriteFactory.Instance.LoadAllTextures(Content);
            MarioSpriteFactory.Instance.LoadAllTextures(Content);
            FireballSpriteFactory.Instance.LoadAllTextures(Content);
            ObjectiveSpriteFactory.Instance.LoadAllTextures(Content);
            GameSpriteFactory.Instance.LoadAllTextures(Content);
            SoundEffectFactory.Instance.LoadAllSoundEffects(Content);

            spriteBatch = new SpriteBatch(GraphicsDevice);
            level = new LevelLoader(path + GameUtil.StartMenuLevelSubPath);
            level.GenerateLevel();

            BackgroundList = level.GetBackgrounds();
            BlockList = level.GetBlocks();
            EnemyList = level.GetEnemies();
            ItemList = level.GetItems();
            PipeList = level.GetPipes();
            PlayerList = level.GetPlayers();
            ProjectileList = level.GetProjectiles();
            ObjectiveList = level.GetObjectives();
            ObstacleList = level.GetObstacles();
            menu = level.GetMenu();

            camera = new Camera(0, 0, graphics.PreferredBackBufferWidth, graphics.PreferredBackBufferHeight);
            cameraController = new CameraController(camera, PlayerList[0]);


            AllCollisions = new MasterCollisionDetector(this, BlockList, EnemyList, ItemList, PipeList, ObjectiveList, FireballList, ProjectileList, ObstacleList);
            cameraCollisionDetector = new CameraCollisionDetector(this);

            headsUpDisplay = new HUD(Content, this);
            PopUpScoreList = Singleton.Instance.myPopUpScoreObjects;


            marioLives = new LivesCounter();
            gameTimer = new GameTimer(this);

        }

        protected override void UnloadContent()
        {
        }

        protected void RemoveDeletedObjects()
        {

            for (int i = 0; i < ProjectileList.Count; i++)
            {
                if (ProjectileList[i].RemoveCheck())
                {
                    ProjectileList.RemoveAt(i);
                }
            }

            for (int i = 0; i < FireballList.Count; i++)
            {
                if (FireballList[i].RemoveCheck())
                {
                    FireballList.RemoveAt(i);
                }
            }

            for (int i = 0; i < ItemList.Count; i++)
            {
                if (ItemList[i].RemoveCheck())
                {
                    ItemList.RemoveAt(i);
                }
            }
            for (int i = 0; i < EnemyList.Count; i++)
            {
                if (EnemyList[i].RemoveCheck())
                {
                    EnemyList.RemoveAt(i);
                }
            }
            for (int i = 0; i < BlockList.Count; i++)
            {
                if (BlockList[i].RemoveCheck())
                {
                    BlockList.RemoveAt(i);
                }
            }

            for (int i = 0; i < PopUpScoreList.Count; i++)
            {
                if (PopUpScoreList[i].RemoveCheck())
                {
                    PopUpScoreList.RemoveAt(i);
                }
            }
            for(int i = 0; i < ObjectiveList.Count; i++)
            {
                if (ObjectiveList[i].RemoveCheck())
                {
                    ObjectiveList.RemoveAt(i);
                }
            }
            
        }

        protected void AddBlocksToList()
        {
            for (int i = 0; i < blocksToAdd.Count; i++)
            {
                BlockList.Add(blocksToAdd[i]);
            }
            blocksToAdd.Clear();
        }

        protected override void Update(GameTime gameTime)
        {
            if (Singleton.Instance.displayLevel)
            {

                gameTimer.Update();
                cameraController.Update();
                RemoveDeletedObjects();
                AddBlocksToList();
                Singleton.Instance.Update();


                if (PlayerList[0].IsDead())
                {
                    deathTimer++;
                    if (deathTimer == GameUtil.delayResetOnDeath)
                    {
                        marioLives.RemoveLife();
                        Reset();
                        deathTimer = 0;
                    }
                }

                foreach (IController controller in ControllerList)
                {
                    controller.Update();
                }

                if (needsIntroScreen)
                {
                    if (marioLives.GetLives() > 0)
                    {
                        introTimer++;
                        if (introTimer == GameUtil.delayIntro)
                        {
                            needsIntroScreen = false;
                            gameTimer.ToggleTime(true);
                            introTimer = 0;
                            SoundManager.Instance.PlaySoundtrack();
                        }
                    }
                    else
                    {
                        if (!gameOver)
                        {
                            SoundManager.Instance.PlayGameOverMusic();
                            gameOver = true;

                        }
                    }
                }
                else if (!Singleton.Instance.isPause)
                {

                    foreach (IBackground background in BackgroundList)
                    {
                        background.Update();
                    }
                    foreach (IItem item in ItemList)
                    {
                        item.Update();
                    }
                    foreach (IEnemy enemy in EnemyList)
                    {
                        enemy.Update();
                    }

                    foreach (IBlock block in BlockList)
                    {
                        block.Update();
                    }

                    foreach (IObjective objective in ObjectiveList)
                    {
                        if (camera.viewableBox.Intersects(objective.CollisionBox))
                        {
                            objective.Update();
                        }
                    }

                    foreach (IPipe pipe in PipeList)
                    {
                        if (camera.viewableBox.Intersects(pipe.CollisionBox))
                        {
                            pipe.Update();
                        }
                    }

                    foreach (IProjectile projectile in ProjectileList)
                    {
                        projectile.Update();
                    }
                    foreach (IProjectile fireball in FireballList)
                    {
                        fireball.Update();
                    }

                    foreach (IObstacle obstacle in ObstacleList)
                    {
                        obstacle.Update();
                    }

                    foreach(PopUpScore score in PopUpScoreList)
                    {
                        score.Update();
                    }

                    PlayerList[0].Update();

                    AllCollisions.DetectAllCollisions();
                    cameraCollisionDetector.DetectCameraCollisions(camera, PlayerList, EnemyList);

                    base.Update(gameTime);
                }
            }
            else
            {
                menu.Update();
                newController.Update();
            }
        }

        protected override void Draw(GameTime gameTime)
        {
            spriteBatch.Begin();
            if (PlayerList[0].isFinish())
            {
                headsUpDisplay.EndText(spriteBatch, camera);
            }
            if (Singleton.Instance.displayLevel)
            {


                if (needsIntroScreen)
                {
                    GraphicsDevice.Clear(Color.Black);
                    if (Singleton.Instance.isLevel == 1 || Singleton.Instance.isLevel == 0)
                        headsUpDisplay.DisplayLivesOne(spriteBatch, camera, marioLives);
                    else if (Singleton.Instance.isLevel == 2)
                        headsUpDisplay.DisplayLivesTwo(spriteBatch, camera, marioLives);
                }
                else
                {
                    if(Singleton.Instance.isLevel == 2)
                    {
                        GraphicsDevice.Clear(Color.Black);
                    }
                    else
                    {
                        GraphicsDevice.Clear(Color.CornflowerBlue);
                    }

                    foreach (IBackground background in BackgroundList)
                    {
                        background.Draw(spriteBatch, camera);
                    }
                    foreach (IObjective objective in ObjectiveList)
                    {
                        objective.Draw(spriteBatch, camera);
                    }
                    foreach (IPipe pipe in PipeList)
                    {
                        pipe.Draw(spriteBatch, camera);
                    }
                    foreach (IItem item in ItemList)
                    {
                        item.Draw(spriteBatch, camera);
                    }
                    foreach (IBlock block in BlockList)
                    {
                        block.Draw(spriteBatch, camera);
                    }
                    foreach (IEnemy enemy in EnemyList)
                    {
                        enemy.Draw(spriteBatch, camera);
                    }

                    foreach (IObstacle obstacle in ObstacleList)
                    {
                        obstacle.Draw(spriteBatch, camera);
                    }

                    foreach (IPlayer player in PlayerList)
                    {
                        player.Draw(spriteBatch, camera);
                    }
                    foreach (IProjectile projectile in ProjectileList)
                    {
                        projectile.Draw(spriteBatch, camera);
                    }
                    foreach (IProjectile projectile in FireballList)
                    {
                        projectile.Draw(spriteBatch, camera);
                    }

                }
                headsUpDisplay.Draw(spriteBatch, camera);
                base.Draw(gameTime);
                
            }
            else
            {
                menu.Draw(spriteBatch, camera);
            }
            spriteBatch.End();
        }
            public void Reset()
            {

                MediaPlayer.Stop();
                spriteBatch = new SpriteBatch(GraphicsDevice);
                spriteBatch.Begin();

            if (Singleton.Instance.isLevel == 2)
            {
                level = new LevelLoader(path + GameUtil.sprint6LevelSubPath);
                level.ClearLevel();
                level.GenerateLevel();
                BackgroundList = level.GetBackgrounds();
                BlockList = level.GetBlocks();
                EnemyList = level.GetEnemies();
                FireballList = new List<IProjectile>();
                ItemList = level.GetItems();
                PipeList = level.GetPipes();
                ObjectiveList = level.GetObjectives();
                PlayerList = level.GetPlayers();
                ProjectileList = level.GetProjectiles();
                ObstacleList = level.GetObstacles();
            }
            else if (Singleton.Instance.isLevel == 1 || Singleton.Instance.isLevel == 0)
            {
                levelOneOne = new LevelLoaderOneOne(path + GameUtil.levelSubPath);

                camera = new Camera(0, 0, graphics.PreferredBackBufferWidth, graphics.PreferredBackBufferHeight);

                levelOneOne.ClearLevel();
                levelOneOne.GenerateLevel();
                BackgroundList = levelOneOne.GetBackgrounds();
                BlockList = levelOneOne.GetBlocks();
                EnemyList = levelOneOne.GetEnemies();
                FireballList = new List<IProjectile>();
                ItemList = levelOneOne.GetItems();
                PipeList = levelOneOne.GetPipes();
                ObjectiveList = levelOneOne.GetObjectives();
                PlayerList = levelOneOne.GetPlayers();
                //ProjectileList = levelOneOne.GetProjectiles();
                //ObstacleList = levelOneOne.GetObstacles();
            }

                Singleton.Instance.score = 0;
                CoinCounter.Instance.ResetCoinCount();
                gameTimer.ResetTimer();

                cameraController = new CameraController(camera, PlayerList[0]);

                AllCollisions = new MasterCollisionDetector(this, BlockList, EnemyList, ItemList, PipeList, ObjectiveList, FireballList, ProjectileList, ObstacleList);

                needsIntroScreen = true;
                introTimer = 0;
                spriteBatch.End();
            }

            public void RecenterCamera()
            {
                camera.SnapCamera(PlayerList[0].GetPositionRef());
            }


        }
    }

