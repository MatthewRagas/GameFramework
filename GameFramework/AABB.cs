using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Raylib;
using RL = Raylib.Raylib;

namespace GameFramework
{
    class AABB
    {
        private Vector3 _min = new Vector3(float.NegativeInfinity,
                                    float.NegativeInfinity,
                                    float.NegativeInfinity);

        private Vector3 _max = new Vector3(float.PositiveInfinity,
                                    float.PositiveInfinity,
                                    float.PositiveInfinity);
        
        public AABB()
        {

        }

        public AABB(Vector3 min, Vector3 max)
        {
            _min = min;
            _max = max;
        }

        public void Resize(Vector3 min, Vector3 max)
        {
            _min = min;
            _max = max;
        }

        public void Move(Vector3 point)
        {
            Vector3 extents = Extents();
            _min = point - extents;
            _max = point + extents;
        }

        public Vector3 Center()
        {
            return (_min + _max) * 0.5f;
        }

        public Vector3 Extents()
        {
            return new Vector3(Math.Abs(_max._x - _min._x) * 0.5f,
            Math.Abs(_max._y - _min._y) * 0.5f,
            Math.Abs(_max._z - _min._z) * 0.5f);
        }

        public List<Vector3> Corners()
        {
            // ignoring z axis for 2D
            List<Vector3> corners = new List<Vector3>(4);
            corners[0] = _min;//Top Left
            corners[1] = new Vector3(_min._x, _max._y, _min._z);//Bottom Left
            corners[2] = _max;//Bottom Right
            corners[3] = new Vector3(_max._x, _min._y, _min._z);//Top Right
            return corners;
        }

        public void Fit(List<Vector3> points)
        {
            // invalidate the extents
            _min = new Vector3(float.PositiveInfinity,
           float.PositiveInfinity,
           float.PositiveInfinity);
            _max = new Vector3(float.NegativeInfinity,
           float.NegativeInfinity,
           float.NegativeInfinity);
            
            //Find _min and _max of the points
            foreach (Vector3 p in points)
            {
                _min = Vector3.Min(_min, p);
                _max = Vector3.Max(_max, p);
            }
        }

        public bool Overlaps(Vector3 p)
        {
            return !(p._x < _min._x || p._y < _min._y ||
                    p._x > _max._x || p._y > _max._y);
        }

        public bool Overlaps(AABB other)
        {
            return !(_max._x < other._min._x || _max._y < other._min._y ||
                    _min._x > other._max._x || _min._y > other._max._y);
        }

        public Vector3 ClosestPoint(Vector3 p)
        {
            return Vector3.Clamp(p, _min, _max);
        }

        public void Draw(Color color)
        {
            float posX = _min._x * Game.UnitSize._x + Game.UnitSize._x / 2;
            float posY = _min._y * Game.UnitSize._y + Game.UnitSize._y / 2;
            float width = (_max._x - _min._x) * Game.UnitSize._x;
            float height = (_max._y - _min._y) * Game.UnitSize._y;
            RL.DrawRectangleLines((int)posX, (int)posY, (int)width, (int)height, color);
        }
    }
}
