using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameFramework
{
    class Wall : Entity
    {
        public Wall(int x, int y)
        {
            X = x;
            Y = y;
            Solid = true;            
        }
        public Wall(char icon, string imageName) : base('█', "emboss-lighted-texture.png")
        {

        }
    }
}
