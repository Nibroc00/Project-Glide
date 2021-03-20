using System;
using System.Timers;

namespace Project_Glide
{
    class glide
    {
        // private static System.Timers.Timer masterTimer;
        // private static void SetTimer() {
        // // Create a timer with a two second interval.
        // aTimer = new System.Timers.Timer(200);
        // // Hook up the Elapsed event for the timer. 
        // aTimer.Elapsed += OnTimedEvent;
        // aTimer.AutoReset = true;
        // aTimer.Enabled = true;
        // }

        

        static void Main(string[] args)
        {
            System.Timers.Timer aTimer = new System.Timers.Timer();
            aTimer.Elapsed += new ElapsedEventHandler(OnTimedEvent);
            aTimer.Interval = 200;
            aTimer.Enabled = true;
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

        //Put code to be executed every 200 milliseconds in here
        private static void OnTimedEvent(object source, ElapsedEventArgs e) {
            Console.WriteLine('A');
        }
    }
}
