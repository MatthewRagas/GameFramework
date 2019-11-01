using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameFramework
{
    class Matrix2
    {
        public float m11, m12, m21, m22;

        public Matrix2()
        {
            m11 = 1; m12 = 0;
            m21 = 0; m22 = 1;
        }

        public Matrix2(float m11, float m12, float m21, float m22)
        {
            this.m11 = m11; this.m12 = m12;
            this.m21 = m21; this.m22 = m22;
        }

        public Matrix2(Matrix2 matrix2)
        {
            m11 = matrix2.m11; m12 = matrix2.m12;
            m21 = matrix2.m21; m22 = matrix2.m22;
        }

        public static Matrix2 operator *(Matrix2 lhs, Matrix2 rhs)
        {
            return new Matrix2(
                //m11
                lhs.m11 * rhs.m11 + lhs.m12 * rhs.m21,
                //m12
                lhs.m11 * rhs.m12 + lhs.m12 * rhs.m22,
                //m21
                lhs.m21 * rhs.m11 + lhs.m22 * rhs.m21,
                //m22
                lhs.m21 * rhs.m12 + lhs.m22 * rhs.m22);
        }

        public static Vector2 operator *(Matrix2 lhs, Vector2 rhs)
        {
            return new Vector2(
                lhs.m11 * rhs._x + lhs.m12 * rhs._x, //X
                lhs.m21 * rhs._y + lhs.m22 * rhs._y);//Y
        }
    }
}
