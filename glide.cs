using System;

namespace Project_Glide
{
    class glide
    {

        static void Main(string[] args) {
            
            // ConsoleKeyInfo input = Console.ReadKey(true);
            jumperGame jumper = new jumperGame();
            jumper.Start();
    
            //while loop boolean
            var z = true;
            //Loops until the Q key is pressed.
            Console.WriteLine("Press \'q\' to quit the sample.");
            while(z){
                if (Console.KeyAvailable) {
                    var input = Console.ReadKey(true);
                    switch (input.Key) {
                        case ConsoleKey.Q:
                            z = false;
                            break;
                    default:
                        jumper.setInput(input);
                        break;
                    }
                }
            }

        }
    }
}
