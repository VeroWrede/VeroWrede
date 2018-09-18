using System;
using System.Collections.Generic;

namespace boxing
{
    class Program
    {
        static void Main(string[] args)
        {
            List<object> boxing = new List<object>{
                7,
                28,
                -1,
                true,
                "chair"
            };

            // foreach(object item in boxing) {
            //     Console.WriteLine(item);
            // };

            int temp = 0;
            foreach(object item in boxing) {
                if (item is int) {
                    int num = (int)item;
                    temp += num;
                }
                Console.WriteLine(item);
            };

            Console.WriteLine("---------------------");
            Console.WriteLine(temp);
        }
    }
}
