using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameDev.GameClasses
{
    public class AABB
    {
        public Rectangle BoundingBox;
        public Vector2 HalfSize => new Vector2(BoundingBox.Width / 2, BoundingBox.Y / 2);

        public AABB(int x, int y, int width, int height)
        {
            BoundingBox = new Rectangle(x, y, width, height);
        }

        public bool Overlaps(AABB other)
        {
            if (Math.Abs(BoundingBox.X - other.BoundingBox.X) > HalfSize.X + other.HalfSize.X) return false;
            if (Math.Abs(BoundingBox.Y - other.BoundingBox.Y) > HalfSize.Y + other.HalfSize.Y) return false;
            return true;
        }
    }
}
