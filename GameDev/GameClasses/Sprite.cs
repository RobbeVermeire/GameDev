using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameDev.GameClasses
{
    /// <summary>
    /// Sprite klasse voor texture en positie te bundelen bij elkaar,
    /// krijgt ook een spritebatch variable zodat elke sprite zijn eigen kan drawen op scherm.
    /// </summary>
    class Sprite
    {
        public Vector2 Position { get; set; }
        public Texture2D Texture { get; set; }
        public SpriteBatch SpriteBatch { get; set; }

        public Rectangle GetAABB()
        { return new Rectangle((int)Position.X, (int)Position.Y, Texture.Width, Texture.Height); }

        public Sprite(Texture2D tex, Vector2 pos, SpriteBatch batch)
        {
            Texture = tex;
            Position = pos;
            SpriteBatch = batch;
        }

        public virtual void Draw()
        {
            SpriteBatch.Draw(Texture, Position, Color.White);
        }
    }
}
