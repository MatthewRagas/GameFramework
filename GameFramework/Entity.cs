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
        private Vector3 _location = new Vector3(0,0,1);
        //The velocity of the Entity
        //private Vector2 _velocity = new Vector2();
        //private Matrix3 _transform = new Matrix3();

        private Matrix3 _translation = new Matrix3();
        private Matrix3 _rotation = new Matrix3();
        //private Matrix3 _scale = new Matrix3();
        public char Icon { get; set; } = ' ';
        //The image representing the Entity on the screen
        public Texture2D Sprite { get; set; }
        public bool Solid { get; set; } = false;
        private float _scale = 1.0f;

        public float X
        {
            get
            {
                return _location._x;
            }
            set
            {
                _location._x = value;
            }
        }

        public float XVelocity
        {
            get
            {
                //return _velocity._x;
                return _translation.m13;
            }
            set
            {
                //_velocity._x = value;
                _translation.SetTranslation(value, YVelocity, 1);
            }
        }


        public float Y
        {
            get
            {
                return _location._y;
            }
            set
            {
                _location._y = value;
            }
        }

        public float YVelocity
        {
            get
            {
                //return _velocity._y;
                return _translation.m23;
            }
            set
            {
                //_velocity._y = value;
                _translation.SetTranslation(XVelocity, value, 1);
            }
        }
        
        public float Scale
        {
            get
            {
                //return _transform.m11;
                return _scale;
            }
            set
            {
                _scale = value; ;
            }
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

        public void Start()
        {
            OnStart?.Invoke();
        }

        public void Update()
        {
            //_location += _velocity;
            Matrix3 transform = _translation * _rotation;
            _location = transform * _location;
            OnUpdate?.Invoke();
        }

        public void Draw()
        {
            OnDraw?.Invoke();
        }
    }
}
