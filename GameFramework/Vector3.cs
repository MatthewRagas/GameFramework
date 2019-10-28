using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameFramework
{
    class Vector3
    {
        public float _x, _y, _z;


        public Vector3()
        {
            _x = 0;
            _y = 0;
            _z = 0;
        }
        public Vector3(float x,float y,float z)
        {
            _x = x;
            _y = y;
            _z = z;
        }

        //Vec3 + Vec3
        public static Vector3 operator +(Vector3 lhs, Vector3 rhs)
        {
            return new Vector3(lhs._x + rhs._x, lhs._y + rhs._y, lhs._z + rhs._z);
        }

        //Vec3 - Vec3
        public static Vector3 operator -(Vector3 lhs, Vector3 rhs)
        {
            return new Vector3(lhs._x - rhs._x, lhs._y - rhs._y, lhs._z - rhs._z);
        }

        //Vec3 / float
        public static Vector3 operator /(Vector3 lhs, float num)
        {
            return new Vector3(lhs._x / num, lhs._y / num, lhs._z / num);
        }

        //float / Vec3
        public static Vector3 operator /(float num, Vector3 rhs)
        {
            return new Vector3(num / rhs._x, num / rhs._y, num / rhs._z);
        }

        //Vec3 * float
        public static Vector3 operator *(Vector3 lhs, float num)
        {
            return new Vector3(lhs._x * num, lhs._y * num, lhs._z * num);
        }

        //float * Vec3
        public static Vector3 operator *(float num, Vector3 rhs)
        {
            return new Vector3(num * rhs._x, num * rhs._y, num * rhs._z);
        }

        public float Magnitude()
        {
            return (float)Math.Sqrt(_x * _x + _y * _y + _z * _z);
        }

        public float MagnitudeSqr()
        {
            return (_x * _x + _y * _y + _z * _z);
        }

        public float Distance(Vector3 other)
        {
            float diffX = _x - other._x;
            float diffY = _y - other._y;
            float diffZ = _z - other._z;

            return (float) Math.Sqrt(diffX * diffX + diffY * diffY + diffZ * diffZ);
        }
    }
}
