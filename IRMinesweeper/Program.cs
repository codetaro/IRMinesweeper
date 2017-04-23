using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRMinesweeper
{
    class Program
    {
        // Get number of adjacent mines on each tile
        static List<Hint> GetHints(List<Mine> mines)
        {
            List<Hint> hints = new List<Hint>();
            foreach (Mine mine in mines)
            {
                int row = mine.Pos.Item1;
                int col = mine.Pos.Item2;

                // All adjacent tiles around a mine
                Hint[] adjacent_tiles = {
                    new Hint(row-1, col-1),
                    new Hint(row-1, col),
                    new Hint(row-1, col+1),
                    new Hint(row, col-1),
                    new Hint(row, col+1),
                    new Hint(row+1, col-1),
                    new Hint(row+1, col),
                    new Hint(row+1, col+1)
                };

                // Set the number of adjacent mines for each tile
                foreach (Hint tile in adjacent_tiles)
                {
                    if (hints.IndexOf(tile) == -1)
                    {
                        hints.Add(tile);
                    }
                    else
                    {
                        int idx = hints.IndexOf(tile);
                        hints[idx].Adjacent_mines += 1;
                    }
                }
            }

            return hints;
        }

        // Print the output on screen with mines and hints
        static void Output(int rows, int cols, List<Hint> hints, List<Mine> mines)
        {
            char[,] field_out = new char[rows,cols];
            // Initiate the panel with 0 hint on each tile
            for (int i = 0; i < rows; i++)
                for (int j = 0; j < cols; j++)
                    field_out[i, j] = '0';
            // Set hints on tiles
            for (int i = 1; i <= rows; i++)
            {
                for (int j = 1; j <= cols; j++)
                {
                    Hint hint = new Hint(i, j);
                    int idx = hints.IndexOf(hint);
                    if (idx != -1)
                    {
                        hint = hints[idx];
                        field_out[i - 1, j - 1] = hint.Adjacent_mines.ToString()[0];
                    }
                }
            }
            // Set mines on tiles
            foreach (Mine mine in mines)
            {
                int row = mine.Pos.Item1 - 1;
                int col = mine.Pos.Item2 - 1;

                field_out[row, col] = '*';
            }
            // Print out the result on screen
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    Console.Write(field_out[i, j]);
                }
                Console.WriteLine();
            }
        }

        static void Main(string[] args)
        {
            Console.WriteLine("The input: ");
            List<Mine> mines = new List<Mine>();
            string[] field_set = Console.ReadLine().Split();
            int num_row = Convert.ToInt32(field_set[0]);
            int num_col = Convert.ToInt32(field_set[1]);

            for (int i = 1; i <= num_row; i++)
            {
                string line = Console.ReadLine();
                for (int j = 1; j <= num_col; j++)
                {
                    if (line[j - 1] == '*')
                    {
                        mines.Add(new Mine(i, j));
                    }
                }
            }

            List<Hint> hints = GetHints(mines);

            Console.WriteLine("Will return the output ");
            Output(num_row, num_col, hints, mines);
        }
    }
}
