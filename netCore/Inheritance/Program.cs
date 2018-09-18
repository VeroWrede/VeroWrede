using System;

namespace Inheritance
{
    class Program
    {
        static void Main(string[] args)
        {
            Human h = new Human("Mina");
            Wizard w = new Wizard("Nate");
            Ninja n = new Ninja("Wes");
            Console.WriteLine(h.health);
            Console.WriteLine(w.health);
            w.heal();
            w.firebal(h);
            Console.WriteLine(n.health);
            n.get_away();
            Console.WriteLine(n.health);
            
           

        }
    }
}
