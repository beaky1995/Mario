using System;
using Microsoft.Xna.Framework;
using System.Diagnostics;

namespace Spaghetti
{
    class BlockCollisionHandler
    {

        public BlockCollisionHandler()
        {

        }

        public void HandleCollision(Game1 game, IBlock block, CollisionDetection.Direction result, Type type, Rectangle intersect)
        {
            
            IPlayer mario = game.PlayerList[0];
            if (type.ToString().Contains("Mario"))
            {
                if (block is LavaTopBlock || block is LavaBlock)
                {
                    if (!mario.IsDead() && (mario.IsBig() || mario.IsFire()))
                    {
                        game.PlayerList[0] = new DamageMario(mario, game);
                        SoundManager.Instance.TakeDamage();
                    }
                    else if(!mario.IsDead())
                    {
                        mario.Die();
                    }
                }
                if (mario.IsMovingUp() && !mario.IsFalling() && result.Equals(CollisionDetection.Direction.Bottom) && (intersect.Width > 4f))
                {
                    if (block is HiddenBlock)
                    {
                        block.IsBumped = true;
                        game.blocksToAdd.Add(new UsedBlock(block.CollisionBox.X, block.CollisionBox.Y));
                        block.React(0);
                    }


                    if (block is BrickBlock)
                    {
                        block.IsBumped = true;
                        if (mario.IsBig() || mario.IsFire())
                        {

                            block.React(0);
                            Singleton.Instance.score += 50;

                        }
                        else
                        {
                            block.NonDestroy();
                        }
                    }
                    else if (block is FalseBrickBlock)
                    {
                        block.IsBumped = true;
                        block.NonDestroy();
                        block.React(0);
                    }
                    else if (block is QuestionBlock)
                    {
                        block.IsBumped = true;
                        if (mario.IsBig() || mario.IsFire())
                        {
                            block.NonDestroy();

                            block.React(1);
                            game.blocksToAdd.Add(new UsedBlock(block.CollisionBox.X, block.CollisionBox.Y));

                        }
                        else
                        {
                            block.NonDestroy();
                            block.React(0);
                        }
                    }

                    else
                    {
                        block.IsBumped = true;
                        block.NonDestroy();
                    }
                }
            }
        }
    }
}
