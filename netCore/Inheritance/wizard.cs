using System;

namespace Inheritance {
    public class Wizard : Human 
    {
        public int health;
        public int intelligence;
        public string name;

        public Wizard(string person) : base(person) 
        {  
            health = 50;
            intelligence = 25;
            name = person;
        }

        public void heal() 
        {
            health += 10;
        }

        public void firebal(object obj)
        {
            Human foe = obj as Human;
            Random rand = new Random();
            foe.health -= rand.Next(20, 51);
        }
    }
}