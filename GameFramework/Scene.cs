using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Raylib;
using RL = Raylib.Raylib;

namespace GameFramework
{
    //Class Scene is responsible for updating Entities
    class Scene
    {
        public Event OnStart;
        public Event OnUpdate;
        public Event OnDraw;

        //The list of entities to remove from the scene
        private List<Entity> _removals = new List<Entity>();
        //The list of entities in the scene
        private List<Entity> _entities = new List<Entity>();

        private List<Entity> _additions = new List<Entity>();

        private int _sizeX;
        private int _sizeY;
        //Create the collision grid
        private bool[,] _collision;

        private List<Entity>[,] _tracking;

        public Scene() : this(12,6)
        {
           
        }
        public Scene(int sizeX, int sizeY)
        {
            _sizeX = sizeX;
            _sizeY = sizeY;
            _collision = new bool[_sizeX, _sizeY];
            _tracking = new List<Entity>[_sizeX, _sizeY];
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
            OnStart?.Invoke();

            foreach(Entity e in _entities)
            {
                e.Start();
            }            
        }

        public void Update()
        {
            OnUpdate?.Invoke();

            //Clear the collision grid
            _collision = new bool[_sizeX, _sizeY];

            //Clear the tracking grid            
            for(int y = 0; y < _sizeY; y++)
            {
                for(int x = 0; x < _sizeX; x++)
                {
                    _tracking[x, y] = new List<Entity>();
                }
                
            }

            //Add all the Entities readied for addition
            foreach (Entity e in _additions)
            {
                //Add e to _entities
                _entities.Add(e);
            }
            _additions.Clear();

            //Remove all the Entities readied for removal
            foreach(Entity e in _removals)
            {
                //Remove e from _entities
                _entities.Remove(e);
            }
            _removals.Clear();

            foreach(Entity e in _entities)
            {                
                //Set the Entity's collision in the collision grid
                int x = (int)e.X;
                int y = (int)e.Y;
                //Only update if the Entity is within bounds
                if(x>= 0 && y < _sizeY && y >= 0 && x < _sizeX)
                {
                    //Add the entity to the tracking grid
                    _tracking[x, y].Add(e);
                    //Only update this point in the grid if the Entity is solid
                    if(!_collision[x,y])
                    {
                        _collision[x, y] = e.Solid;
                    }
                }
            }

            foreach (Entity e in _entities)
            {
                //Call the Entity's Update events
                e.Update();
            }            
        }

        public void Draw()
        {
            OnDraw?.Invoke();

            //Clear the screen
            Console.Clear();
            
            char[,] display = new char[_sizeX, _sizeY];

            foreach (Entity e in _entities)
            {
                int x = (int)e.X;
                int y = (int)e.Y;
                //Position each Entity's icon in the display
                if (x >= 0 && x < _sizeX && y >= 0 && y < _sizeY)
                {
                    display[x, y] = e.Icon;                    
                }

            }

            //Render the display grid to the screen
            for (int y = 0; y < _sizeY; y++)
            {
                for(int x = 0; x < _sizeX; x++)
                {
                    Console.Write(display[x, y]);

                    foreach (Entity e in _tracking[x,y])
                    {
                        //RL.DrawTexture(e.Sprite, (int)(e.X * Game.SizeX),  (int)(e.Y *Game.SizeY), Color.WHITE);
                        Texture2D texture = e.Sprite;
                        Raylib.Vector2 position = new Raylib.Vector2(e.X * Game.SizeX, e.Y * Game.SizeY);
                        float rotation = e.Rotation * (float)(180.0f/Math.PI);
                        float scale = e.Size;
                        RL.DrawTextureEx(texture, position, rotation, scale, Color.WHITE);
                    }
                }
                Console.WriteLine();
            }

            foreach (Entity e in _entities)
            {
                e.Draw();
            }            
        }

        //Add an entity
        public void AddEntity(Entity entity)
        {
            _additions.Add(entity);
            entity.TheScene = this;
        }

        //Remove an entity
        public void RemoveEntity(Entity entity)
        {
            //Ready the Entity for removal
            _removals.Add(entity);
            entity.TheScene = null;
        }

        //Clear the scene of entities
        public void ClearEntities()
        {
            foreach(Entity e in _entities)
            {
                RemoveEntity(e);
            }            
        }

        //Returns whither there is a solid Entity at the point
        public bool GetCollision(float x, float y)
        {
            if(x >= 0 && y >= 0 && x < _sizeX && y < _sizeY)
            {
                return _collision[(int)x, (int)y];
            }
            else
            {
                return false;
            }            
        }

        public List<Entity> GetEntities(float x, float y)
        {
            if (x >= 0 && y >= 0 && x < _sizeX && y < _sizeY)
            {
                return _tracking[(int)x, (int)y];
            }
            else
            {
                return new List<Entity>();
            }            
        }
    }
}