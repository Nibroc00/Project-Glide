using System;
using System.Timers;

namespace Project_Glide
{
    class glide
    {
        static void Main(string[] args)
        {
            //creates a new timer class
            System.Timers.Timer masterTimer = new System.Timers.Timer();
            masterTimer.Elapsed += new ElapsedEventHandler(OnTimedEvent);
            //number of milliseconds between each interval
            masterTimer.Interval = 200;
            masterTimer.Enabled = true;

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
                        break;
                    }
                }
            }
        }

        //Put code to be executed every X amount of milliseconds in here
        private static void OnTimedEvent(object source, ElapsedEventArgs e) {
            Console.WriteLine('A');
        }
    }
}
