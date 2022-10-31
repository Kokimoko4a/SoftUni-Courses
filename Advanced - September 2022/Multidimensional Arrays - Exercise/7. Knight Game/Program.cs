using System;

namespace _7._Knight_Game
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            char[,] matrix = new char[size, size];
            int removedKnights = 0;
          

            if (size<3)
            {
                Console.WriteLine(0);
                return;
            }

            for (int row = 0; row < size; row++)
            {
                string units = Console.ReadLine();

                for (int col = 0; col < size; col++)
                {
                    matrix[row, col] = units[col];
                }
            }

            while (true)
            {
                int mostAttacking = 0;
                int rowOfKnight = 0;
                int colOfKnight = 0;

                for (int row = 0; row < size; row++)
                {                  
                    for (int col = 0; col < size; col++)
                    {
                        if (matrix[row,col] == 'K')
                        {
                            int attackedKnights = CountAttackedKnights(matrix, row, col, size);

                            if (attackedKnights>mostAttacking)
                            {
                                mostAttacking = attackedKnights;
                                rowOfKnight = row;
                                colOfKnight = col;
                            }
                        }
                    }
                }

                if (mostAttacking == 0 )
                {
                    break;
                }

                else
                {
                    matrix[rowOfKnight, colOfKnight] = '0';
                    removedKnights++;
                }
            }

            Console.WriteLine(removedKnights);
        }

        private static int CountAttackedKnights(char[,] matrix, int row, int col, int size)
        {
            int attackedKnights = 0;

            //horizontal left -up
            if (CellValid(row-1,col-2,size))
            {
                if (matrix[row-1,col-2] == 'K')
                {
                    attackedKnights++;
                }
            }

            //hor left-down
            if (CellValid(row + 1, col - 2, size))
            {
                if (matrix[row + 1, col - 2] == 'K')
                {
                    attackedKnights++;
                }
            }

            //hor right - up
            if (CellValid(row - 1, col + 2, size))
            {
                if (matrix[row - 1, col + 2] == 'K')
                {
                    attackedKnights++;
                }
            }

            // hor right - down
            if (CellValid(row + 1, col + 2, size))
            {
                if (matrix[row + 1, col + 2] == 'K')
                {
                    attackedKnights++;
                }
            }

            // ver up left
            if (CellValid(row - 2, col - 1, size))
            {
                if (matrix[row - 2, col - 1] == 'K')
                {
                    attackedKnights++;
                }
            }


            // ver down left
            if (CellValid(row + 2, col - 1, size))
            {
                if (matrix[row + 2, col - 1] == 'K')
                {
                    attackedKnights++;
                }
            }

            //ver up right
            if (CellValid(row - 2, col + 1, size))
            {
                if (matrix[row - 2, col + 1] == 'K')
                {
                    attackedKnights++;
                }
            }

            // ver down right
            if (CellValid(row + 2, col + 1, size))
            {
                if (matrix[row + 2, col + 1] == 'K')
                {
                    attackedKnights++;
                }
            }

            return attackedKnights;
        }

        private static bool CellValid(int row, int col, int size)
        {
            return row>=0 && row < size && col >= 0 && col<size;
        }
    }
}
