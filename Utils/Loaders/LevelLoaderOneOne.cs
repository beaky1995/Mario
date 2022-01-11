using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Xml;

namespace Spaghetti
{
    public class LevelLoaderOneOne
    {
        private List<IBackground> backgrounds;
        private List<IBlock> blocks;
        private List<IEnemy> enemies;
        private List<IItem> items;
        private List<IPipe> pipes;
        private List<IObjective> objectives;
        private List<IPlayer> players;
        private List<int> holes;
        private XmlDocument levelXml;
        private int scale;
        private int levelLength;
        private int coinOffset, parsingOffset;
        private int bottomFloorBlockLocation, topFloorBlockLocation;

        public LevelLoaderOneOne(string levelFileName)
        {
            backgrounds = new List<IBackground>();
            blocks = new List<IBlock>();
            enemies = new List<IEnemy>();
            items = new List<IItem>();
            pipes = new List<IPipe>();
            objectives = new List<IObjective>();
            players = new List<IPlayer>();
            holes = new List<int>();
            levelXml = new XmlDocument();
            levelXml.Load(levelFileName);
            scale = 16; // pixels per block
            levelLength = 300; // "blocks" per level
            coinOffset = 5;
            parsingOffset = 1;
            bottomFloorBlockLocation = 14;
            topFloorBlockLocation = 13;
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
            GenerateFloor();
        }

        public void GenerateFloor()
        {
            for (int i = 0; i < levelLength; i++) {
                if (!holes.Contains(i))
                {
                    blocks.Add(new FloorBlock(scale * i, scale * topFloorBlockLocation));
                    blocks.Add(new FloorBlock(scale * i, scale * bottomFloorBlockLocation));
                }
            }
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
                case "Hole":
                    RecordHole(gameObjectNode);
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

        public void GenerateObjective(XmlNode objectiveNode)
        {
            int[] location = GetLocation(objectiveNode);
            switch (GetGameObjectName(objectiveNode))
            {
                case "Flagpole":
                    //objectives.Add(new Pole(location[0], location[1]));
                    //objectives.Add(new Flag(location[0] - 13, location[1] + 8));
                    objectives.Add(new Flagpole(location[0], location[1]));
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

        public void ClearLevel()
        {
            backgrounds = new List<IBackground>();
            blocks = new List<IBlock>();
            enemies = new List<IEnemy>();
            items = new List<IItem>();
            pipes = new List<IPipe>();
            objectives = new List<IObjective>();
            players = new List<IPlayer>();
        }
    }
}
