using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Spaghetti
{
    public class UsedQuestionBlockState: IBlockState
    {

        private QuestionBlock usedQuestionBlock;
        private ISprite usedQuestionBlockSprite;
        private bool toDestroy;

        public UsedQuestionBlockState(QuestionBlock block)
        {
            usedQuestionBlock = block;
            usedQuestionBlockSprite = BlockSpriteFactory.Instance.CreateUsedBlockSprite();
            toDestroy = false;
        }

       public void React()
        {

        }

        public void Update()
        {
            usedQuestionBlockSprite.Update();
        }

        public void Draw(SpriteBatch spriteBatch, Camera camera)
        {
            usedQuestionBlockSprite.Draw(spriteBatch, camera.AdjustPosition(usedQuestionBlock.position));
        }

        public int GetWidth()
        {
            return usedQuestionBlockSprite.GetWidth();
        }

        public int GetHeight()
        {
            return usedQuestionBlockSprite.GetHeight();
        }

        public bool RemoveCheck()
        {
            return toDestroy;
        }
    }
}
