using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameFramework
{
    class Vector2
    {
        public float _x, _y;


        public Vector2()
        {
            _x = 0;
            _y = 0;
        }
        public Vector2(float x, float y)
        {
            _x = x;
            _y = y;
        }
        public float Magnitude()
        {
            return (float)Math.Sqrt(_x * _x + _y * _y);
        }

        public float MagnitudeSqr()
        {
            return (_x * _x + _y * _y);
        }

        public float Distance(Vector2 other)
        {
            float diffX = _x - other._x;
            float diffY = _y - other._y;            

            return (float)Math.Sqrt(diffX * diffX + diffY * diffY);
        }

        //Vec2 + Vec2
        public static Vector2 operator +(Vector2 lhs, Vector2 rhs)
        {
            return new Vector2(lhs._x + rhs._x, lhs._y + rhs._y);
        }

        //Vec2 - Vec2
        public static Vector2 operator -(Vector2 lhs, Vector2 rhs)
        {
            return new Vector2(lhs._x - rhs._x, lhs._y - rhs._y);
        }

        //Vec2 / float
        public static Vector2 operator /(Vector2 vec2, float num)
        {
            return new Vector2(vec2._x / num, vec2._y / num);
        }

        //float / Vec2
        public static Vector2 operator /(float num, Vector2 vec2)
        {
            return new Vector2(num / vec2._x, num / vec2._y);
        }

        //Vec2 * float
        public static Vector2 operator *(Vector2 lhs, float num)
        {
            return new Vector2(lhs._x * num, lhs._y * num);
        }

        //float * Vec2
        public static Vector2 operator *(float num, Vector2 rhs)
        {
            return new Vector2(rhs._x * num, rhs._y * num);
        }

        public float DotProduct(Vector2 a, Vector2 b)
        {
            return (a._x * b._x + a._y * b._y);
        }                
    }
}
