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
        public Vector2 Movement { get; set; }
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
            Movement += Vector2.UnitY * .5f;
        }

        public bool IsOnFirmGround()
        {
            Rectangle onePixelLower = GetAABB();
            onePixelLower.Offset(0, 1);
            return !Board.CurrentBoard.HasRoomForRectangle(onePixelLower);
        }
        




        /// <summary>
        /// Helper functies voor betere code:
        /// </summary>


        private void CheckKeyBoardStateAndUpdateMovement()
        {
            keyboardState = Keyboard.GetState();
            if (keyboardState.IsKeyDown(Keys.Left)) { Movement += new Vector2(-1, 0); }
            if (keyboardState.IsKeyDown(Keys.Right)) { Movement += new Vector2(1, 0); }
            if (keyboardState.IsKeyDown(Keys.Up) && IsOnFirmGround()) { Movement = -Vector2.UnitY * 25; }

        }
        private void SimulateFriction()
        {
            Movement -= Movement * new Vector2(.1f, .1f);
        }
        private void MoveIfPossible(GameTime gameTime)
        {
            Vector2 oldPosition = Position;
            UpdatePosition(gameTime);
            Position = Board.CurrentBoard.WhereCanIGetTo(oldPosition, Position, GetAABB());

        }

        private void UpdatePosition(GameTime gameTime)
        {
            Position += Movement * (float)gameTime.ElapsedGameTime.TotalMilliseconds / 15; ;
        }

    }
}
