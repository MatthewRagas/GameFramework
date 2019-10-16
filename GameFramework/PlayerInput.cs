using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameFramework
{    
    static class PlayerInput
    {
        private delegate void KeyEvent(ConsoleKey Key);

        private static KeyEvent OnKeyPress;

        public static void AddKeyEvent(Event action, ConsoleKey key)
        {
            void KeyPressed(ConsoleKey keyPress)
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
            ConsoleKey inputKey = Console.ReadKey().Key;
            OnKeyPress(inputKey);
        }
    }
}
