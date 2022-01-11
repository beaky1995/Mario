using System;
using Microsoft.Xna.Framework;
using System.Diagnostics;

namespace Spaghetti
{
    class ObjectiveCollisionHandler
    {

        public ObjectiveCollisionHandler()
        {

        }

        public void HandleCollision(Game1 game, IObjective objective, CollisionDetection.Direction result, Type type, Rectangle intersect)
        {
            if (Singleton.Instance.isLevelFour)
            {
                Singleton.Instance.getAxe = true;
            }
            
                objective.React();

            
            
        }
    }
}
