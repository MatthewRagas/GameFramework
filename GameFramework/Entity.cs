using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
