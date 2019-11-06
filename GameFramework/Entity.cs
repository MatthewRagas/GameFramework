using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Raylib;
using RL = Raylib.Raylib;

namespace GameFramework
{

    delegate void Event();

    class Entity
    {

        public Event OnStart;
        public Event OnUpdate;
        public Event OnDraw;

        //The location of the Entity
        //private Vector3 _location = new Vector3(0,0,1);
        ////The velocity of the Entity
        private Vector2 _velocity = new Vector2();
        ////private Matrix3 _transform = new Matrix3();

        //private Matrix3 _translation = new Matrix3();
        //private Matrix3 _rotation = new Matrix3();
        //private Matrix3 _scale = new Matrix3();
        private Matrix3 _localTransform = new Matrix3();
        private Matrix3 _globalTransform = new Matrix3();

        public char Icon { get; set; } = ' ';
        //The image representing the Entity on the screen
        public Texture2D Sprite { get; set; }
        public bool Solid { get; set; } = false;
        //private float _scale = 1.0f;

        public float X
        {
            get
            {
                return _localTransform.m13;
            }
            set
            {
                _localTransform.SetTranslation(value,Y,1);
            }
        }

        public float XVelocity
        {
            get
            {
                return _velocity._x;
                //return _translation.m13;
            }
            set
            {
                _velocity._x = value;
                //_translation.SetTranslation(value, YVelocity, 1);
            }
        }


        public float Y
        {
            get
            {
                return _localTransform.m23;
            }
            set
            {
                _localTransform.SetTranslation(X,value,1);
            }
        }

        public float YVelocity
        {
            get
            {
                return _velocity._y;
                //return _translation.m23;
            }
            set
            {
                _velocity._y = value;
                //_translation.SetTranslation(XVelocity, value, 1);
            }
        }
        
        public float Size
        {
            get
            {
                //return _transform.m11;
                //return _scale;
                return 1;
            }
            //set
            //{
            //    _localTransform.SetScaled(value, value, 1);
            //   //_scale = value; ;
            //}
        }

        public float Rotation
        {
            get
            {
                return (float)Math.Atan2(_localTransform.m21, _localTransform.m11);
            }
            //set
            //{
            //    _localTransform.SetRotateZ(value);
            //}
        }

        public Scene TheScene { get; set; }                                                                                                                       

        public Entity()
        {

        }

        public Entity(char icon)
        {
            Icon = icon;
        }

        //Creates an Entity with the specified icon and image
        public Entity(char icon, string imageName) : this(icon)
        {
            Sprite = RL.LoadTexture(imageName);
        }

        public void Scale(float width, float height)
        {
            _localTransform.Scale(width, height, 1);
        }

        public void Rotate(float radians)
        {
            _localTransform.RotateZ(radians);
        }

        public void Start()
        {
            OnStart?.Invoke();
        }

        public void Update()
        {
            //_location += _velocity;
            //Matrix3 transform = _translation * _rotation;
            //_location = transform * _location;
            X += _velocity._x;
            Y += _velocity._y;
            OnUpdate?.Invoke();
        }

        public void Draw()
        {
            OnDraw?.Invoke();
        }
    }
}
