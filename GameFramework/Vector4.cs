using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameFramework
{
    class Vector4
    {
        public float _x, _y, _z, _w;


        public Vector4()
        {
            _x = 0;
            _y = 0;
            _z = 0;
            _w = 0;
        }
        public Vector4(float x, float y, float z, float w)
        {
            _x = x;
            _y = y;
            _z = y;
            _w = w;
        }

        //Vec3 + Vec3
        public static Vector4 operator +(Vector4 lhs, Vector4 rhs)
        {
            return new Vector4(lhs._x + rhs._x, lhs._y + rhs._y, lhs._z + rhs._z, lhs._w + rhs._w);
        }

        //Vec3 - Vec3
        public static Vector4 operator -(Vector4 lhs, Vector4 rhs)
        {
            return new Vector4(lhs._x - rhs._x, lhs._y - rhs._y, lhs._z - rhs._z, lhs._w - rhs._w);
        }

        //Vec3 / float
        public static Vector4 operator /(Vector4 lhs, float num)
        {
            return new Vector4(lhs._x / num, lhs._y / num, lhs._z / num, lhs._w / num);
        }

        //float / Vec3
        public static Vector4 operator /(float num, Vector4 rhs)
        {
            return new Vector4(num / rhs._x, num / rhs._y, num / rhs._z, num / rhs._w);
        }

        //Vec3 * float
        public static Vector4 operator *(Vector4 lhs, float num)
        {
            return new Vector4(lhs._x * num, lhs._y * num, lhs._z * num, lhs._w * num);
        }

        //float * Vec3
        public static Vector4 operator *(float num, Vector4 rhs)
        {
            return new Vector4(num * rhs._x, num * rhs._y, num * rhs._z, num * rhs._w);
        }

        public static float Magnitude(float x, float y, float z, float w)
        {
            return (float)Math.Sqrt(x * x + y * y + z * z + w * w);
        }

        public static float MagnitudeSqr(float x, float y, float z, float w)
        {
            return (x * x + y * y + z * z + w * w);
        }

        public float Distance(Vector4 other)
        {
            float diffX = _x - other._x;
            float diffY = _y - other._y;
            float diffZ = _z - other._z;
            float diffW = _w - other._w;

            return (float)Math.Sqrt(diffX * diffX + diffY * diffY + diffZ * diffZ + diffW * diffW);
        }
    }
}
