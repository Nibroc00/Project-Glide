using System;
using System.Timers;


namespace Project_Glide {
    public class jumperGame {

//--------------------Class Elements/variables---------------------------------------------------------------------------------------------------------------
        //game grid
        grid display = new grid();

        //input from main
        ConsoleKeyInfo input;
        
        //timers
        System.Timers.Timer MasterTimer = new System.Timers.Timer();
        System.Timers.Timer ObstacleTimer = new System.Timers.Timer();
        System.Timers.Timer JumperTimer = new System.Timers.Timer();

//-------------------------------------------------------------------------------------------------------------------------------------------------
        



//--------------------Timer Events---------------------------------------------------------------------------------------------------------------

        private void MasterOnTimedEvent(object source, ElapsedEventArgs e) {   
            // System.Threading.Thread.Sleep(5);
            if (!display.getPlayerStatus()) {
                Console.Clear();
                display.displayGrid();
                Stop();
            }
            else{
                Console.Clear();
                display.displayGrid();
                // Console.WriteLine(display.ObstacleCounter);
            }
        }

        private void ObstacleOnTimedEvent(object source, ElapsedEventArgs e) {           
            display.UpdateObstacles();
        }

        private void JumperOnTimedEvent(object source, ElapsedEventArgs e) {
            display.UpdateJumper(ref input);
            ConsoleKeyInfo reseter = new ConsoleKeyInfo((char)ConsoleKey.RightArrow, ConsoleKey.RightArrow, false, false, false);
            input = reseter;
        }

//-------------------------------------------------------------------------------------------------------------------------------------------------------




//----------------Functions------------------------------------------------------------------------------------------------------------------------------------

        public void setInput(ConsoleKeyInfo a) {
            input = a;
        }

        public void Start() {
            MasterTimer.Elapsed += new ElapsedEventHandler(MasterOnTimedEvent);
            //number of milliseconds between each interval
            MasterTimer.Interval = 50;
            MasterTimer.Enabled = true;

            ObstacleTimer.Elapsed += new ElapsedEventHandler(ObstacleOnTimedEvent);
            //number of milliseconds between each interval
            ObstacleTimer.Interval = 80;
            ObstacleTimer.Enabled = true;

            JumperTimer.Elapsed += new ElapsedEventHandler(JumperOnTimedEvent);
            //number of milliseconds between each interval
            JumperTimer.Interval = 150;
            JumperTimer.Enabled = true;
        }

        public void Stop() {
            MasterTimer.Enabled = false;
            ObstacleTimer.Enabled = false;
            JumperTimer.Enabled = false;
            Console.WriteLine("Dead, better luck next time!");
            Console.WriteLine("Press Q to quit.");
        }

//----------------------------------------------------------------------------------------------------------------------------------------------------



//----------Constructors------------------------------------------------------------------------------------------------------------------------------------------

        // public jumperGame (ref grid a) {
        //     display = a;
        // }

//----------------------------------------------------------------------------------------------------------------------------------------------------

    }
}