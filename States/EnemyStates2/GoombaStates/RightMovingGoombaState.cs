﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


namespace Spaghetti
{
    public class RightMovingGoombaState: IGoombaState
    {
        private Goomba myGoomba;
        private ISprite goombaSprite;

        public RightMovingGoombaState(Goomba goomba)
        {
            myGoomba = goomba;
            goombaSprite = EnemySpriteFactory.Instance.CreateGoombaSprite();
        }

        public void MoveLeft()
        {
            myGoomba.state = new LeftMovingGoombaState(myGoomba);
        }
        
        public void MoveRight()
        {
            //myGoomba.position.X += 1;
        }

        public void BeStomped()
        {
            myGoomba.state = new RunningInPlaceStompedGoombaState(myGoomba);
        }

        public void BeFlipped()
        {
            myGoomba.state = new FlippedGoombaState(myGoomba);
        }

        public void BeKilled()
        {
            myGoomba.state = new DeadGoombaState(myGoomba);
        }

        public void Update()
        {
            goombaSprite.Update();
            myGoomba.MoveRight();
        }

        public void Draw(SpriteBatch spriteBatch, Camera camera)
        {
            goombaSprite.Draw(spriteBatch, camera.AdjustPosition(myGoomba.position));
        }

        public int GetWidth()
        {
            return goombaSprite.GetWidth();
        }

        public int GetHeight()
        {
            return goombaSprite.GetHeight();
        }

    }
}
