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

        }

        public Matrix2(float m11, float m12, float m21, float m22)
        {
            this.m11 = m11; this.m12 = m12;
            this.m21 = m21; this.m22 = m22;
        }

        public static Matrix2 operator *(Matrix2 lhs, Matrix2 rhs)
        {
            return new Matrix2(
                lhs.m11 * rhs.m11 + lhs.m12 * rhs.m21,
                lhs.m11 * rhs.m12 + lhs.m12 * rhs.m22,
                lhs.m21 * rhs.m11 + lhs.m22 * rhs.m21,
                lhs.m21 * rhs.m12 + lhs.m22 * rhs.m22);
        }
    }
}
