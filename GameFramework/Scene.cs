using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameFramework
{
    //Class Scene is responsible for updating Entities
    class Scene
    {
        private List<Entity> _entities = new List<Entity>();
        private int _sizeX;
        private int _sizeY;
        //Create the collision grid
        private bool[,] _collision;

        public Scene() : this(24,6)
        {
           
        }
        public Scene(int sizeX, int sizeY)
        {
            _sizeX = sizeX;
            _sizeY = sizeY;
            _collision = new bool[_sizeX, _sizeY];
        }

        public int SizeX
        {
            get
            {
                return _sizeX;
            }                   
        }

        public int SizeY
        {
            get
            {
                return _sizeY;
            }
        }

        public void Start()
        {
            foreach(Entity e in _entities)
            {
                e.Start();
            }
        }

        public void Update()
        {
            //Clear the collision grid
            _collision = new bool[_sizeX, _sizeY];           

            foreach(Entity e in _entities)
            {
                e.Update();

                //Set the Entity's collision in the collision grid
                int x = (int)e.X;
                int y = (int)e.Y;
                if(e.X>= 0 && e.Y < _sizeY && e.Y >= 0 && e.X < _sizeX)
                {
                    if(!_collision[x,y])
                    {
                        _collision[x, y] = e.Solid;
                    }
                }
            }
        }

        public void Draw()
        {

            //Clear the screen
            Console.Clear();
            
            char[,] display = new char[_sizeX, _sizeY];

            foreach (Entity e in _entities)
            {
                e.Draw();

                //Position each Entity's icon in the display
                if (e.X >= 0 && e.X < _sizeX && e.Y >= 0 && e.Y < _sizeY)
                {
                    display[(int)e.X, (int)e.Y] = e.Icon;
                }

            }
            for (int y = 0; y<_sizeY; y++)
            {
                for(int x = 0; x < _sizeX; x++)
                {
                    Console.Write(display[x, y]);
                }
                Console.WriteLine();
            }
        }

        //Add an entity
        public void AddEntity(Entity entity)
        {
            _entities.Add(entity);
            entity.TheScene = this;
        }

        //Remove an entity
        public void RemoveEntity(Entity entity)
        {
            _entities.Remove(entity);
            entity.TheScene = null;
        }

        //Clear the scene of entities
        public void ClearEntities()
        {
            foreach(Entity e in _entities)
            {
                e.TheScene = null;
            }
            _entities.Clear();
        }

        //Returns whither there is a solid Entity at the point
        public bool GetCollision(float x, float y)
        {
            if(x >= 0 && y <= 0 && x < _sizeX && y < _sizeY)
            {
                return _collision[(int)x, (int)y];
            }
            return false;
        }
    }
}