using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Raylib;
using RL = Raylib.Raylib;

namespace GameFramework
{
    class Game
    {
        //Whether or not the game should finish running and exit
        public static bool gameOver = false;

        private static Scene _currentScene;
        public Game()
        {
            RL.InitWindow(640, 480, "Shalom");
            RL.SetTargetFPS(15);
        }        

        private void Init()
        {
            Room startingRoom = new Room(8,6);
            Room northRoom = new Room(12,6);
            Enemy enemy = new Enemy();
            void StartNorthRoom()
            {
                enemy.X = 4;
                enemy.Y = 4;
            }

            northRoom.OnStart += StartNorthRoom;

            Room southRoom = new Room();
            Room eastRoom = new Room();
            Room westRoom = new Room();

            startingRoom.North = northRoom;
            startingRoom.South = southRoom;
            startingRoom.East = eastRoom;
            startingRoom.West = westRoom;

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

            //Add walls to starting room
            
            //Create Player and position it in startingRoom
            Player player = new Player("survivor-idle_handgun_0.png");
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
            while(!gameOver && !RL.WindowShouldClose())
            {
                _currentScene.Update();

                RL.BeginDrawing();
                RL.ClearBackground(Color.RED);
                _currentScene.Draw();
                RL.EndDrawing();

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

        

        
    }
}
