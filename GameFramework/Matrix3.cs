using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameFramework
{
    class Matrix3
    {
        public float m11, m12, m13, m21, m22, m23, m31, m32, m33;
        public Matrix3()
        {
            m11 = 1; m12 = 0; m13 = 0;
            m21 = 0; m22 = 1; m23 = 0;
            m31 = 0; m32 = 0; m33 = 1;           
        }

        //Creates a Matrix3 ith the specidfied values
        public Matrix3(
            float m11, float m12, float m13, float m21, float m22, 
            float m23, float m31, float m32, float m33)
        {
            this.m11 = 1; this.m12 = 0; this.m13 = 0;
            this.m21 = 0; this.m22 = 1; this.m23 = 0;
            this.m31 = 0; this.m32 = 0; this.m33 = 1;
        }

        public Matrix3(Matrix3 matrix3)
        {
            m11 = matrix3.m11; m12 = matrix3.m12; m13 = matrix3.m13;
            m21 = matrix3.m21; m22 = matrix3.m22; m23 = matrix3.m23;
            m31 = matrix3.m31; m32 = matrix3.m32; m33 = matrix3.m33;
        }


        public static Matrix3 operator *(Matrix3 lhs, Matrix3 rhs)
        {
            return new Matrix3(
                //m11
                lhs.m11 * rhs.m11 + lhs.m12 * rhs.m21 + lhs.m13 * rhs.m31,
                //m12
                lhs.m11 * rhs.m12 + lhs.m12 * rhs.m22 + lhs.m13 * rhs.m32,
                //m13
                lhs.m11 * rhs.m13 + lhs.m12 * rhs.m23 + lhs.m13 * rhs.m33,
                //m21
                lhs.m21 * rhs.m11 + lhs.m22 * rhs.m21 + lhs.m23 * rhs.m31,
                //m22
                lhs.m21 * rhs.m12 + lhs.m22 * rhs.m22 + lhs.m23 * rhs.m32,
                //m23
                lhs.m21 * rhs.m13 + lhs.m22 * rhs.m23 + lhs.m23 * rhs.m33,
                //m31
                lhs.m31 * rhs.m11 + lhs.m32 * rhs.m21 + lhs.m33 * rhs.m31,
                //m32
                lhs.m31 * rhs.m12 + lhs.m32 * rhs.m22 + lhs.m33 * rhs.m32,
                //m33
                lhs.m31 * rhs.m13 + lhs.m32 * rhs.m23 + lhs.m33 * rhs.m33);
        }

        public static Vector3 operator *(Matrix3 lhs, Vector3 rhs)
        {
            return new Vector3(
                lhs.m11 * rhs._x + lhs.m12 * rhs._y + lhs.m13 * rhs._z,
                lhs.m21 * rhs._x + lhs.m22 * rhs._y + lhs.m23 * rhs._z,
                lhs.m31 * rhs._x + lhs.m32 * rhs._y + lhs.m33 * rhs._z);
        }   
        
        public void SetScaled(Vector3 v)
        {
            m11 = v._x; m12 = 0; m13 = 0;
            m21 = 0; m22 = v._y; m23 = 0;
            m31 = 0; m32 = 0; m33 = v._z;
        }

        public void SetScaled(float x, float y, float z)
        {
            m11 = x; m12 = 0; m13 = 0;
            m21 = 0; m22 = y; m23 = 0;
            m31 = 0; m32 = 0; m33 = z;
        }

        public void Set(Matrix3 matrix3)
        {
            m11 = matrix3.m11; m12 = matrix3.m12; m13 = matrix3.m13;
            m21 = matrix3.m21; m22 = matrix3.m22; m23 = matrix3.m23;
            m31 = matrix3.m31; m32 = matrix3.m32; m33 = matrix3.m33;
        }

        void Scale(float x, float y, float z)
        {
            Matrix3 m = new Matrix3();
            m.SetScaled(x, y, z);
            Set(this * m);
        }

        void Scale(Vector3 v)
        {
            Matrix3 m = new Matrix3();
            m.SetScaled(v._x, v._y, v._z);
            Set(this * m);
        }
    }
}
