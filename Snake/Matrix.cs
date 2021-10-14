
using System;

namespace Snake
{
    internal class Matrix
    {
        protected int[,] Data;
        protected int Rows { get; }
        protected int Columns { get; }

        internal Matrix(int row, int column)
        {
            Rows = row;
            Columns = column;
            Data = new int[Rows,Columns];
        }
        
        internal int GetElement(int row, int column)
        {
            var rowFixed = row % Rows;
            var columnFixed = column % Columns;
            return Data[rowFixed - 1 , columnFixed - 1];
        }

        internal int[] GetRow(int row)
        {
            var buffer = new int[Columns];
            for (var i = 0; i < Columns; i++)
            {
                buffer[i] = Data[row%Rows-1, i];
            }

            return buffer;
        }
        
        internal int[] GetColumn(int column)
        {
            var buffer = new int[Rows];
            for (var i = 0; i < Rows; i++)
            {
                buffer[i] = Data[i, column%Columns-1];
            }

            return buffer;
        }

        internal void Print()
        {
            Console.Out.Write("\n");
            Console.Out.Write("┏");
            for (int i = 0; i < Columns*2; i++)
            {
                Console.Out.Write("━");
            }
            Console.Out.Write("┓\n");
            for (int i = 0; i < Rows; i++)
            {
                Console.Out.Write("│");
                for (int j = 0; j < Columns; j++)
                {
                    if (Data[i, j] > 0)
                    {
                        Console.Out.Write("■");
                    }else if (Data[i, j] < 0)
                    {
                        Console.Out.Write("☆");
                    }
                    else
                    {
                        Console.Out.Write("\u3000");
                    }
                }
                Console.Out.Write("┃\n");
            }
            Console.Out.Write("┗");
            for (int i = 0; i < Columns*2; i++)
            {
                Console.Out.Write("━");
            }
            Console.Out.Write("┛\n");
        }
    }
}