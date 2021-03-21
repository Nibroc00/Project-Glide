using System;
using System.Timers;


namespace Project_Glide {
    public class gameTimer {
        grid display;
        ConsoleKeyInfo input;
        bool grounded = true;
        int jump = 0;
        System.Timers.Timer masterTimer = new System.Timers.Timer();
        public void Start() {
            // Part 1: set up the timer for 0.2 seconds.
            masterTimer.Elapsed += new ElapsedEventHandler(OnTimedEvent);
            //number of milliseconds between each interval
            masterTimer.Interval = 100;
            masterTimer.Enabled = true;
        }
        
        public void setInput(ConsoleKeyInfo a) {
            input = a;
        }

        //Put code to be executed every X amount of milliseconds in here
        private void OnTimedEvent(object source, ElapsedEventArgs e) {
            Console.WriteLine(input.Key);
            if (grounded) {
                // var input = Console.ReadKey(true);
                switch (input.Key) {
                    case ConsoleKey.Spacebar:
                        
                        jump = 5;
                        break;
                    default:
                        break;
                }
            }
            ConsoleKeyInfo reseter = new ConsoleKeyInfo((char)ConsoleKey.RightArrow, ConsoleKey.RightArrow, false, false, false);
            input = reseter;
            Console.Clear();
            Console.WriteLine("Jump Counter: " + jump);
            grounded = display.Update(ref jump);
            display.displayGrid();
        }

        public gameTimer (ref grid a) {
            display = a;
        }

    }


}