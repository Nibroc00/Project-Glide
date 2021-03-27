using System;

namespace Project_Glide
{
    class glide
    {

        static void Main(string[] args) {

            // Welcom Screen
            Console.Write("Welcome to The Jumper Game \n\n Dodge obstacles by jumping (Space Bar) \n\nPress Space Bar to begin...");
            var begin = Console.ReadKey();
            while(begin != ConsoleKey.Spacebar){
                begin = Console.ReadKey();
            }
            
            
            // ConsoleKeyInfo input = Console.ReadKey(true);
            jumperGame jumper = new jumperGame();
            jumper.Start();
            jumper.Resume();
    
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
                        case ConsoleKey.Escape:
                            z = false;
                            break;
                        case ConsoleKey.R:
                            // Clear Grid and print grid
                            jumper.Restart();
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
