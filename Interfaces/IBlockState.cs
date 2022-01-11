using Microsoft.Xna.Framework.Graphics;

namespace Spaghetti
{
    public interface IBlockState: IUpdatable, IDrawable
    {
        int GetWidth();
        int GetHeight();
        void React();
    }
}
