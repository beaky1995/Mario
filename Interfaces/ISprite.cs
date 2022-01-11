using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Spaghetti
{

    public interface ISprite: IUpdatable
    {
        void Draw(SpriteBatch spriteBatch, Vector2 position);
        void StarDraw(SpriteBatch spriteBatch, Vector2 position);
        int GetWidth();
        int GetHeight();
    }
}
