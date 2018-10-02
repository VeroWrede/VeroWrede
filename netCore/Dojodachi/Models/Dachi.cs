using System.ComponentModel.DataAnnotations;
using System;

namespace Dojodachi.Models
{
    public class Dachi{
        public string Name;
        public int Happiness { get; set; }
        public int Energy { get; set; }
        public int Fullness { get; set; }
        public int Meals { get; set; }

        public Dachi()
        {
            Name = "Albert";
            Happiness = 20;
            Energy = 50;
            Fullness = 20;
            Meals = 3;
        }
        public void Feed(int Meals, int Fullness)
        {
            if (Meals == 0)
            {
                //turn this into a warning popup
                Console.WriteLine("No more food, go work!!");
            } else{
                Random rand = new Random();
                int filling = 0;
                if (Energy <= 15) //Dachi is still a kid
                {
                    filling = rand.Next(3, 11);
                }
                if (Energy > 15 && Energy <= 40) // young adult to grown up
                {
                    filling = rand.Next(7, 13);
                }
                if (Energy > 40 && Energy <= 80) //grown up
                {
                    filling = rand.Next(10 , 16);
                }
                if (Energy > 80) //old
                {
                    int fill;
                    int chance = rand.Next(1,16);
                    if (chance == 1 || chance == 15)
                    {
                        fill  = -100;
                        Console.WriteLine("accidental death by food");
                    } else if (chance % 5 == 0)
                    {
                        fill = -5;
                        Console.WriteLine("not good food for an elderly Dachi");
                    } else {
                        fill = 5;
                    }
                    filling = fill;
                }
                Meals -= 1;
                Fullness += filling;
            }
        }
        public void Play()
        {
            int joy = 0;
            Random rand = new Random();
            if (Happiness <= 33) //depressed Dachi
            {
                int chance = rand.Next(1,6);
                if ( chance == 1)
                {
                    joy = -5;
                } else {
                    joy = 2;
                }
            } else if (Happiness <= 66) // neutral Dachi
            {
                joy = 5;
            } else { // happy Dachi!
                joy = rand.Next(10, 16);
            }
            Happiness += joy;
            Energy -= 5;
        }
        public void Work()
        {
            int wear = 0;
            Random rand = new Random();
            if ( Happiness <= 33)
            {
                wear -=10;
                Happiness -= 3;
            } else if (Happiness > 33 && Happiness < 66)
            {
                wear = -5;
            } else {
                wear -= 3;
                Happiness += 1;
            }
            Meals += rand.Next(1,4);
        }
        public void Sleep()
        {
            int rest = 0;
            Random rand = new Random();
            Energy += rand.Next(10, 16);
            Fullness -= rand.Next(10, 16);
            Happiness -= 3;
            if ( Happiness > 66)
            {
                Energy += 5;
                Fullness -= 5;
            }
        }
        
    }
}