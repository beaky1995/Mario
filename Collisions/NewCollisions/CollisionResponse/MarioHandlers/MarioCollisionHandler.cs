using Microsoft.Xna.Framework;
using System;

namespace Spaghetti
{
    public class MarioCollisionHandler
    {
        const string block = "Block";
        const string goomba = "Spaghetti.Goomba";
        const string koopa = "Spaghetti.Koopa";
        const string bowser = "Spaghetti.Bowser";
        const string pipe = "Spaghetti.Pipe";
        const string warpPipe = "Spaghetti.WarpPipe";
        const string coin = "Spaghetti.Coin";
        const string redMushroom = "Spaghetti.RedMushroom";
        const string fireFlower = "Spaghetti.FireFlower";
        const string star = "Spaghetti.Star";
        const string hiddenBlock = "Spaghetti.HiddenBlock";
        const string flagPole = "Spaghetti.Flagpole";
        const string greenMushroom = "Spaghetti.GreenMushroom";
        const string platform = "Spaghetti.MovingPlatform";
        const string firebar = "Spaghetti.Firebar";
        const string firespear = "Spaghetti.FireSpear";
        const string axe = "Spaghetti.Axe";

        private MarioHiddenBlockCollisions marioHiddenBlockCollisions;
        private MarioBlockCollisions marioBlockCollisions;
        private MarioObjectiveCollision marioFlagPoleCollision;
        private MarioItemCollisions marioItemCollisions;
        private MarioGoombaCollision marioGoombaCollision;
        private MarioKoopaCollision marioKoopaCollision;
        private MarioBowserCollision marioBowserCollision;
        private MarioPipeCollision marioPipeCollision;

        private MarioPlatformCollisions marioPlatformCollision;
        private MarioFirebarCollision marioFirebarCollision;
        private MarioFireSpearCollision marioFireSpearCollision;


        public MarioCollisionHandler()
        {

            marioHiddenBlockCollisions = new MarioHiddenBlockCollisions();
            marioBlockCollisions = new MarioBlockCollisions();
            marioItemCollisions = new MarioItemCollisions();
            marioPipeCollision = new MarioPipeCollision();
            marioFlagPoleCollision = new MarioObjectiveCollision();
            marioGoombaCollision = new MarioGoombaCollision();
            marioKoopaCollision = new MarioKoopaCollision();
            marioBowserCollision = new MarioBowserCollision();
            marioFirebarCollision = new MarioFirebarCollision();
            marioFireSpearCollision = new MarioFireSpearCollision();
            marioPlatformCollision = new MarioPlatformCollisions();

        }


        public void HandleCollision(Game1 game, IPlayer mario, CollisionDetection.Direction result, Type type, Rectangle rec, object object2)
        {

            if (type.ToString().Equals(hiddenBlock))
            {
                marioHiddenBlockCollisions.HandleHiddenBlockCollisions(mario, result, rec);
            }
            else if (type.ToString().Contains(block))
            {
                marioBlockCollisions.HandleBlockCollisions(mario, result, rec);
            }
            else if (type.ToString().Contains(platform))
            {
                marioPlatformCollision.HandlePlatformCollisions(mario, result, rec, object2);
            }
            else if (type.ToString().Equals(star))
            {
                marioItemCollisions.HandleItemCollisions(game, mario, result, type, rec);
            }
            else if (type.ToString().Equals(goomba))
            {
                marioGoombaCollision.HandleGoombaCollision(game, mario, result, rec);
            }
            else if (type.ToString().Equals(koopa))
            {
                marioKoopaCollision.HandleKoopaCollision(game, mario, result, rec, object2);
            }
            else if (type.ToString().Equals(bowser))
            {
                marioBowserCollision.HandleBowserCollision(game, mario, result, rec);
            }
            else if (type.ToString().Equals(pipe))
            {
                marioPipeCollision.HandlePipeCollision(mario, result, rec);
            }
            else if (type.ToString().Equals(warpPipe))
            {
                marioPipeCollision.HandlePipeCollision(mario, result, rec);
            }
            else if (type.ToString().Equals(fireFlower))
            {
                marioItemCollisions.HandleItemCollisions(game, mario, result, type, rec);
            }
            else if (type.ToString().Equals(redMushroom))
            {
                marioItemCollisions.HandleItemCollisions(game, mario, result, type, rec);
            }
            else if (type.ToString().Equals(greenMushroom))
            {
                marioItemCollisions.HandleItemCollisions(game, mario, result, type, rec);
            }
            else if (type.ToString().Equals(flagPole))
            {
                marioFlagPoleCollision.HandleObjectiveCollision(game, mario, result, rec);
            }
            else if (type.ToString().Equals(axe))
            {
                marioFlagPoleCollision.HandleObjectiveCollision(game, mario, result, rec);
            }
            else if (type.ToString().Equals(firebar))
            {
                marioFirebarCollision.HandleFirebarCollision(game, mario, result, rec);
            }
            else if (type.ToString().Equals(firespear))
            {
                marioFireSpearCollision.HandleFireSpearCollision(game, mario, result, rec);
            }


        }
 
    }
}
