using System;

    public class grid
    {
        public grid()
        {

        }


        private char[,] gridInit()
        {
            char[,] gridArray = new char[6,25];

            for(int i = 0; i < 6; i++)
            {
                for(int j = 0; j < 25; j++)
                {
                    gridArray[i,j] = '.';
                
                }
                
            }
            return gridArray;
        }

        public void displayGrid()
        {
            char[,] gridArray = gridInit();

            for(int i = 0; i < gridArray.GetLength(0); i++)
            {
                for(int j = 0; j < gridArray.GetLength(1); j++)
                {
                    Console.Write(gridArray[i,j]);
                    
                }
                Console.WriteLine();
            
            }
        }
    }
