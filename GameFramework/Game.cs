using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Raylib;
using RL = Raylib.Raylib;

namespace GameFramework
{
    class Game
    {
        //The tile size of the game
        public static readonly Vector2 UnitSize = new Vector2(34, 34);
        //public static readonly int UnitSizeX = 34;
        //public static readonly int UnitSizeY = 34;
        //Whether or not the game should finish running and exit
        public static bool gameOver = false;

        private static Scene _currentScene;
        private static Scene _nextScene;

        private Timer _gameTimer;
        public Game()
        {
            RL.InitWindow(800, 550, "Shalom");
            RL.SetTargetFPS(15);

            _gameTimer = new Timer();
        }

        public static Scene CurrentScene
        {
            get
            {
                return _currentScene;
            }
            set
            {
                _nextScene = value;
            }
        }

        private void Init()
        {
            Room startingRoom = LoadRoom("Rooms/StartingRoom.txt");
            Room northRoom = LoadRoom("Rooms/northRoom.txt");           

            Room southRoom = LoadRoom("Rooms/southRoom.txt");
            Room eastRoom = LoadRoom("Rooms/eastRoom.txt");
            Room westRoom = LoadRoom("Rooms/westRoom.txt");

            startingRoom.North = northRoom;
            startingRoom.South = southRoom;
            startingRoom.East = eastRoom;
            startingRoom.West = westRoom;            

            CurrentScene = startingRoom;
        }       

        public void Run()
        {
            Init();

            //Loop until game is over
            while(!gameOver && !RL.WindowShouldClose())
            {
                if(_currentScene != _nextScene)
                {
                    _currentScene = _nextScene;                    
                }

                _currentScene.Update(_gameTimer.GetDeltaTime());

                if (!_currentScene.Started)
                {
                    _currentScene.Start();
                }                

                RL.BeginDrawing();
                RL.ClearBackground(Color.RED);
                _currentScene.Draw();
                RL.EndDrawing();                
            }
            RL.CloseWindow();
        }       

        private Room LoadRoom(string path)
        {
            StreamReader reader = new StreamReader(path);

            int width, height;
            Int32.TryParse(reader.ReadLine(), out width);
            Int32.TryParse(reader.ReadLine(), out height);

            Room room = new Room(width, height);

            for (int y = 0; y < height; y++)
            {
                string row = reader.ReadLine();
                for (int x = 0; x < width; x++)
                {
                    char tile = row[x];
                    switch (tile)
                    {
                        case '1':
                            room.AddEntity(new Wall(x, y));
                            break;
                        case '@':
                            Player p = new Player();
                            p.X = x;
                            p.Y = y;
                            //p.Sprite.X -= 0.5f;
                            //p.Sprite.Y -= 0.5f;
                            room.AddEntity(p);
                            break;
                        case 'e':
                            Enemy e = new Enemy();
                            e.X = x;
                            e.Y = y;
                            room.AddEntity(e);
                            break;

                    }
                }
            }

            return room;
        }
    }
}
