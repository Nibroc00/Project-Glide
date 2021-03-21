using System;


namespace Project_Glide {
    public class grid
    {

        int position = 5;
        char[,] gridArray = new char[6, 25] {
            {' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' '}, 
            {' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' '},
            {' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' '},
            {' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' '},
            {' ', '1', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' '},
            {' ', '2', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' '}
        };


        public void displayGrid()
        {
            Console.WriteLine("___________________________");
            for(int i = 0; i < gridArray.GetLength(0); i++)
            {
                Console.Write('|');
                for(int j = 0; j < gridArray.GetLength(1); j++)
                {
                    Console.Write(gridArray[i,j]);
                    
                }
                Console.WriteLine('|');
            
            }
            Console.WriteLine("███████████████████████████");
        }

        public bool Update(ref int jump) {
            // for(int i = 0; i < gridArray.GetLength(0); i++) {
            //     for(int j = 0; j < gridArray.GetLength(1); j++) {
            //         // move objects
            //     }
            // }
            if (jump > 0) {
                // Console.WriteLine(jump);
                switch(jump) {
                    case 5:
                    case 4:
                        //move up
                        Console.WriteLine("up");
                        gridArray[position - 2, 1] = gridArray[position - 1, 1];
                        gridArray[position - 1, 1] = gridArray[position, 1];
                        gridArray[position, 1] = ' ';
                        position--;
                        jump--;
                        break;
                    case 3:
                        //stay the same
                        Console.WriteLine("stay");
                        jump--;
                        break;
                    case 2:
                    case 1:
                        //move down
                        Console.WriteLine("down");
                        gridArray[position + 1, 1] = gridArray[position, 1];
                        gridArray[position, 1] = gridArray[position - 1, 1];
                        gridArray[position - 1, 1] = ' ';
                        position++;
                        jump--;
                        break;
                    default:
                        break;
                }
            }

            if (jump == 0) {
                return true;
            }
            else {
                return false;
            }

        }
    }

}
