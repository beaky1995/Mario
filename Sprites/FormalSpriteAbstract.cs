using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Spaghetti
{
    public class FormalSpriteAbstract : ISprite
    {
        private Texture2D spriteTexture;
        private int currentFrame;
        private int currentUpdate;
        private int totalFrames;
        private int updatesPerFrame;
        private int row;
        private int column;

        public FormalSpriteAbstract(Texture2D texture, int rows, int cols)
        {
            spriteTexture = texture;
            currentUpdate = 0;
            currentFrame = 0;
            totalFrames = rows * cols;
            updatesPerFrame = 10;
            row = rows;
            column = cols;
        }

        public void Update()
        {
            currentUpdate++;
            if (currentUpdate == updatesPerFrame)
            {
                currentUpdate = 0;
                currentFrame++;
                if (currentFrame == totalFrames)
                {
                    currentFrame = 0;
                }
                
            }
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 position)
        {
            int width = spriteTexture.Width / column;
            int height = spriteTexture.Height / row;
            int rows = (int)((float)currentFrame / (float)column);
            int columns = currentFrame % column;
            Rectangle sourceRectangle = new Rectangle(width * columns, height * rows, width, height);
            Rectangle destinationRectangle = new Rectangle((int)position.X, (int)position.Y, width, height);
            spriteBatch.Draw(spriteTexture, destinationRectangle, sourceRectangle, Color.White);
        }

        public void StarDraw(SpriteBatch spriteBatch, Vector2 position)
        {
            int width = spriteTexture.Width / column;
            int height = spriteTexture.Height / row;
            int rows = (int)((float)currentFrame / (float)column);
            int columns = currentFrame % column;
            Rectangle sourceRectangle = new Rectangle(width * columns, height * rows, width, height);
            Rectangle destinationRectangle = new Rectangle((int)position.X, (int)position.Y, width, height);
            spriteBatch.Draw(spriteTexture, destinationRectangle, sourceRectangle, Color.SlateBlue);
        }

        public int GetHeight()
        {
            return spriteTexture.Height / row;
        }

        public int GetWidth()
        {
            return spriteTexture.Width / column;
        }
    }
}