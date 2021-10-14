using System;

namespace Snake
{
    internal enum Direction
    {
        Up,
        Down,
        Left,
        Right
    };
    
    internal class SnakeMap :Matrix
    {
        private static readonly Direction[] AllDirections = 
            {Direction.Up, Direction.Down, Direction.Left, Direction.Right};
        private int[] _snakeHead;
        private Direction _heading;
        
        internal SnakeMap(int row, int column) : base(row, column)
        {
            var rand =new Random();
            _heading = AllDirections[rand.Next(0,4)];
            _snakeHead = new[] {rand.Next(0, Rows), rand.Next(0, Columns)};
            Data[_snakeHead[0], _snakeHead[1]] = 1;
            int[] newFood = new int[2];
            do
            {
                newFood[0] = rand.Next(0, Rows);
                newFood[1] = rand.Next(0, Columns);
            } while (Data[newFood[0],newFood[1]] != 0);
            Data[newFood[0], newFood[1]] = -1;
        }

        internal void RefreshMap()
        {
            int[] newHead = {_snakeHead[0],_snakeHead[1]};
            switch (_heading)
            {
                case Direction.Up:
                    newHead[0] = (newHead[0]+Rows - 1) % Rows;
                    break;
                case Direction.Down:
                    newHead[0] = (newHead[0] + 1) % Rows;
                    break;
                case Direction.Left:
                    newHead[1] = (newHead[1]+Columns - 1) % Rows;
                    break;
                case Direction.Right:
                    newHead[1] = (newHead[1] + 1) % Rows;
                    break;
            }

            if (Data[newHead[0], newHead[1]] > 0)
            {
                Dead();
                throw new Exception("Dead.\n");
            }
            else if(Data[newHead[0], newHead[1]]<0)
            {
                Data[newHead[0], newHead[1]] = Data[_snakeHead[0], _snakeHead[1]] + 1;
                int[] newFood = new int[2];
                var rand = new Random();
                do
                {
                    newFood[0] = rand.Next(0, Rows);
                    newFood[1] = rand.Next(0, Columns);
                } while (Data[newFood[0],newFood[1]] != 0);
                Data[newFood[0], newFood[1]] = -1;
                _snakeHead = newHead;
            }
            else
            {
                Data[newHead[0], newHead[1]] = Data[_snakeHead[0], _snakeHead[1]]+1;
                for (int i = 0; i < Rows;i++)
                {
                    for (int j = 0; j < Columns; j++)
                    {
                        if(Data[i,j]>0)
                        {
                            Data[i, j] -= 1;
                        }
                    }
                }
                _snakeHead = newHead;
            }
        }

        internal void Operate(ConsoleKeyInfo key)
        {
            
            switch (key.Key)
            {
                case ConsoleKey.W:
                    _heading = Direction.Up;
                    break;
                case ConsoleKey.A:
                    _heading = Direction.Left;
                    break;
                case ConsoleKey.S:
                    _heading = Direction.Down;
                    break;
                case ConsoleKey.D:
                    _heading = Direction.Right;
                    break;
                case ConsoleKey.Escape:
                    throw new Exception("Escaped.\n");
            }
        }
        internal void Dead()
        {
            
        }
    }
}