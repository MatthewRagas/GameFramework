using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameFramework
{
    class Wall : Entity
    {
        public Wall(int x, int y) : base('█', "emboss-lighted-texture.png")
        {
            X = x;
            Y = y;
            OriginX = 4;
            OriginY = 4;
            Solid = true;
            //OnUpdate += SPIN;
        }

        void SPIN()
        {
            //Rotation = 0.01f;
            Rotate(0.05f);
        }
    }
}
