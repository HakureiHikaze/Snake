
using System;
using System.Threading;

namespace Snake
{
    static class SnakeMain
    {
        static void Main(string[] args)
        {
            Console.Out.WriteLine("WASD to control.");
            Console.Out.WriteLine("Map width:");
            var width =int.Parse(Console.In.ReadLine() ?? "8");
            Console.Out.WriteLine("Map height:");
            var height =int.Parse(Console.In.ReadLine() ?? "8");
            Console.Out.WriteLine("Refresh rate:");
            var rate =int.Parse(Console.In.ReadLine() ?? "1000");
            SnakeMap test = new SnakeMap(width, height);
            try
            {
                while (true)
                {
                    Console.Clear();
                    Console.Out.WriteLine("Score: {0}", test.GetScore());
                    test.Print();
                    Thread.Sleep(rate);
                    if (Console.KeyAvailable)
                    {
                        var buffer = Console.ReadKey(true);
                        test.Operate(buffer);
                    }
                    test.RefreshMap();
                    
                }
            }
            catch (Exception e)
            {
                Console.Out.WriteLine(e.Message);
            }
            Console.Out.WriteLine("Type any key to escape.");
            Console.ReadKey();
        }
    }
}
