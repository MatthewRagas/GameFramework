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

        private Scene _currentScene;
        public Game()
        {
            _currentScene = new Scene();            
        }

        public Game(Scene newScene)
        {

        }

        public void Run()
        {
           _currentScene.AddEntity(new Wall(0,0));
            _currentScene.AddEntity(new Wall(1,0));
            _currentScene.AddEntity(new Wall(2,0));
            _currentScene.AddEntity(new Wall(3,0));
            _currentScene.AddEntity(new Wall(4,0));
            _currentScene.AddEntity(new Wall(5,0));

            Player player = new Player('@');
            player.X = 0;
            player.Y = 0;

            Entity enemy = new Entity('e');
            enemy.X = 0;
            enemy.Y = 0;       

            _currentScene.AddEntity(player);
            _currentScene.AddEntity(enemy);

            _currentScene.Start();

            //Loop until game is over
            while(!gameOver)
            {
                _currentScene.Update();
                _currentScene.Draw();
                PlayerInput.ReadKey();
            }
        }

        public Scene CurrenScene
        {
            get
            {
                return _currentScene;
            }
        }
    }
}
