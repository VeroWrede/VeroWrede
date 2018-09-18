using System;

namespace Hello
{
    class Program
    {
        static void Main(string[] args)
        {
            int a = 80;
            int b = 90;
            if ( !a.Equals(b)) {
                Console.WriteLine("NO");
            };
            Console.WriteLine(a.Equals(b));
        }
    }
}
