using GameDev.GameClasses;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameDev
{
    class Player : Sprite
    {
        
        private KeyboardState keyboardState;
        public Player(Texture2D tex, Vector2 pos, SpriteBatch batch):base(tex,pos,batch)
        {

        }

        public void Update(GameTime gameTime)
        {
            CheckKeyBoardStateAndUpdateMovement();
            AffectWithGravity();
            SimulateFriction();
            MoveIfPossible(gameTime);

        }

        private void AffectWithGravity()
        {
            Speed += Vector2.UnitY * .5f;
        }

        public bool IsOnFirmGround()
        {
            Vector2 center = Position + AABB.HalfSize;
            Vector2 bottomLeft = Position + Vector2.UnitY * AABB.BoundingBox.Height;
            Vector2 BottomRight = center + AABB.HalfSize;
            int tileIndexX, tileIndexY;
            for(Vector2 checkedTile = bottomLeft; ; checkedTile.X +=70)
            {
                checkedTile.X = Math.Min(checkedTile.X, BottomRight.X);

                



            }
        
        }
        




        /// <summary>
        /// Helper functies voor betere code:
        /// </summary>


        private void CheckKeyBoardStateAndUpdateMovement()
        {
            keyboardState = Keyboard.GetState();
            if (keyboardState.IsKeyDown(Keys.Left)) { Speed -= Vector2.UnitX; }
            if (keyboardState.IsKeyDown(Keys.Right)) { Speed += Vector2.UnitX; }
            if (keyboardState.IsKeyDown(Keys.Up) && IsOnFirmGround()) { Speed = -Vector2.UnitY * 25; }

        }
        private void SimulateFriction()
        {
            Speed -= Speed * new Vector2(.1f, .1f);
        }
        private void MoveIfPossible(GameTime gameTime)
        {
            Vector2 oldPosition = Position;
            UpdatePosition(gameTime);
            Position = Board.CurrentBoard.WhereCanIGetTo(oldPosition, Position, AABB.BoundingBox);

        }

        private void UpdatePosition(GameTime gameTime)
        {
            Position += Speed * (float)gameTime.ElapsedGameTime.TotalMilliseconds / 15; ;
        }

    }
}
