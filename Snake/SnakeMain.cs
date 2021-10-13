
using System;

namespace Snake
{
    class SnakeMain
    {
        static void Main(string[] args)
        {
            var i1 = Console.In.ReadLine();
            var i2 = Console.In.ReadLine();
            var r = int.Parse( (i1 !="" ? i1: "4") ?? "4");
            var c = int.Parse( (i2 !="" ? i1: "4") ?? "4");
            Matrix test = new SnakeMap(r,c);
            test.Print();
            Console.Out.WriteLine("{0}", ((-2)*2+1)%2);
        }
    }
}
