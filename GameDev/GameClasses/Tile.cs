using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameDev.GameClasses
{
    class Tile: Sprite
    {
        public bool IsBlocked { get; set; }
        public Tile(Texture2D tex, Vector2 pos, SpriteBatch batch, bool isBlocked):base(tex, pos, batch)
        {
            IsBlocked = isBlocked;
        }

        public override void Draw()
        {
            if (IsBlocked) { base.Draw(); }
        }
    }
}
