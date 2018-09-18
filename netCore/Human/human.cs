public class AHuman {

    public string Name;
    public double Strength = 3;
    public double Intelligence = 3;
    public int Dexterity = 3;
    public int Health = 100;

    // public AHuman(string name) => Name = name;
    // public string Name 
    // {
    //     get => name;
    //     set => name = value;
    // }

    public AHuman(string name, double strength, double intelligence, int dexterity, int health)
    {
        Name = name;
        Strength = strength;
        Intelligence = intelligence;
        Dexterity = dexterity;
        Health = health;
    }

    public void Attack(AHuman victim)
    {
        victim.Health -= Health * 5;
    }

}