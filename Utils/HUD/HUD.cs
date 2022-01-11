using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework;

namespace Spaghetti
{
    public class HUD: IDrawable
    {

        private SpriteFont font;

        private Game1 myGame;

        private Vector2 PositionOfMarioText;
        private Vector2 PositionOfTotalScore;

        private Vector2 PositionOfCoinCounter;

        private Vector2 PositionOfWorldText;
        private Vector2 PositionOfLevelSpecifier;

        private Vector2 PositionOfTimeText;
        private Vector2 PositionOfTimeRemaining;

        private Vector2 PositionOfIntroWorldText;
        private Vector2 PositionOfLivesSprite;
        private Vector2 PositionOfLivesText;
        private Vector2 PositionOfLivesRemaining;

        private Vector2 PositionOfGameOverText;

        public HUD(ContentManager content, Game1 game)
        {           
            font = content.Load<SpriteFont>(HUDUtil.SpriteFont);

            PositionOfMarioText = HUDUtil.PositionOfMarioText;
            PositionOfTotalScore = HUDUtil.PositionOfTotalScore;

            PositionOfCoinCounter = HUDUtil.PositionOfCoinCounter;

            PositionOfWorldText = HUDUtil.PositionOfWorldText;
            PositionOfLevelSpecifier = HUDUtil.PositionOfLevelSpecifier;
 
            PositionOfTimeText = HUDUtil.PositionOfTimeText;
            PositionOfTimeRemaining = HUDUtil.PositionOfTimeRemaining;

            PositionOfIntroWorldText = HUDUtil.PositionOfIntroWorldText;
            PositionOfLivesSprite = HUDUtil.PositionOfLivesSprite;
            PositionOfLivesText = HUDUtil.PositionOfLivesText;
            PositionOfLivesRemaining = HUDUtil.PositionOfLivesRemaining;

            PositionOfGameOverText = HUDUtil.PositionOfGameOverText;

            myGame = game;
        }
        

      
        public void Draw(SpriteBatch spriteBatch, Camera camera)
        {
            if (Singleton.Instance.isLevel == 1 )
            {
                DisplayWorldOne(spriteBatch, camera);
                
            }
            else if(Singleton.Instance.isLevel == 2)
            {
                DisplayWorldTwo(spriteBatch, camera);
            }
            DisplayTotalPoints(spriteBatch, camera);
            DisplayCoinCounter(spriteBatch, camera);
            DisplayTimeRemaining(spriteBatch, camera);
            DisplayPopUpScore(spriteBatch, camera);
        }

        public void DisplayPopUpScore(SpriteBatch spriteBatch, Camera camera)
        {
            List<PopUpScore> popUpScoreList= Singleton.Instance.myPopUpScoreObjects;
            foreach(PopUpScore score in popUpScoreList)
            {
                int scoreValue = score.GetScore();
                Vector2 pos = score.GetPositionRef();
                spriteBatch.DrawString(font, scoreValue.ToString(), camera.AdjustPosition(pos), Color.White);
            }
            
        }

        public Vector2 CalculatePosition(Vector2 input, Camera camera)
        {
            return new Vector2(input.X + camera.viewableBox.X, input.Y + camera.viewableBox.Y);
        }

        public void DisplayTotalPoints(SpriteBatch spriteBatch, Camera camera)
        {
            spriteBatch.DrawString(font, HUDUtil.MarioText, camera.AdjustPosition(CalculatePosition(PositionOfMarioText, camera)) , Color.White);
            spriteBatch.DrawString(font, Singleton.Instance.score.ToString(), camera.AdjustPosition(CalculatePosition(PositionOfTotalScore, camera)), Color.White);
        }

        public void DisplayCoinCounter(SpriteBatch spriteBatch, Camera camera)
        {
            spriteBatch.DrawString(font, HUDUtil.TimesText+ CoinCounter.Instance.GetCoinCount(), camera.AdjustPosition(CalculatePosition(PositionOfCoinCounter, camera)), Color.White);
        }

        public void DisplayWorldOne(SpriteBatch spriteBatch, Camera camera)
        {
            spriteBatch.DrawString(font, HUDUtil.WorldText, camera.AdjustPosition(CalculatePosition(PositionOfWorldText, camera)), Color.White);
            spriteBatch.DrawString(font, HUDUtil.LevelTextOne, camera.AdjustPosition(CalculatePosition(PositionOfLevelSpecifier, camera)), Color.White);
        }
        public void DisplayWorldTwo(SpriteBatch spriteBatch, Camera camera)
        {
            spriteBatch.DrawString(font, HUDUtil.WorldText, camera.AdjustPosition(CalculatePosition(PositionOfWorldText, camera)), Color.White);
            spriteBatch.DrawString(font, HUDUtil.LevelTextTwo, camera.AdjustPosition(CalculatePosition(PositionOfLevelSpecifier, camera)), Color.White);
        }

        public void DisplayTimeRemaining(SpriteBatch spriteBatch, Camera camera)
        {
            spriteBatch.DrawString(font, HUDUtil.TimeText, camera.AdjustPosition(CalculatePosition(PositionOfTimeText, camera)), Color.White);
            spriteBatch.DrawString(font, myGame.gameTimer.CurrentTime().ToString(), camera.AdjustPosition(CalculatePosition(PositionOfTimeRemaining, camera)), Color.White);
        }

        public void DisplayLivesOne(SpriteBatch spriteBatch, Camera camera, LivesCounter lives)
        {
            if (lives.GetLives() > 0)
            {
                spriteBatch.DrawString(font, HUDUtil.InitialDisplayOne, camera.AdjustPosition(CalculatePosition(PositionOfIntroWorldText, camera)), Color.White);

                ISprite MarioSprite = MarioSpriteFactory.Instance.CreateMarioRightSmallIdleSprite();
                MarioSprite.Draw(spriteBatch, PositionOfLivesSprite);
                spriteBatch.DrawString(font, HUDUtil.TimesText, camera.AdjustPosition(CalculatePosition(PositionOfLivesText, camera)), Color.White);
                spriteBatch.DrawString(font, lives.GetLives().ToString(), camera.AdjustPosition(CalculatePosition(PositionOfLivesRemaining, camera)), Color.White);
            } else
            {
                spriteBatch.DrawString(font, HUDUtil.GOText, camera.AdjustPosition(CalculatePosition(PositionOfGameOverText, camera)), Color.White);
            }
        }
        public void EndText(SpriteBatch spriteBatch, Camera camera)
        {
            spriteBatch.DrawString(font, HUDUtil.FinalText, camera.AdjustPosition(CalculatePosition(HUDUtil.PositionOfEndText1, camera)), Color.White);
            spriteBatch.DrawString(font, HUDUtil.FinalText2, camera.AdjustPosition(CalculatePosition(HUDUtil.PositionOfEndText2, camera)), Color.White);
            spriteBatch.DrawString(font, HUDUtil.FinalText3, camera.AdjustPosition(CalculatePosition(HUDUtil.PositionOfEndText3, camera)), Color.White);
        }
        public void DisplayLivesTwo(SpriteBatch spriteBatch, Camera camera, LivesCounter lives)
        {
            if (lives.GetLives() > 0)
            {
                spriteBatch.DrawString(font, HUDUtil.InitialDisplayTwo, camera.AdjustPosition(CalculatePosition(PositionOfIntroWorldText, camera)), Color.White);

                ISprite MarioSprite = MarioSpriteFactory.Instance.CreateMarioRightSmallIdleSprite();
                MarioSprite.Draw(spriteBatch, PositionOfLivesSprite);
                spriteBatch.DrawString(font, HUDUtil.TimesText, camera.AdjustPosition(CalculatePosition(PositionOfLivesText, camera)), Color.White);
                spriteBatch.DrawString(font, lives.GetLives().ToString(), camera.AdjustPosition(CalculatePosition(PositionOfLivesRemaining, camera)), Color.White);
            }
            else
            {
                spriteBatch.DrawString(font, HUDUtil.GOText, camera.AdjustPosition(CalculatePosition(PositionOfGameOverText, camera)), Color.White);
            }
        }
    }
}
