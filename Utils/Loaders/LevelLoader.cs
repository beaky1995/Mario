using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Xml;
using Microsoft.Xna.Framework;

namespace Spaghetti
{
    public class LevelLoader
    {
        private List<IBackground> backgrounds;
        private List<IBlock> blocks;
        private List<IEnemy> enemies;
        private List<IItem> items;
        private List<IPipe> pipes;
        private List<IObjective> objectives;
        private List<IPlayer> players;
        private List<IProjectile> projectiles;
        private List<IObstacle> obstacles;
        private StartMenu menu;
        private List<int> holes;
        private XmlDocument levelXml;
        private int scale;
        private int levelLength;
        private int coinOffset, parsingOffset;
        private int bottomFloorBlockLocation, topFloorBlockLocation;

        private List<int> ceilingHoles;

        public LevelLoader(string levelFileName)
        {
            backgrounds = new List<IBackground>();
            blocks = new List<IBlock>();
            enemies = new List<IEnemy>();
            items = new List<IItem>();
            pipes = new List<IPipe>();
            objectives = new List<IObjective>();
            players = new List<IPlayer>();
            projectiles = new List<IProjectile>();
            holes = new List<int>();
            ceilingHoles = new List<int>();
            obstacles = new List<IObstacle>();

            
            levelXml = new XmlDocument();
            levelXml.Load(levelFileName);
            scale = 16; // pixels per block
            levelLength = 300; // "blocks" per level
            coinOffset = 5;
            parsingOffset = 1;

            //14 meaning 14 blocks down from the top.
            bottomFloorBlockLocation = 14;
            topFloorBlockLocation = 13;


            //Ceiling
            //topCeilingBlockLocation = 0;
            //bottomCeilingBlockLocation = 1;

        }

        public void ChangeLevel(string levelFileName)
        {
            levelXml.Load(levelFileName);
        }
         
        public void GenerateLevel()
        {
            foreach (XmlNode gameObjectNode in levelXml.DocumentElement.FirstChild)
            {
                GenerateGameObjectNode(gameObjectNode);
            }

            GenerateLevelDesign();
        }

        public void GenerateCeiling()
        {
            for (int i = 0; i < levelLength; i++)
            {
                if (!ceilingHoles.Contains(i))
                {
                    blocks.Add(new StoneFloorBlock(scale * i, scale * 3));
                    blocks.Add(new StoneFloorBlock(scale * i, scale * 4));
                    blocks.Add(new StoneFloorBlock(scale * i, scale * 5));
                }
            }


            for(int i = 23; i < 36; i++)
            {
                blocks.Add(new StoneFloorBlock(scale * i, scale * 3));
            }

            for(int i = 36; i < 68; i++)
            {
                blocks.Add(new StoneFloorBlock(scale * i, scale * 6));
            }

            for(int i = 68; i < 95; i++)
            {
                blocks.Add(new StoneFloorBlock(scale * i, scale * 3));
            }

            for(int i = 101; i < 120; i++)
            {
                blocks.Add(new StoneFloorBlock(scale * i, scale * 3));
            }

            for(int i = 125; i < 139; i++)
            {
                blocks.Add(new StoneFloorBlock(scale * i, scale * 3));
            }

            for(int i = 139; i < 141; i++)
            {
                blocks.Add(new FloorBlock(scale * i, scale * 6));
            }

            for(int i = 141; i < 151; i++)
            {
                blocks.Add(new FloorBlock(scale * i, scale * 3));
            }
        }

        public void RemoveBlocks()
        {
            //blocks.Remove();
        }

        public void GenerateLevelDesign()
        {
            GenerateCeiling();
            GenerateFloor();
        }

     
        //public void GenerateFloor()
        //{

        //    for (int i = 0; i < levelLength; i++) {
        //        if (!holes.Contains(i))
        //        {
        //            blocks.Add(new FloorBlock(scale * i, scale * topFloorBlockLocation));
        //            blocks.Add(new FloorBlock(scale * i, scale * bottomFloorBlockLocation));
        //        }
        //    }
        //}
        public void GenerateFloor()
        {

            for (int i = 0; i < levelLength; i++)
            {
                if (!holes.Contains(i))
                {
                    blocks.Add(new StoneFloorBlock(scale * i, scale * 11));
                    blocks.Add(new StoneFloorBlock(scale * i, scale * 12));
                    blocks.Add(new StoneFloorBlock(scale * i, scale * topFloorBlockLocation));
                    blocks.Add(new StoneFloorBlock(scale * i, scale * bottomFloorBlockLocation));                    
                }
            }

            GenerateRaisedFloor();
            GenerateStairs();
            FillInFloorAfterHoles();

        }

        public void GenerateStairs()
        {
            for( int i = 0; i < 3; i++)
            {
                blocks.Add(new StoneFloorBlock(scale * i, scale * 8));
            }

            for (int i = 0; i < 4; i++)
            {
                blocks.Add(new StoneFloorBlock(scale * i, scale * 9));

            }

            for (int i = 0; i < 5; i++)
            {
                blocks.Add(new StoneFloorBlock(scale * i, scale * 10));
            }
        }

        public void GenerateRaisedFloor()
        {
            for( int i = 34; i < (34+34); i++)
            {
                blocks.Add(new StoneFloorBlock(scale * i, scale * 10));
            }

            for (int i = 138; i < 138 + 3; i++)
            {
                blocks.Add(new StoneFloorBlock(scale * i, scale * 10));
            }
        }

        public void FillInFloorAfterHoles()
        {
            for (int i = 101; i < 113 ; i++)
            {
                blocks.Add(new StoneFloorBlock(scale * i, scale * 14));
                blocks.Add(new StoneFloorBlock(scale * i, scale * 13));
            }

            for (int i = 117 ; i < 117+3 ; i++)
            {
                blocks.Add(new StoneFloorBlock(scale * i, scale * 14));
                blocks.Add(new StoneFloorBlock(scale * i, scale * 13));
            }
          
        }
        public void GenerateFireLink()
        {
        //    for(int i = 0; i < chainLength; i++)
        //    {

        //    }


        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1059:MembersShouldNotExposeCertainConcreteTypes", MessageId = "System.Xml.XmlNode")]
        public void GenerateGameObjectNode(XmlNode gameObjectNode)
        {
            switch (GetGameObjectType(gameObjectNode))
            {
                case "Background":
                    GenerateBackground(gameObjectNode);
                    break;
                case "Block":
                    GenerateBlock(gameObjectNode);
                    break;
                case "Enemy":
                    GenerateEnemy(gameObjectNode);
                    break;
                case "Item":
                    GenerateItem(gameObjectNode);
                    break;
                case "Pipe":
                    GeneratePipe(gameObjectNode);
                    break;
                case "Objective":
                    GenerateObjective(gameObjectNode);
                    break;
                case "Player":
                    GeneratePlayer(gameObjectNode);
                    break;
                case "Projectile":
                    GenerateProjectile(gameObjectNode);
                    break;
                case "Hole":
                    RecordHole(gameObjectNode);
                    break;
                case "CeilingHole":
                    RecordCeilingHole(gameObjectNode);
                    break;
                case "Obstacle":
                    GenerateObstacle(gameObjectNode);
                    break;
                case "Menu":
                    GenerateMenu(gameObjectNode);
                    break;

            }
        }



        public string GetGameObjectType(XmlNode gameObjectNode)
        {
            return gameObjectNode.FirstChild.InnerText;
        }

        public string GetGameObjectName(XmlNode gameObjectNode)
        {
            return gameObjectNode.ChildNodes[1].InnerText;
        }

        public string GetContainItemName(XmlNode gameObjectNode)
        {         
            return gameObjectNode.ChildNodes[2].InnerText;
        }

        public string GetDirection(XmlNode gameObjectNode)
        {
            return gameObjectNode.ChildNodes[2].InnerText;
        }

        public int[] GetLocation(XmlNode gameObjectNode)
        {
            string locationText = gameObjectNode.LastChild.InnerText;
            int locationX = Int32.Parse(locationText.Substring(0, locationText.IndexOf(' ')));
            int locationY = Int32.Parse(locationText.Substring(locationText.IndexOf(' ') + parsingOffset));
            return new int[]{scale*locationX, scale*locationY};
        }

        public int[] GetWarpLocation(XmlNode gameObjectNode)
        {
            string locationText = gameObjectNode.ChildNodes[2].InnerText;
            int locationX = Int32.Parse(locationText.Substring(0, locationText.IndexOf(' ')));
            int locationY = Int32.Parse(locationText.Substring(locationText.IndexOf(' ') + parsingOffset));
            return new int[] { scale * locationX, scale * locationY };
        }

     
        public void GenerateObstacle(XmlNode obstacleNode)
        {
            string direction = GetDirection(obstacleNode);
            int[] location = GetLocation(obstacleNode);
            Vector2 origin = new Vector2(location[0] + 4, location[1] + 4);
            switch(GetGameObjectName(obstacleNode))
            {
                case "Firebar":
                    obstacles.Add(new Firebar(origin, 6, 0, direction));
                    break;
            }


        }


        public void GenerateBackground(XmlNode backgroundNode)
        {
            int[] location = GetLocation(backgroundNode);
            switch (GetGameObjectName(backgroundNode))
            {
                case "BigMountain":
                    backgrounds.Add(new BigMountain(location[0], location[1]));
                    break;
                case "SingleBush":
                    backgrounds.Add(new SingleBush(location[0], location[1]));
                    break;
                case "SingleCloud":
                    backgrounds.Add(new SingleCloud(location[0], location[1]));
                    break;
                case "SmallMountain":
                    backgrounds.Add(new SmallMountain(location[0], location[1]));
                    break;
                case "TripleBush":
                    backgrounds.Add(new TripleBush(location[0], location[1]));
                    break;
                case "TripleCloud":
                    backgrounds.Add(new TripleCloud(location[0], location[1]));
                    break;
                case "Castle":
                    backgrounds.Add(new Castle(location[0], location[1]));
                    break;
                case "Toad":
                    backgrounds.Add(new Toad(location[0], location[1]));
                    break;
            }
        }

        public void GenerateBlock(XmlNode blockNode)
        {
            int[] location = GetLocation(blockNode);
            switch (GetGameObjectName(blockNode))
            {
                case "BrickBlock":
                    blocks.Add(new BrickBlock(location[0], location[1]));
                    break;
                case "FalseBrickBlock":
                    IBlock b = new FalseBrickBlock(location[0], location[1]);
                    blocks.Add(b);
                    GenerateItemInsideBlock(blockNode, b);
                    break;
                case "FloorBlock":
                    blocks.Add(new FloorBlock(location[0], location[1]));
                    break;
                case "HiddenBlock":
                    IBlock c = new HiddenBlock(location[0], location[1]);
                    blocks.Add(c);
                    GenerateItemInsideBlock(blockNode, c);
                    break;
                case "QuestionBlock":
                    IBlock a = new QuestionBlock(location[0], location[1]);
                    blocks.Add(a);
                    GenerateItemInsideBlock(blockNode, a);
                    break;
                case "UnbreakableBlock":
                    blocks.Add(new UnbreakableBlock(location[0], location[1]));
                    break;
                case "StoneFloorBlock":
                    blocks.Add(new StoneFloorBlock(location[0], location[1]));
                    break;
                case "LavaBlock":
                    blocks.Add(new LavaBlock(location[0], location[1]));
                    break;
                case "LavaTopBlock":
                    blocks.Add(new LavaTopBlock(location[0], location[1]));
                    break;
                case "MovingPlatform":
                    blocks.Add(new MovingPlatform(location[0], location[1]));
                    break;
                case "DrawbridgeBlock":
                    blocks.Add(new DrawbridgeBlock(location[0], location[1]));
                    break;
                case "DrawbridgeChainBlock":
                    blocks.Add(new DrawbridgeChainBlock(location[0], location[1]));
                    break;
            }
        }

        public void GenerateEnemy(XmlNode enemyNode)
        {
            int[] location = GetLocation(enemyNode);
            switch (GetGameObjectName(enemyNode))
            {
                case "Goomba":
                    enemies.Add(new Goomba(location[0], location[1]));
                    break;
                case "Koopa":
                    enemies.Add(new Koopa(location[0], location[1]));
                    break;
                case "Bowser":
                    enemies.Add(new Bowser(location[0], location[1]));
                    break;
            }
        }

        public void GenerateItem(XmlNode itemNode)
        {
            int[] location = GetLocation(itemNode);
            switch (GetGameObjectName(itemNode))
            {
                case "Coin":
                    items.Add(new Coin(location[0], location[1]));
                    break;
                case "FireFlower":
                    items.Add(new FireFlower(location[0], location[1]));
                    break;
                case "GreenMushroom":
                    items.Add(new GreenMushroom(location[0], location[1]));
                    break;
                case "RedMushroom":
                    items.Add(new RedMushroom(location[0], location[1]));
                    break;
                case "Star":
                    items.Add(new Star(location[0], location[1]));
                    break;
            }
        }

        public void GeneratePipe(XmlNode pipeNode)
        {
            int[] location = GetLocation(pipeNode);
            int[] warpLocation = GetWarpLocation(pipeNode);
            switch (GetGameObjectName(pipeNode))
            {
                case "Pipe":
                    pipes.Add(new Pipe(location[0], location[1]));
                    break;
                case "WarpPipe":
                    pipes.Add(new WarpPipe(location[0], location[1], warpLocation[0], warpLocation[1]));
                    break;
            }
        }
        public void GenerateMenu(XmlNode menuNode)
        {
            int[] location = GetLocation(menuNode);
            menu = new StartMenu(location[0], location[1]);
        }

        public void GenerateObjective(XmlNode objectiveNode)
        {
            int[] location = GetLocation(objectiveNode);
            switch (GetGameObjectName(objectiveNode))
            {
                case "Flagpole":
                    objectives.Add(new Flagpole(location[0], location[1]));
                    break;
                case "Axe":
                    objectives.Add(new Axe(location[0], location[1]));
                    break;
            }
        }

        public void GeneratePlayer(XmlNode playerNode)
        {
            int[] location = GetLocation(playerNode);
            switch (GetGameObjectName(playerNode))
            {
                case "Mario":
                    players.Add(new Mario(location[0], location[1]));
                    break;
            }
        }
        public void GenerateProjectile(XmlNode projectileNode)
        {
            int[] location = GetLocation(projectileNode);
            switch (GetGameObjectName(projectileNode))
            {
                case "FireSpear":
                    projectiles.Add(new FireSpear(location[0], location[1]));
                    break;
            }
        }
        public void GenerateItemInsideBlock(XmlNode itemNode, IBlock block)
        {
            
            int[] location = GetLocation(itemNode);
            switch (GetContainItemName(itemNode) )
            {
                
                case "red":
                    IItem a = new RedMushroom(location[0], location[1]);
                    items.Add(a);
                    block.SetItem(a);
                    IItem c = new FireFlower(location[0], location[1]);
                    items.Add(c);
                    block.SetItem(c);
                    break;
                case "green":
                    IItem b = new GreenMushroom(location[0], location[1]);
                    items.Add(b);
                    block.SetItem(b);
                    break;
                case "star":
                    IItem d = new Star(location[0], location[1]);
                    items.Add(d);
                    block.SetItem(d);
                    break;
                case "coin":
                    IItem e = new Coin(location[0], location[1] - coinOffset);
                    items.Add(e);
                    block.SetItem(e);
                    break;
            }
        }

        public void RecordHole(XmlNode holeNode)
        {
            int[] location = GetLocation(holeNode);
            if (!holes.Contains(location[0])) {
                holes.Add(location[0] / scale);
            }
        }

        public void RecordCeilingHole(XmlNode ceilingHoleNode)
        {
            int[] location = GetLocation(ceilingHoleNode);
            if (!ceilingHoles.Contains(location[0]))
            {
                ceilingHoles.Add(location[0] / scale);
            }
        }
        public StartMenu GetMenu()
        {
            return menu;
        }
        public List<IBackground> GetBackgrounds()
        {
            return backgrounds;
        }

        public List<IBlock> GetBlocks()
        {
            return blocks;
        }

        public List<IEnemy> GetEnemies()
        {
            return enemies;
        }

        public List<IItem> GetItems()
        {
            return items;
        }

        public List<IPipe> GetPipes()
        {
            return pipes;
        }

        public List<IObjective> GetObjectives()
        {
            return objectives;
        }
        public List<IPlayer> GetPlayers()
        {
            return players;
        }
        public List<IProjectile> GetProjectiles()
        {
            return projectiles;
        }

        public List<IObstacle> GetObstacles()
        {
            return obstacles;
        }

        public void ClearLevel()
        {
            backgrounds = new List<IBackground>();
            blocks = new List<IBlock>();
            enemies = new List<IEnemy>();
            items = new List<IItem>();
            pipes = new List<IPipe>();
            objectives = new List<IObjective>();
            players = new List<IPlayer>();
            projectiles = new List<IProjectile>();
            obstacles = new List<IObstacle>();
        }
    }
}
