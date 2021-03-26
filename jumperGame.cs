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
        System.Timers.Timer ScoreTimer = new System.Timers.Timer();

//-------------------------------------------------------------------------------------------------------------------------------------------------
        



//--------------------Timer Events---------------------------------------------------------------------------------------------------------------

        private void MasterOnTimedEvent(object source, ElapsedEventArgs e) {   
            // System.Threading.Thread.Sleep(5);
            if (!display.getPlayerStatus()) {
                Console.Clear();
                display.displayGrid();
                Stop();
                Console.WriteLine("Dead, better luck next time!");
                Console.WriteLine("Press Q to quit.");
                Console.WriteLine("Press R to restart the game.");
            }
            else{
                Console.Clear();
                display.displayGrid();
                // Console.writeline(input);
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

        private void ScoreOnTimedEvent(object source, ElapsedEventArgs e)
        {
            display.UpdateScore();
        }

//-------------------------------------------------------------------------------------------------------------------------------------------------------




//----------------Functions------------------------------------------------------------------------------------------------------------------------------------

        public void setInput(ConsoleKeyInfo a) {
            input = a;
        }

        public void Start() {
            MasterTimer.Elapsed += new ElapsedEventHandler(MasterOnTimedEvent);
            //number of milliseconds between each interval
            MasterTimer.Interval =  40;
            MasterTimer.Enabled = true;

            ObstacleTimer.Elapsed += new ElapsedEventHandler(ObstacleOnTimedEvent);
            //number of milliseconds between each interval
            ObstacleTimer.Interval = 80;
            ObstacleTimer.Enabled = true;

            JumperTimer.Elapsed += new ElapsedEventHandler(JumperOnTimedEvent);
            //number of milliseconds between each interval
            JumperTimer.Interval = 150;
            JumperTimer.Enabled = true;

            ScoreTimer.Elapsed += new ElapsedEventHandler(ScoreOnTimedEvent);
            //number of milliseconds for each individual point
            ScoreTimer.Interval = 585;
            ScoreTimer.Enabled = true;
        }

        public void Restart() 
        {
            // Console.Clear();
            // display.clearGrid();
            // display.alivePlayerStatus();
            display = new grid();
            Resume();
        }

        public void Resume ()
        {
            MasterTimer.Enabled = true;
            ObstacleTimer.Enabled = true;
            JumperTimer.Enabled = true;
            ScoreTimer.Enabled = true;
        }

        public void Stop() {
            MasterTimer.Enabled = false;
            ObstacleTimer.Enabled = false;
            JumperTimer.Enabled = false;
            ScoreTimer.Enabled = false;
            
        }

//----------------------------------------------------------------------------------------------------------------------------------------------------



//----------Constructors------------------------------------------------------------------------------------------------------------------------------------------

        // public jumperGame (ref grid a) {
        //     display = a;
        // }

//----------------------------------------------------------------------------------------------------------------------------------------------------

    }
}