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
        public float Speed { get; set; } = 0.5f;

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

        public void Move()
        {
            switch (_facing)
            {
                case Direction.North:
                    MoveUp();
                    break;
                case Direction.South:
                    MoveDown();
                    break;
                case Direction.East:
                    MoveRight();
                    break;
                case Direction.West:
                    MoveLeft();
                    break;
            }

        }

        private void MoveUp()
        {
            if (!TheScene.GetCollision(XAbsolute, Sprite.Top - Speed))
            {
                YVelocity = -Speed;
            }
            else
            {
                YVelocity = 0f;
                _facing = Direction.South;
            }
        }

        private void MoveDown()
        {
            if (!TheScene.GetCollision(XAbsolute, Sprite.Bottom + Speed))
            {
                YVelocity = Speed;
            }
            else
            {
                YVelocity = 0f;
                _facing = Direction.North;
            }
        }

        private void MoveLeft()
        {
            if (!TheScene.GetCollision(Sprite.Left - Speed, YAbsolute))
            {
                XVelocity = Speed;
            }
            else
            {
                XVelocity = 0f;
                _facing--;
            }
        }

        private void MoveRight()
        {
            if (!TheScene.GetCollision(Sprite.Right + Speed, YAbsolute))
            {
                XVelocity = Speed;
            }
            else
            {
                XVelocity = 0f;
                _facing++;
            }
        }

        private void TouchPlayer()
        {
            List<Entity> touched;
            touched = TheScene.GetEntities(X, Y);
            bool hit = false;
            foreach(Entity e in touched)
            {
                if(e is Player)
                {
                    hit = true;
                    break;
                }
            }

            if(hit)
            {
                TheScene.RemoveEntity(this);
            }
        }
    }
}
