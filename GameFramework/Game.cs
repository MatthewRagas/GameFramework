using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameFramework
{
    class Game
    {
        //Whether or not the game should finish running and exit
        public static bool gameOver = false;

        private static Scene _currentScene;
        public Game()
        {
            _currentScene = new Scene();            
        }

        public Game(Scene newScene)
        {

        }

        private void Init()
        {
            Room startingRoom = new Room();
            Room northRoom = new Room();

            void StartNorthRoom()
            {
                enemy.X = 4;
            }

            northRoom.OnStart += StartNorthRoom;

            Room southRoom = new Room();
            Room eastRoom = new Room();
            Room westRoom = new Room();

            //West Room
            for (int i = 0; i < westRoom.SizeX; i++)
            {
                if (i != 2)
                {
                    westRoom.AddEntity(new Wall(i, 0));
                    westRoom.AddEntity(new Wall(i, startingRoom.SizeY - 1));
                }
            }
            for (int i = 0; i < westRoom.SizeY; i++)
            {
                if (i != 2)
                {
                    westRoom.AddEntity(new Wall(0, i));
                    westRoom.AddEntity(new Wall(westRoom.SizeX - 1, i));
                }
            }
            //East Room
            for (int i = 0; i < eastRoom.SizeX; i++)
            {
                if (i != 2)
                {
                    eastRoom.AddEntity(new Wall(i, 0));
                    eastRoom.AddEntity(new Wall(i, eastRoom.SizeY - 1));
                }
            }
            for (int i = 0; i < eastRoom.SizeY; i++)
            {
                if (i != 2)
                {
                    eastRoom.AddEntity(new Wall(0, i));
                    eastRoom.AddEntity(new Wall(eastRoom.SizeX - 1, i));
                }
            }
            //South Room
            for (int i = 0; i < startingRoom.SizeX; i++)
            {
                if (i != 2)
                {
                    southRoom.AddEntity(new Wall(i, 0));
                    southRoom.AddEntity(new Wall(i, southRoom.SizeY - 1));
                }
            }
            for (int i = 0; i < southRoom.SizeY; i++)
            {
                if (i != 2)
                {
                    southRoom.AddEntity(new Wall(0, i));
                    southRoom.AddEntity(new Wall(southRoom.SizeX - 1, i));
                }
            }
            //North Room
            for (int i = 0; i < northRoom.SizeX; i++)
            {
                if(i!=2)
                {
                    northRoom.AddEntity(new Wall(i, 0));
                    northRoom.AddEntity(new Wall(i, startingRoom.SizeY - 1));
                }
            }
            for (int i = 0; i < northRoom.SizeY; i++)
            {
                northRoom.AddEntity(new Wall(northRoom.SizeX - 1, i));
                northRoom.AddEntity(new Wall(0, i));
            }

            //Starting Room
            for (int i = 0; i < startingRoom.SizeX; i++)
            {
                if (i != 2)
                {
                    startingRoom.AddEntity(new Wall(i, 0));
                    startingRoom.AddEntity(new Wall(i, startingRoom.SizeY - 1));
                }
            }
            for(int i=0;i<startingRoom.SizeY;i++)
            {
                if(i!=2)
                {
                    startingRoom.AddEntity(new Wall(0, i));
                    startingRoom.AddEntity(new Wall(startingRoom.SizeX - 1, i));
                }
            }
            startingRoom.North = northRoom;
            startingRoom.South = southRoom;
            startingRoom.East = eastRoom;
            startingRoom.West = westRoom;

            //Add walls to starting room
            
            //Create Player and position it in startingRoom
            Player player = new Player('@');
            player.X = 4;
            player.Y = 4;           


            startingRoom.AddEntity(player);
            //Add enemy to northRoom
            northRoom.AddEntity(enemy);

            CurrentScene = startingRoom;
        }

        public void Run()
        {
            Init();            

            _currentScene.Start();

            //Loop until game is over
            while(!gameOver)
            {
                _currentScene.Update();
                _currentScene.Draw();
                PlayerInput.ReadKey();
            }
        }

        public static Scene CurrentScene
        {
            get
            {
                return _currentScene;
            }
            set
            {
                _currentScene = value;
                _currentScene.Start();
            }
        }

        private Enemy enemy = new Enemy();

        
    }
}
