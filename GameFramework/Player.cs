using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace GameFramework
{
    class Player : Entity
    {
        public Player() : base('@')
        {

        }

        public Player(string imageName) : base('@',imageName)
        {
            //Bind movement methods to the arrowkeys
            PlayerInput.AddKeyEvent(MoveRight, 100);//d
            PlayerInput.AddKeyEvent(MoveLeft, 97);//a
            PlayerInput.AddKeyEvent(MoveUp, 119);//w
            PlayerInput.AddKeyEvent(MoveDown, 115);//s            
        }

        public Player(char icon) : base(icon)
        {
           
            PlayerInput.AddKeyEvent(MoveRight, 100);//d
            PlayerInput.AddKeyEvent(MoveLeft,97);//a
            PlayerInput.AddKeyEvent(MoveUp, 119);//w
            PlayerInput.AddKeyEvent(MoveDown, 115);//s                     
        }
        


        private void MoveRight()
        {
            if (X + 1 > TheScene.SizeX)
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
            if (Y + 1 > TheScene.SizeY)
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
