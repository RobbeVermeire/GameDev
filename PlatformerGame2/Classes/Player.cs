using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PlatformerGame2.Classes
{
    class Player : MovingObject
    {

        public CharacterState mCurrentState = CharacterState.Stand;
        public float mJumpSpeed;
        public float mWalkSpeed;
        private KeyboardState mKeyboardState;

        public Player(Texture2D tex, Vector2 pos, SpriteBatch spriteBatch ):base(tex,pos,spriteBatch)
        {

        }

        public void Update(GameTime gameTime)
        {
            mKeyboardState = Keyboard.GetState();
            switch (mCurrentState)
            {
                case CharacterState.Stand:
                    mSpeed = Vector2.Zero;
                    if (!mOnGround)
                    {
                        mCurrentState = CharacterState.Jump;
                        break;
                    }    
                    if (mKeyboardState.IsKeyDown(Keys.Right) != mKeyboardState.IsKeyDown(Keys.Left))
                    {
                        mCurrentState = CharacterState.Walk;
                        break;
                    }
                    if (mKeyboardState.IsKeyDown(Keys.Up))
                    {
                        mSpeed.Y = mJumpSpeed;
                        mCurrentState = CharacterState.Jump;
                        break;
                    }
                    break;

                case CharacterState.Walk:
                    if (mKeyboardState.IsKeyDown(Keys.Right) == mKeyboardState.IsKeyDown(Keys.Left))
                    {
                        mCurrentState = CharacterState.Stand;
                        //mSpeed = Vector2.Zero;
                        break;
                    }
                    else if(mKeyboardState.IsKeyDown(Keys.Right))
                    {
                        if (mPushesRightWall)
                        {
                            mSpeed.X = 0.0f;
                        }
                        else mSpeed.X = mWalkSpeed;
                        mScale.X = Math.Abs(mScale.X);

                    }
                    else if (mKeyboardState.IsKeyDown(Keys.Left))
                    {
                        if (mPushesLeftWall)
                        {
                            mSpeed.X = 0.0f;
                        }
                        else mSpeed.X = -mWalkSpeed;
                        mScale.X = -Math.Abs(mScale.X);
                    }
                    if(mKeyboardState.IsKeyDown(Keys.Up))
                    {
                        //mSpeed.Y=mJumpSpeed

                    }

                    

                     break;

                case CharacterState.Jump:
                    mSpeed.Y = mJumpSpeed;
                     break;
            }   
            UpdatePhysics(gameTime);
        }

        private void CheckKeyBoardStateAndUpdateCharacterState()
        {
            mKeyboardState = Keyboard.GetState();
            if (mKeyboardState.IsKeyDown(Keys.Left)) mCurrentState = CharacterState.WalkLeft;
            else if (mKeyboardState.IsKeyDown(Keys.Right)) mCurrentState = CharacterState.WalkRight;
            if (mKeyboardState.IsKeyDown(Keys.Up) || !mOnGround) mCurrentState = CharacterState.Jump;
            else mCurrentState = CharacterState.Stand;
        }

    }
}
