using System;

namespace Basic13
{
    class Program
    {
        static void Main(string[] args)
        {

            NtoS(new object[] { 2, 2, -4, 02, -908});
            Console.WriteLine("Hello World!");
        }

        public static void NtoS(object[] arr) {
            object Dojo = "Dojo";
            int i = 0;
            foreach(object num in arr) {
                if (num is int && (int)num < 0) {
                    arr[i] = Dojo;
                    i ++;
                } else {
                    i ++;
                };
            };
            foreach(object num in arr) {
                Console.WriteLine(num);
            };
        }

        public static void Shift(int[] arr) {
            int i = 0;
            while ( i < arr.Length - 1) {
                arr[i] = arr[i+1];
                i ++;
            };
            arr[arr.Length - 1] = 0;

            foreach(int num in arr) {
                Console.WriteLine(num);
            };
        }

        public static void MMA(int[] arr) {
            int Max = arr[0];
            int Min = arr[0];
            int Avg;
            int temp = 0;
            foreach (int num in arr) {
                temp += num;
                if (num < Min) {
                    Min = num;
                } else if (num > Max) {
                     Max = num;
                } else {
                    continue;
                };
            };
            Avg = temp / arr.Length;
            Console.WriteLine(Max);
            Console.WriteLine(Min);
            Console.WriteLine(Avg);
        }

        public static void Negs(int[] arr) {
            int i = 0;
            foreach (int num in arr) {
                if (num < 0 ) {
                    arr[i] = 0;
                };
                i ++;
            };
            foreach ( int num in arr) {
                Console.WriteLine(num);
            };
        }

        public static void Sqaure(int[] arr) {
            int i = 0;
            foreach(int num in arr) {
                arr[i] = num*num;
                i ++;
            };
            foreach(int num in arr) {
            Console.WriteLine(num);
            };
        }

        public static void GreaterThan(int limit, int[] arr) {
            int count = 0;
            foreach(int num in arr) {
                if (num > limit) {
                    count ++;
                };
            };
            Console.WriteLine(count);
        }

        public static void OddArr(int num) {
            int index = 0;
            int j = 0;
            int len;
            if (num % 2 == 0) {
                len = num /2;
            } else {
                len = (num + 1) /2;
            }
            int[] result = new int[len];           
            while ( index < len) {
                if ( j % 2 != 0) {
                    result[index] = j;
                    index ++;
                };
                j ++;
            };
            foreach (int number in result) {
            Console.WriteLine(number);
            };
        }

        public static void Avg(int[] arr) {
            int temp = 0;
            foreach (int num in arr) {
                temp += num;
            };
            int len = arr.Length;
            int result = temp / len;
            Console.WriteLine(result);
        }

        public static void Max(int[] arr) {
            int temp = arr[0];
            foreach(int num in arr) {
                if (num > temp) {
                    temp = num;
                };
            };
            Console.WriteLine(temp);
        }

        public static void IterArr(int[] arr) {
            foreach (int num in arr) {
                Console.WriteLine(num);
            };
        }

        public static void SumNums(int num) {
            int temp = 0;
            for (int i = 0; i <= num; i++) {
                Console.WriteLine(i);
                temp += i;
                Console.WriteLine(temp);
            };
        }

        public static void PrintNums(int num) {
            for (int i = 0; i <= num; i++) {
                Console.WriteLine(i);
            };
        }

        public static void PrintOddNums(int num) {
            for (int i = 0; i <= num; i++) {
                if (i % 2 != 0) {
                    Console.WriteLine(i);
                };
            };
        }
    }
}
