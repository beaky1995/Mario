using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Spaghetti
{
    public class HiddenBlock : IBlock
    {
        private IBlockState state { get; set; }
        private bool isCollidable { get; set; }
        public Vector2 position;
        private bool toDestroy;
        private IItem item;
        private bool toUsed;
        
        private bool isBumped { get; set; }
        public HiddenBlock(int x, int y)
        {
            position.X = x;
            position.Y = y;
            State = new HiddenBlockState(this);
            IsCollidable = true;
            toDestroy = false;
            item = new Coin((int)position.X, (int)position.Y);
            IsBumped = false;
        }
        public bool IsBumped
        {
            get
            {
                return isBumped;
            }
            set => isBumped = value;

        }

        public Rectangle CollisionBox
        {
            get
            {
                return new Rectangle((int)position.X, (int)position.Y, state.GetWidth(), state.GetHeight());
            }

        }
        public void React(int a)
        {
            if (!toUsed)
            {
                toUsed = true;
                toDestroy = true;
                item.Appears();
                state.React();
                
            }
        }

        public void Update()
        {

        }

        public void Draw(SpriteBatch spriteBatch, Camera camera)
        {
            state.Draw(spriteBatch, camera);
        }

        public bool RemoveCheck()
        {
            return toDestroy;
        }

        public IBlockState State
        {
            get
            {
                return state;
            }
            set => state = value;
        }

        public bool IsCollidable
        {
            get
            {
                return isCollidable;
            }
            set => isCollidable = value;
        }

        public void NonDestroy()
        {

            SoundManager.Instance.Bump();
        }
        public void SetItem(IItem item)
        {
            this.item = item;
        }

        public string GetBlockType()
        {
            return "HiddenBlock";
        }
    }
}
