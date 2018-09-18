using System;
using System.Collections.Generic;

namespace CollectionsPractice
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr1 = new int[10];
            string[] arr2 = {"tim", "martin", "nikki", "sara"};
            // boolean[] arr3 = new boolean[10];
            // int i = 0;
            // while ( i <= 5) {
            //     arr3.Add(True);
            //     arr3.Add(False);
            //     i++;
            // }
            // Console.WriteLine(arr3);

            string[] iceCream = {"vanilla", "cat", "chocolate", "ginger", "banana"};
            Console.WriteLine(iceCream.Length);
            Console.WriteLine(iceCream[2]);
            iceCream[2] = "double chocolate";
            Console.WriteLine("---------------------------");

            Random rand = new Random();
            Dictionary<string, string> iceCreamDict = new Dictionary<string, string>();
            foreach(string name in arr2) {
                int ind = rand.Next(iceCream.Length);
                string val = iceCream[ind];
                iceCreamDict.Add(name, val);
            };
            foreach(KeyValuePair<string, string> entry in iceCreamDict){
                Console.WriteLine(entry.Key + " - " + entry.Value);
            }
        }
    }
}
 