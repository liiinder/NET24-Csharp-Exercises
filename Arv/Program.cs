Dog hund = new Dog() { Name = "Bosse" };
Cat katt = new Cat() { Name = "Pelle" };
Dog hund2 = new Dog() { Name = "Kenzo" };

Puppy valp = new Puppy() { Name = "Fido" };

Console.WriteLine("\nValp äter...");
valp.Eat();

Mammal[] mammals = { valp };

mammals[0].Eat();

abstract class Animal
{
    required public string Name { get; set; } // required, då måste objektet initieras med värdet
    protected int Age { get; set; }
    public Animal() { Age = 0; }
    public void Birthday() => Age++;
    public void Info() => Console.WriteLine($"{Name} är {Age} år gammal");
    public virtual void Eat()
    {
        Console.WriteLine("Djuret äter");
    }
    private void Dream() { }

    public abstract void Hungry();
}

class Fish : Animal
{
    public override void Hungry()
    {
        Console.WriteLine("Hungrig");
        //throw new NotImplementedException();
    }
    public void Hungry(string test)
    {
        Console.WriteLine($"Sugen på {test}");
        //throw new NotImplementedException();
    }

    public void Swim() { }
}

class Mammal : Animal
{
    public void Run() { }
    public override void Eat()
    {
        Console.WriteLine("Mammal äter");
    }

    public override void Hungry()
    {
        throw new NotImplementedException();
    }
}

class Cat : Mammal
{
    public void Meow() { }
}

class Dog : Mammal
{
    public void Bark() { }
    //public override void Eat()
    new public void Eat()
    {
        Console.WriteLine("Hunden äter");
    }
}

class Puppy : Dog
{
    
}