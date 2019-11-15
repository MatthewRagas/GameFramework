using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameFramework
{
    class Enemy : Entity
    {
        private Direction _facing;

        private float _speed = 5f;

        public float Speed
        {
            get { return _speed; }
            set { _speed = value; }
        }        

        public Enemy() : this('e', "enemy.png")
        {

        }

        public Enemy(char icon) : this(icon, "enemy.png")
        {
           
        }

        public Enemy(string imageName) : this('e', imageName)
        {

        }

        public Enemy(char icon, string imageName) : base(icon, imageName)
        {
            _facing = Direction.North;
            OnUpdate += Move;
            OnUpdate += TouchPlayer;            
        }

        public void Move(float deltaTime)
        {
            switch (_facing)
            {
                case Direction.North:
                    MoveUp(deltaTime);
                    break;
                case Direction.South:
                    MoveDown(deltaTime);
                    break;
                case Direction.East:
                    MoveRight(deltaTime);
                    break;
                case Direction.West:
                    MoveLeft(deltaTime);
                    break;
            }

        }

        private void MoveUp(float deltaTime)
        {
            if (!TheScene.GetCollision(XAbsolute, Sprite.Top - Speed * deltaTime))
            {
                YVelocity = -Speed;
            }
            else
            {
                YVelocity = 0f;
                _facing = Direction.South;
            }
        }

        private void MoveDown(float deltaTime)
        {
            if (!TheScene.GetCollision(XAbsolute, Sprite.Bottom + Speed * deltaTime))
            {
                YVelocity = Speed;
            }
            else
            {
                YVelocity = 0f;
                _facing = Direction.North;
            }
        }

        private void MoveLeft(float deltaTime)
        {
            if (!TheScene.GetCollision(Sprite.Left - Speed * deltaTime, YAbsolute))
            {
                XVelocity = Speed;
            }
            else
            {
                XVelocity = 0f;
                _facing--;
            }
        }

        private void MoveRight(float deltaTime)
        {
            if (!TheScene.GetCollision(Sprite.Right + Speed * deltaTime, YAbsolute))
            {
                XVelocity = Speed;
            }
            else
            {
                XVelocity = 0f;
                _facing++;
            }
        }

        private void TouchPlayer(float deltaTime)
        {
            List<Entity> touched = TheScene.GetEntities(X, Y);            
            bool hit = false;
            //Check if any of the are Players
            foreach (Entity e in touched)
            {
                if(e is Player)
                {
                    TheScene.RemoveEntity(this);
                    break;
                }
            }                                                    
        }
    }
}
