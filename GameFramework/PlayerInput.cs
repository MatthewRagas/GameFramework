using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Raylib;
using RL = Raylib.Raylib;

namespace GameFramework
{    
    static class PlayerInput
    {
        private delegate void KeyEvent(int Key);

        private static KeyEvent OnKeyPress;

        public static void AddKeyEvent(Event action, int key)
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

        public static void ReadKey()
        {
            //ConsoleKey inputKey = Console.ReadKey().Key;
            int inputKey = RL.GetKeyPressed();
            OnKeyPress(inputKey);
        }
    }
}
