using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameFramework
{
    class Program
    {
        static void Main(string[] args)
        {

            //Examples();                        
            Game game = new Game();
            game.Run();
        }

        static void Examples()
        {
            ////Find the Magnitude
            //Console.WriteLine(new Vector3(1, 1, 1).MagnitudeSqr());
            //Console.WriteLine(new Vector2(3, -2).MagnitudeSqr());
            //Console.WriteLine(new Vector3(-1, 1, -1).MagnitudeSqr());
            //Console.WriteLine(new Vector3(0.5f,-1f,0.25f).MagnitudeSqr());

            ////Find the Distance
            //Vector2 a = new Vector2(1, 0);
            //Vector2 b = new Vector2(0, 1);
            //Vector2 c = new Vector2(1, 1);
            //Vector2 d = new Vector2(-1, -1);
            //Vector3 e = new Vector3(2, 3, 1);
            //Vector3 f = new Vector3(-3, 1, 2);
            //Console.WriteLine(new Vector2().DotProduct(a, b));
            //Console.WriteLine(c.DotProduct(c, d));
            //Console.WriteLine(e.DotProduct(f));
            //Vector2 vec2a = new Vector2(1f, 3f);
            //Vector2 vec2b = new Vector2(0.5f, -0.25f);
            //Console.WriteLine(vec2a.AngleBetween(vec2b));  

            Vector3 up = new Vector3(0f, 1f, 0f);
            Vector3 playerLoc = new Vector3(0f, 0f, 0f);
            Vector3 enemyLoc = new Vector3(-7.5f, 0f, 9f);
            Vector3 enemyForward = new Vector3(0.857f, 0f, -0.514f);

            Vector3 enemyToPlayer = playerLoc - enemyLoc;
            Console.WriteLine("Distance from enemy to player : " + enemyToPlayer);

            if (enemyForward.DotProduct(enemyToPlayer) > 0)
            {
                Console.WriteLine("Player is infront of enemy.");
            }
            else
            {
                Console.WriteLine("Player is behind enemy.");
            }

            Vector3 enemyLeft = enemyForward.CrossProduct(up);

            if (enemyLeft.DotProduct(enemyToPlayer) > 0)
            {
                Console.WriteLine("Player is to the left of enemy.");
            }
            else
            {
                Console.WriteLine("Player is to the right enemy.");
            }

            //Is the player in the enemy's fov
            if (enemyForward.AngleBetween(enemyToPlayer) <= Math.PI / 4 ||
                enemyForward.AngleBetween(enemyToPlayer) >= 7 * Math.PI / 4)
            {
                Console.WriteLine("REEEEEEEEEEEEEEEE");
            }
        }
    }
}
