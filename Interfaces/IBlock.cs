using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Spaghetti
{
    public interface IBlock: IUpdatable, IDrawable, ICollidable
    {
        
        void React(int a);
        bool RemoveCheck();       
        void NonDestroy();
        void SetItem(IItem item);
        IBlockState State { get; set; }
        string GetBlockType();

        bool IsBumped { get; set;  }
    }
}
