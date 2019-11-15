using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Raylib;
using RL = Raylib.Raylib;

namespace GameFramework
{
    class SpriteEntity : Entity
    {        
        private Texture2D _texture = new Texture2D();
        private Image _image = new Image();

        public float Width
        {
            get { return _texture.width / Game.UnitSize._x; }
        }      

        public float Height
        {
            get { return _texture.height / Game.UnitSize._y; }
        }

        public float Top
        {
            get { return YAbsolute + 0.5f; }
        }

        public float Bottom
        {
            get { return YAbsolute + Height + 0.5f; }
        }

        public float Left
        {
            get { return XAbsolute; }
        }

        public float Right
        {
            get { return XAbsolute + Width; }
        }

        public SpriteEntity()
        {
           
        }

        public void Load(string path)
        {
            _image = RL.LoadImage(path);
            _texture = RL.LoadTextureFromImage(_image);
            X = -Width / 2;
            Y = -Height / 2;
        }

        public Texture2D Texture
        {
            get { return _texture; }
        }
    }
}
