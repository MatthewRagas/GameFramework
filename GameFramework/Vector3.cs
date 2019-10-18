using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameFramework
{
    class Vector3
    {
        private float _x, _y, _z;

        public Vector3(float x,float y,float z)
        {
            _x = x;
            _y = y;
            _z = y;
        }

        public static Vector3 operator +(Vector3 lhs, Vector3 rhs)
        {
            return new Vector3(lhs._x + rhs._x, lhs._y + rhs._y, lhs._z + rhs._z);
        }

        public static Vector3 operator -(Vector3 lhs, Vector3 rhs)
        {
            return new Vector3(lhs._x - rhs._x, lhs._y - rhs._y, lhs._z - rhs._z);
        }

        public static Vector3 operator /(Vector3 lhs, float num)
        {
            return new Vector3(lhs._x / num, lhs._y / num, lhs._z / num);
        }

        public static Vector3 operator /(float num, Vector3 rhs)
        {
            return new Vector3(num / rhs._x, num / rhs._y, num / rhs._z);
        }

        public static Vector3 operator *(Vector3 lhs, float num)
        {
            return new Vector3(lhs._x * num, lhs._y * num, lhs._z * num);
        }

        public static Vector3 operator *(float num, Vector3 rhs)
        {
            return new Vector3(num * rhs._x, num * rhs._y, num * rhs._z);
        }
    }
}
