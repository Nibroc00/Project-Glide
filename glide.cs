using System;

namespace Project_Glide
{
    class glide
    {

        static void Main(string[] args) {
            grid display = new grid();
            // ConsoleKeyInfo input = Console.ReadKey(true);
            gameTimer masterTimer = new gameTimer(ref display);
            masterTimer.Start();
    
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
                        masterTimer.setInput(input);
                        break;
                    }
                }
            }

        }
    }
}
