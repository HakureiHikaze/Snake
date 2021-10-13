using System;
using System.Security.Cryptography;

namespace Snake
{
    internal class SnakeMap :Matrix
    {
        private int[] SnakeHead;
        private int[] Heading;
        internal SnakeMap(int row, int column) : base(row, column)
        {
            var rand =new Random();
            Heading = new[] {rand.Next(-1,2), rand.Next(-1,2)};
            SnakeHead = new[] {rand.Next(1, Rows + 1), rand.Next(1, Columns + 1)};
        }

        internal void RefreshMap()
        {
            
            if (Data[SnakeHead[0] + Heading[0], SnakeHead[1] + Heading[1]] > 0)
            {
                Dead();
                return;
            }
            Data[SnakeHead[0] + Heading[0], SnakeHead[1] + Heading[1]] =
                Data[SnakeHead[0], SnakeHead[1]] - (Data[SnakeHead[0] + Heading[0], SnakeHead[1] + Heading[1]]*2+1)%2;
        }

        internal void Dead()
        {
            
        }
    }
}