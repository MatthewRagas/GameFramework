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


        private Vector2 _location = new Vector2();
        public char Icon { get; set; } = ' ';
        //The image representing the Entity on the screen
        public Texture2D Sprite { get; set; }
        public bool Solid { get; set; } = false;

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

        private Scene _scene;
        public Scene TheScene
        {
            set
            {
                _scene = value;
            }
            get
            {
                return _scene;
            }
        }

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
            OnUpdate?.Invoke();
        }

        public void Draw()
        {
            OnDraw?.Invoke();
        }
    }
}
