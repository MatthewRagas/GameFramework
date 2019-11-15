using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace GameFramework
{
    class Player : Entity
    {

        private PlayerInput _input = new PlayerInput();
        private Entity _sword = new Entity('/', "sword0.png");

        public Entity Sword
        {
            get { return _sword; }
        }

        public Player() : this('@', "survivor-idle_handgun_0.png")
        {

        }

        public Player(string imageName) : this('@',imageName)
        {
                       
        }

        public Player(char icon) : this(icon, "survivor-idle_handgun_0.png")
        {
                                         
        }

        public Player(char icon, string imageName) : base(icon, imageName)
        {
            _input.AddKeyEvent(MoveRight, 100);//d
            _input.AddKeyEvent(MoveLeft, 97);//a
            _input.AddKeyEvent(MoveUp, 119);//w
            _input.AddKeyEvent(MoveDown, 115);//s 
            _input.AddKeyEvent(DetachSword, 113);//q
            _input.AddKeyEvent(AttachSword, 101);//e

            OnUpdate += _input.ReadKey;
            OnUpdate += Orbit;
            OnStart += CreateSword;
            OnStart += AttachSword;
        }

        private void CreateSword()
        {            
            TheScene.AddEntity(_sword);
            _sword.X = X;
            _sword.Y = Y;
        }

        private void AttachSword()
        {
            //if(_sword.TheScene != TheScene || GetDistance(_sword) > 1)
            if(!Hitbox.Overlaps(_sword.Hitbox))
            {
                return;
            }

            AddChild(_sword);
            _sword.X = 0.5f;
            _sword.Y = 0.5f;
        }

        private void DetachSword()
        {
            if (_sword.TheScene != TheScene)
            {
                return;
            }
            RemoveChild(_sword);
        }
        
        private void Orbit(float deltaTime)
        {
            foreach(Entity child in _children)
            {
                //child.Rotate(1.0f);
            }

            Rotate(0.5f * deltaTime);
        }

        private void MoveRight()
        {
            if (X + 1 >= TheScene.SizeX)
            {
               if (TheScene is Room)
               {
                   Room dest = (Room)TheScene;
                   Travel(dest.East);
               }
                   X = 0;
            }                        
            else if(!TheScene.GetCollision(X + 1, Y))
            {
                X++;
            }
            
        }
       
        private void MoveLeft()
        {
            if (X - 1 < 0)
            {
                if (TheScene is Room)
                {
                    Room dest = (Room)TheScene;
                    Travel(dest.West);
                }
                X = TheScene.SizeX - 1;
            }
            else if (!TheScene.GetCollision(X - 1, Y))
            {
                X--;
            }
            
        }

        private void MoveUp()
        {
            if(Y - 1 < 0)
            {
                if(TheScene is Room)
                {
                    Room dest = (Room)TheScene;
                    Travel(dest.North);
                }
                Y = TheScene.SizeY - 1;
            }
            else if (!TheScene.GetCollision(X, Y - 1))
            {
                Y--;
            }
        }

        private void MoveDown()
        {
            if (Y + 1 >= TheScene.SizeY)
            {
                if (TheScene is Room)
                {
                    Room dest = (Room)TheScene;
                    Travel(dest.South);
                }
                Y = 0;
            }
            else if (!TheScene.GetCollision(X, Y + 1))
            {
                Y++;
            }
        }

        //private void Exit()
        //{
        //    Game.gameOver = true;
        //}
        
        //Move the Player to the destination room and change the Scene
        private void Travel(Room destination)
        {
            if(destination == null)
            {
                return;
            }

            //If the Player is holding the sword
            if(_sword.Parent == this)
            {
                //Remove the sword from the current Room
                TheScene.RemoveEntity(_sword);
                //Add the sword to the current Room
                TheScene.AddEntity(_sword);
            }

            TheScene.RemoveEntity(this);
            destination.AddEntity(this);
            Game.CurrentScene = destination;
        }
    }
}
