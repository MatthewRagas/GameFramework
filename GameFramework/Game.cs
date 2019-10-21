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
            Room southRoom = new Room();
            Room eastRoom = new Room();
            Room westRoom = new Room();

            startingRoom.North = northRoom;
            startingRoom.South = southRoom;
            startingRoom.East = eastRoom;
            startingRoom.West = westRoom;

            //northRoom.South = startingRoom;

            //southRoom.North = startingRoom;

            //eastRoom.West = startingRoom;

            //westRoom.East = startingRoom;

            //Add walls to starting room
            startingRoom.AddEntity(new Wall(0, 0));
            startingRoom.AddEntity(new Wall(1, 1));
            startingRoom.AddEntity(new Wall(2, 1));
            startingRoom.AddEntity(new Wall(3, 2));
            startingRoom.AddEntity(new Wall(4, 3));
            startingRoom.AddEntity(new Wall(5, 4));
            //Create Player and position it
            Player player = new Player('@');
            player.X = 0;
            player.Y = 0;

            Entity enemy = new Entity('e');
            enemy.X = 1;
            enemy.Y = 1;

            startingRoom.AddEntity(player);
            northRoom.AddEntity(enemy);

            _currentScene = startingRoom;
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
            }
        }
    }
}
