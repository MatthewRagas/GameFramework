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

            OnUpdate += _input.ReadKey;
            OnUpdate += Orbit;
        }
        
        private void Orbit()
        {
            foreach(Entity child in _children)
            {
                child.Rotate(1.0f);
            }

            Rotate(0.5f);
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

            TheScene.RemoveEntity(this);
            destination.AddEntity(this);
            Game.CurrentScene = destination;
        }
    }
}
