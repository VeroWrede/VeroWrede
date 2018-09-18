using System;

namespace Fundamentals1
{
    class Program
    {
        static void Main(string[] args)
        {
            // for (int i = 0; i <= 255; i ++) {
            //     Console.WriteLine(i);
            // };

            // for (int i = 0; i <= 100; i++) {
            //     if ( (i % 3 == 0) || (i % 5 == 0) ) {
            //         if ( (i % 3 == 0) && (i % 5 == 0) ) {
            //             continue;
            //         } else {
            //             Console.WriteLine(i);
            //         };
            //     };
            // };

            // for (int i = 0; i <= 100; i++ ) {
            //     if ( (i % 3 == 0)  && (i % 5 != 0) ) {
            //         Console.WriteLine("fizz");
            //     };
            //     if ( (i % 3 != 0)  && (i % 5 == 0) ) {
            //         Console.WriteLine("buzz");
            //     };
            //     if ( (i % 3 == 0)  && (i % 5 == 0) ) {
            //         Console.WriteLine("fizzBuzz");
            //     };
            // }

            for (int i = 0; i <= 100; i++) {
                double temp3 = i / 3;
                Console.WriteLine(temp3);
                double temp5 = i / 5;

                // if ( (temp3 - (int)temp3 > 0) && (temp5 - (int)temp5 > 0) ) {
                //     Console.WriteLine("fizzBuzz");
                // } else if ( (temp3 - (int)temp3 > 0) ) {
                //     Console.WriteLine("fizz");
                // } else if ( (temp5 - (int)temp5 > 0)) {
                //     Console.WriteLine("buzz");
                // } else {
                //     continue;
                // };
            }
        }
    }
}
