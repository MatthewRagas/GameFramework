using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameFramework
{
    class Vector2
    {
        private float _x, _y;

        public Vector2(float x, float y)
        {
            _x = x;
            _y = y;
        }

        public static Vector2 operator +(Vector2 lhs, Vector2 rhs)
        {
            return new Vector2(lhs._x + rhs._x, lhs._y + rhs._y);
        }

        public static Vector2 operator -(Vector2 lhs, Vector2 rhs)
        {
            return new Vector2(lhs._x - rhs._x, lhs._y - rhs._y);
        }

        public static Vector2 operator /(Vector2 vec2, float num)
        {
            return new Vector2(vec2._x / num, vec2._y / num);
        }

        public static Vector2 operator /(float num, Vector2 vec2)
        {
            return new Vector2(num / vec2._x, num / vec2._y);
        }

        public static Vector2 operator *(Vector2 lhs, float num)
        {
            return new Vector2(lhs._x * num, lhs._y * num);
        }

        public static Vector2 operator *(float num, Vector2 rhs)
        {
            return new Vector2(rhs._x * num, rhs._y * num);
        }
    }
}
