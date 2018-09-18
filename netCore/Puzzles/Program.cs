using System;

namespace Puzzles
{
    class Program
    {
        static void Main(string[] args)
        {
            Flip(3);
        }

        public static void Names() {
            string[] names = new string[5] {"Todd", "tiffany", "cara", "Geneva", "Paris"};
            Random rand = new Random();
            
        }

        public static void Flip(int num) {
            Random rand = new Random();
            Console.WriteLine("Tossing....");
            int i = 0;
            while (i < num) {
                int coin = rand.Next(1,3);
                if( coin == 1) {
                    Console.WriteLine("Tail");
                } else {
                    Console.WriteLine("Head");
                };
                i ++;
            };
        }

        public static void FlipOne() {
            Random rand = new Random();
            Console.WriteLine("Tossing....");
            int coin = rand.Next(1,3);
            if( coin == 1) {
                Console.WriteLine("Tail");
            } else {
                Console.WriteLine("Head");
            };
        }

        public static void RandArr() {
            int[] arr = new int[10];
            Random rand = new Random();
            int i = 0;
            while (i < 10) {
                arr[i] = rand.Next(5, 26);
                i ++;
            };
            int max = arr[0];
            int min = arr[0];
            int sum = 0;
            foreach (int num in arr) {
                if (num < min) {
                    min = num;
                };
                if (num > max) {
                    max = num;
                };
                sum += num;
            };
            Console.WriteLine(max);
            Console.WriteLine(min);
            Console.WriteLine(sum);

        }
    }
}
