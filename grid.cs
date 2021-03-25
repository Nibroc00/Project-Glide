using System;


namespace Project_Glide {
    public class grid {

//-------------------Class Elements/Variables------------------------------------------------------------------------------------------------------------------------------

        //player values
        bool alive = true;
        int JumperPosition = 5;
        int JumpCounter = 0;
        int score = 0;

        //obstacle values
        public int ObstacleCounter = 10;

        //grid values
        char[,] GridArray = new char[6, 25] {
            {' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' '}, 
            {' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' '},
            {' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' '},
            {' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' '},
            {' ', '☺', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' '},
            {' ', '║', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' '}
        };

//-------------------------------------------------------------------------------------------------------------------------------------------------




//------------------Functions-------------------------------------------------------------------------------------------------------------------------------

        public void displayGrid()
        {
            Console.WriteLine("___________________________" + "    Score: " + score);
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
            if (JumpCounter <= 0) {
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
            random = r.Next(1,4);
            //random chance to pick from 3 values. Those values correspond to aerial, ground, and tall ground obstacles
            switch (random) {
                // Spawn ground 1 tall, spawn only on row 5 column 24
                case 1:
                    GridArray[5, 24] = '█';
                    break;
                // Spawn ground 2 tall, spawn only on row 4 column 24
                case 2:
                    GridArray[5, 24] = '█';
                    GridArray[4, 24] = '▄';
                    break;
                // Spawn flyer, can spawn on rows 4-2 column 24
                case 3:
                    int flyerSpawn = 0;
                    Random flyerR = new Random();
                    flyerSpawn = flyerR.Next(2,5);
                    // Spawn Flyer on row 2 column 24
                    if ( flyerSpawn == 2)
                    {
                        GridArray[2, 24] = '■';
                    }
                    // Spawn Flyer on row 3 column 24
                    else if ( flyerSpawn == 3)
                    {
                        GridArray[3, 24] = '■';
                    }
                    // Spawn Flyer on row 4 column 24
                    else
                    {
                        GridArray[4, 24] = '■';
                    }
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
                    // Deletes the obstacle from the grid
                    if (j == 0 && (GridArray[i,j] != ' ' && GridArray[i,j] != '☺' && GridArray[i,j] != '║')) {
                        GridArray[i, j] = ' ';
                        score += 5;
                    }
                    //if statement ignores these characters: ' ', '☺', '║'
                    if (GridArray[i,j] != ' ' && GridArray[i,j] != '☺' && GridArray[i,j] != '║') {
                        // Player hit obstacle and died, end game.
                        if (GridArray[i, j - 1] == '☺' || GridArray[i, j - 1] == '║')
                        {
                            alive = false;
                        }
                    //if statement ignores these characters: ' ', '☺', '║'
                    else if (GridArray[i,j] != ' ' || GridArray[i,j] != '☺' || GridArray[i,j] != '║') {
                        //move obstacles
                            if (GridArray[i, j] == '■')
                            {
                                GridArray[i - 0, j - 1] = '■';
                                GridArray[i, j] = ' ';
                            }
                            if (GridArray[i, j] == '▄')
                            {
                                GridArray[i - 0, j - 1] = '▄';
                                GridArray[i, j] = ' ';
                            }
                            if (GridArray[i, j] == '█')
                            {
                                GridArray[i - 0, j - 1] = '█';
                                GridArray[i, j] = ' ';
                            }
                        }
                    }
                    
                    
                    
                }
            }
            ObstacleCounter--;
            if (ObstacleCounter <= 0) {
                int randomSpawn = 0;
                Random chance = new Random();
                randomSpawn = chance.Next(1,5);
                if (randomSpawn == 3)
                {
                    AddObstacle();
                    ObstacleCounter = 10;
                }
            }
        }

        public void UpdateScore()
        {
            score++;
        }

        public bool getPlayerStatus() {
            return alive;
        }

        // public void alivePlayerStatus() {
        //     alive = true;
        // }

        // public void clearGrid()
        // {
        //     for(int i = 0; i < GridArray.GetLength(0); i++)
        //     {
        //         for(int j = 0; j < GridArray.GetLength(1); j++)
        //         {
        //             GridArray[i,j] = ' ';
        //         }
                
        //     }
        //     GridArray[5,1] = '║';
        //     GridArray[4,1] = '☺';
        //     JumpCounter = 0;
        //     ObstacleCounter = 10;
        // }
//-------------------------------------------------------------------------------------------------------------------------------------------------


    }
}
