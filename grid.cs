using System;


namespace Project_Glide {
    public class grid {

//-------------------Class Elements/Variables------------------------------------------------------------------------------------------------------------------------------

        //player values
        bool alive = true;
        int JumperPosition = 5;
        int JumpCounter = 0;

        //obstacle values
        public int ObstacleCounter = 10;

        //grid values
        char[,] GridArray = new char[6, 25] {
            {' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' '}, 
            {' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' '},
            {' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' '},
            {' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' '},
            {' ', '1', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' '},
            {' ', '2', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' '}
        };

//-------------------------------------------------------------------------------------------------------------------------------------------------




//------------------Functions-------------------------------------------------------------------------------------------------------------------------------

        public void displayGrid()
        {
            Console.WriteLine("___________________________");
            for(int i = 0; i < GridArray.GetLength(0); i++)
            {
                Console.Write('|');
                for(int j = 0; j < GridArray.GetLength(1); j++)
                {
                    Console.Write(GridArray[i,j]);
                }
                Console.WriteLine('|');
            }
            Console.WriteLine("███████████████████████████");
        }

        public void UpdateJumper(ref ConsoleKeyInfo input) {
            if (JumpCounter == 0) {
                switch (input.Key) {
                    case ConsoleKey.Spacebar:
                        JumpCounter = 5;
                        break;
                    default:
                        break;
                }
            }
            if (JumpCounter > 0) {
                switch(JumpCounter) {
                    case 5:
                    case 4:
                        //move up
                        GridArray[JumperPosition - 2, 1] = GridArray[JumperPosition - 1, 1];
                        GridArray[JumperPosition - 1, 1] = GridArray[JumperPosition, 1];
                        GridArray[JumperPosition, 1] = ' ';
                        JumperPosition--;
                        JumpCounter--;
                        break;
                    case 3:
                        //stay the same
                        JumpCounter--;
                        break;
                    case 2:
                    case 1:
                        //move down
                        GridArray[JumperPosition + 1, 1] = GridArray[JumperPosition, 1];
                        GridArray[JumperPosition, 1] = GridArray[JumperPosition - 1, 1];
                        GridArray[JumperPosition - 1, 1] = ' ';
                        JumperPosition++;
                        JumpCounter--;
                        break;
                    default:
                        break;
                }
            }
        }

        //adds a random obstacle on the very right edge of the screen/GridArray
        public void AddObstacle() {
            int random = 0;
            Random r = new Random();
            random = r.Next(1,3);
            //random chance to pick from 3 values. Those values correspond to aerial, ground, and tall ground obstacles
            switch (random) {
                // Ground 1 tall, spawn only on row 5 column 24
                case 1:

                    break;
                // Ground 2 tall, spawn only on row 4 column 24
                case 2:

                    break;
                // Flyer, can spawn on rows 4-2 column 24
                case 3:
                
                    break;
                default:
                    break;
            }
        }
    
        public void UpdateObstacles() {
            for(int i = 0; i < GridArray.GetLength(0); i++)
            {
                for(int j = 0; j < GridArray.GetLength(1); j++)
                {
                    //if statement ignores these characters: ' ', '1', '2'
                    if (GridArray[i,j] != ' ' || GridArray[i,j] != '1' || GridArray[i,j] != '2') {
                        //move obstacles
                    }
                }
            }
            ObstacleCounter--;
            if (ObstacleCounter <= 0) {
                AddObstacle();
                ObstacleCounter = 10;
            }
        }

        public bool getPlayerStatus() {
            return alive;
        }

//-------------------------------------------------------------------------------------------------------------------------------------------------


    }
}
