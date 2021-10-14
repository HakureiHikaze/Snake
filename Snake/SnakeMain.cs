
using System;
using System.Text.Encodings.Web;

namespace Snake
{
    class SnakeMain
    {
        static void Main(string[] args)
        {
            var a =int.Parse(Console.In.ReadLine() ?? "8");
            var b =int.Parse(Console.In.ReadLine() ?? "8");
            SnakeMap test = new SnakeMap(a, b);
            try
            {
                while (true)
                {
                    Console.Clear();
                    test.Print();
                    test.Operate(Console.ReadKey(true));
                    test.RefreshMap();
                }
            }
            catch (Exception e)
            {
                Console.Out.WriteLine(e.Message);
            }
        }
    }
}
