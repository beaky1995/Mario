using Microsoft.Xna.Framework;

namespace Spaghetti { 
    public interface ICollidable
    {
        Rectangle CollisionBox { get;}
        //Vector2 Velocity { get;}
        bool IsCollidable { get; set; }
    }
}
