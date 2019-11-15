using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Raylib;
using RL = Raylib.Raylib;

namespace GameFramework
{    
    class PlayerInput
    {
        private delegate void KeyEvent(int Key);

        private KeyEvent OnKeyPress;

        public void AddKeyEvent(Event action, int key)
        {
            void KeyPressed(int keyPress)
            {
                if(key == keyPress)
                {
                    action();
                }
            }
            OnKeyPress += KeyPressed;
        }

        public void ReadKey(float deltaTime)
        {
            //ConsoleKey inputKey = Console.ReadKey().Key;
            int inputKey = RL.GetKeyPressed();
            OnKeyPress(inputKey);
        }
    }
}
