using System;

namespace Inheritance
{
    public class Samurai : Human 
    {
        public int health;
        public int chance;

        public Samurai(string person) : base(person) 
        {
            health = 200;
        }

        public void death_blow(object obj)
        {
            Human foe = obj as Human;
            Random rand = new Random();
            // Samurai gets 2/3 chance of dealing death_blow to waek oponents
            // 1/3 chance to deal death blow to strong opponents
            chance = rand.Next(1,4);
            if (foe.health <= 50)
            {
                if(chance <= 2)
                {
                    foe.health = 0;
                }
            } else {
                if (chance = 3)
                {
                    foe.health = 1;
                }
            }
        }

        public void meditate() 
        {
            Random rand = new Random();
            chance = rand.Next(1, 5);
            // meditation takes time
            // if samuray gets spooked during meditation he/she looses 2 health
            if (chance > 3)
            {
                health = 200;
            } else {
                health -= 2;
            }
        }
    }
}