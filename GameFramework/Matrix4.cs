using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameFramework
{
    class Matrix4
    {
        public float 
            m11, m12, m13, m14,//X
            m21, m22, m23, m24,//Y 
            m31, m32, m33, m34,//Z 
            m41, m42, m43, m44;//W

        public Matrix4()
        {
            m11 = 1; m12 = 0; m13 = 0; m14 = 0;
            m21 = 0; m22 = 1; m23 = 0; m24 = 0;
            m31 = 0; m32 = 0; m33 = 1; m34 = 0;
            m41 = 0; m42 = 0; m43 = 0; m44 = 1;
        }

        public Matrix4(
            float n11, float n12, float n13, float n14,//X
            float n21, float n22, float n23, float n24,//Y 
            float n31, float n32, float n33, float n34,//Z 
            float n41, float n42, float n43, float n44)//W
        {
            m11 = n11; m12 = n12; m13 = n13; m14 = n14;
            m21 = n21; m22 = n22; m23 = n23; m24 = n24;
            m31 = n31; m32 = n32; m33 = n33; m34 = n34;
            m41 = n41; m42 = n42; m43 = n43; m44 = n44;
        }

        public Matrix4(Matrix4 matrix4)
        {
            m11 = matrix4.m11; m12 = matrix4.m12; m13 = matrix4.m13; m14 = matrix4.m14;
            m21 = matrix4.m21; m22 = matrix4.m22; m23 = matrix4.m23; m24 = matrix4.m24;
            m31 = matrix4.m31; m32 = matrix4.m32; m33 = matrix4.m33; m34 = matrix4.m34;
            m41 = matrix4.m41; m42 = matrix4.m42; m43 = matrix4.m43; m44 = matrix4.m44;
        }

        public static Matrix4 operator *(Matrix4 lhs, Matrix4 rhs)
        {
            return new Matrix4(
                //m11
                lhs.m11 * rhs.m11 + lhs.m12 * rhs.m21 + lhs.m13 * rhs.m31 + lhs.m14 * rhs.m41,
                //m12
                lhs.m11 * rhs.m12 + lhs.m12 * rhs.m22 + lhs.m13 * rhs.m32 + lhs.m14 * rhs.m42,
                //m13
                lhs.m11 * rhs.m13 + lhs.m12 * rhs.m23 + lhs.m13 * rhs.m33 + lhs.m14 * rhs.m43,
                //m14
                lhs.m11 * rhs.m14 + lhs.m12 * rhs.m24 + lhs.m13 * rhs.m34 + lhs.m14 * rhs.m44,

                //m21
                lhs.m21 * rhs.m11 + lhs.m22 * rhs.m21 + lhs.m23 * rhs.m31 + lhs.m24 * rhs.m41,
                //m22
                lhs.m21 * rhs.m12 + lhs.m22 * rhs.m22 + lhs.m23 * rhs.m32 + lhs.m24 * rhs.m42,
                //m23
                lhs.m21 * rhs.m13 + lhs.m22 * rhs.m23 + lhs.m23 * rhs.m33 + lhs.m24 * rhs.m43,
                //m24
                lhs.m21 * rhs.m14 + lhs.m22 * rhs.m24 + lhs.m23 * rhs.m34 + lhs.m24 * rhs.m44,

                //m31
                lhs.m31 * rhs.m11 + lhs.m32 * rhs.m21 + lhs.m33 * rhs.m31 + lhs.m34 * rhs.m41,
                //m32
                lhs.m31 * rhs.m12 + lhs.m32 * rhs.m22 + lhs.m33 * rhs.m32 + lhs.m34 * rhs.m42,
                //m33
                lhs.m31 * rhs.m13 + lhs.m32 * rhs.m23 + lhs.m33 * rhs.m33 + lhs.m34 * rhs.m43,
                //m34
                lhs.m31 * rhs.m14 + lhs.m32 * rhs.m24 + lhs.m33 * rhs.m34 + lhs.m34 * rhs.m44,

                //m41
                lhs.m41 * rhs.m11 + lhs.m42 * rhs.m21 + lhs.m43 * rhs.m31 + lhs.m44 * rhs.m41,
                //m42
                lhs.m41 * rhs.m12 + lhs.m42 * rhs.m22 + lhs.m43 * rhs.m32 + lhs.m44 * rhs.m42,
                //m43
                lhs.m41 * rhs.m13 + lhs.m42 * rhs.m23 + lhs.m43 * rhs.m33 + lhs.m44 * rhs.m43,
                //m44
                lhs.m41 * rhs.m14 + lhs.m42 * rhs.m24 + lhs.m43 * rhs.m34 + lhs.m44 * rhs.m44);
        }

        public static Vector4 operator *(Matrix4 lhs, Vector4 rhs)
        {
            return new Vector4(
                lhs.m11 * rhs._x + lhs.m12 * rhs._x + lhs.m13 * rhs._x + lhs.m14 * rhs._x,
                lhs.m21 * rhs._y + lhs.m22 * rhs._y + lhs.m23 * rhs._y + lhs.m24 * rhs._y,
                lhs.m31 * rhs._z + lhs.m32 * rhs._z + lhs.m33 * rhs._z + lhs.m34 * rhs._z,
                lhs.m41 * rhs._w + lhs.m42 * rhs._w + lhs.m43 * rhs._w + lhs.m44 * rhs._w);
        }

        public void SetScaled(float x, float y, float z)
        {
            m11 = x; m12 = 0; m13 = 0; m14 = 0;
            m21 = 0; m22 = y; m23 = 0; m24 = 0;
            m31 = 0; m32 = 0; m33 = z; m34 = 0;
            m41 = 0; m42 = 0; m43 = 0; m44 = 1;
        }

        public void SetScaled(Vector4 v)
        {
            m11 = v._x; m12 = 0; m13 = 0; m14 = 0;
            m21 = 0; m22 = v._y; m23 = 0; m24 = 0;
            m31 = 0; m32 = 0; m33 = v._z; m34 = 0;
            m41 = 0; m42 = 0; m43 = 0; m44 = 1;
        }

        public void Set(
          float m11, float m12, float m13, float m14,
          float m21, float m22, float m23, float m24,
          float m31, float m32, float m33, float m34,
          float m41, float m42, float m43, float m44)
        {
            this.m11 = m11; this.m12 = m12; this.m13 = m13; this.m14 = m14;
            this.m21 = m21; this.m22 = m22; this.m23 = m23; this.m24 = m24;
            this.m31 = m31; this.m32 = m32; this.m33 = m33; this.m34 = m34;
            this.m41 = m41; this.m42 = m42; this.m43 = m43; this.m44 = m44;
        }

        public void SetRotateX(double radians)
        {
            Set(
            1, 0, 0, 0,
            0, (float)Math.Cos(radians), (float)-Math.Sin(radians), 0,
            0, (float)Math.Sin(radians), (float)Math.Cos(radians), 0,
            0, 0, 0, 1);
        }

        public void SetRotateY(double radians)
        {
            Set((float)Math.Cos(radians), 0, (float)Math.Sin(radians), 0,
                0, 1, 0, 0,
                (float)-Math.Sin(radians), 0, (float)Math.Cos(radians), 0,
                0, 0, 0, 1);
        }

        public void SetRotateZ(double radians)
        {
            Set((float)Math.Cos(radians), (float)-Math.Sin(radians), 0, 0,
                (float)Math.Sin(radians), (float)Math.Cos(radians), 0, 0,
                0, 0, 1, 0,
                0, 0, 0, 1);
        }

    }
}
