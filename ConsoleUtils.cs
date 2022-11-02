/* This work is a derivate of:
* Professor Mike Hadley's "Intro to C#: 30 - Adventure Game Architecture Walkthrough"
* ConsoleUtils Class
 * https://www.youtube.com/watch?v=eBadZxYe6I4&t=289s&ab_channel=MichaelHadley
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace ThreeMagi
{
    internal class ConsoleUtils
    {
        public static void WaitForKeyPress()
        {
           Console.WriteLine("(Press any key to continue.)");
            ReadKey(true);
            Console.Clear();
        }

        public static void QuitConsole()
        {
            Console.WriteLine("(Press any key to exit the game.)");
            ReadKey(true);
            Environment.Exit(0);
        }


        
    }
}
