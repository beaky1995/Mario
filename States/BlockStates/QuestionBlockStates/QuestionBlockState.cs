using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Spaghetti
{
    public class QuestionBlockState: IBlockState
    {
        
        private QuestionBlock questionBlock;
        private ISprite questionBlockSprite;
        private bool toDestroy;
        public QuestionBlockState(QuestionBlock block)
        {
            questionBlock = block;
            questionBlockSprite = BlockSpriteFactory.Instance.CreateQuestionBlockSprite();
            toDestroy = false;
        }

        public void React()
        {
            questionBlock.State = new UsedQuestionBlockState(questionBlock);
        }

        public void Update()
        {
            questionBlockSprite.Update();
        }

        public void Draw(SpriteBatch spriteBatch, Camera camera)
        {
            questionBlockSprite.Draw(spriteBatch, camera.AdjustPosition(questionBlock.position));
        }

        public int GetWidth()
        {
            return questionBlockSprite.GetWidth();
        }

        public int GetHeight()
        {
            return questionBlockSprite.GetHeight();
        }

        public bool RemoveCheck()
        {
            return toDestroy;
        }

    }
}
