using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlatformerGame2.Classes
{
    class MovingObject
    {
        public Texture2D mTexture;
        public SpriteBatch mSpriteBatch;

        
        public Vector2 mOldPosition;
        public Vector2 mPosition;

        public Vector2 mOldSpeed;
        public Vector2 mSpeed;
        public Vector2 mScale;

        public AABB mAABB;
        public Vector2 mAABBOffset;

        public bool mPushedRightWall;
        public bool mPushesRightWall;

        public bool mPushedLeftWall;
        public bool mPushesLeftWall;

        public bool mWasOnGround;
        public bool mOnGround;

        public bool mWasAtCeiling;
        public bool mAtCeiling;

        public MovingObject(Texture2D tex, Vector2 pos, SpriteBatch batch)
        {
            mTexture = tex;
            mPosition = pos;
            mSpriteBatch = batch;
        }

        protected void UpdatePhysics(GameTime gameTime)
        {
            mOldPosition = mPosition;
            mOldSpeed = mSpeed;

            mWasOnGround = mOnGround;
            mPushedRightWall = mPushesRightWall;
            mPushedLeftWall = mPushesLeftWall;
            mWasAtCeiling = mAtCeiling;

            mPosition += mSpeed * gameTime.ElapsedGameTime.Seconds;

            if (mPosition.Y < 0.0f)
            {
                mPosition.Y = 0.0f;
                mOnGround = true;
            }
            else
                mOnGround = false;
            mAABB.center = mPosition + mAABBOffset;

        }
        public virtual void Draw()
        {
            mSpriteBatch.Draw(mTexture, mPosition, Color.White);
        }
    }
}
