
// Code Alongs från Lektioner
sept16();

// 16 September - Intro till klasser
static void sept16()
{
    // tre olika sätt att skapa en "katt" på.
    Cat myCat = new Cat();
    myCat.name = "Pelle";
    myCat.age = 3;

    Cat myOtherCat = new Cat()
    {
        name = "Måns",
        age = 5
    };

    Cat myThirdCat = new Cat() { name = "Sven", age = 12 };

    // En array med katter.
    Cat[] cats = new Cat[] { myCat, myOtherCat, myThirdCat, new Cat() { age = 8, name = "Orvar" } };

    myCat.name = "Pelle Svanslös";
    cats[0].age = 25;

    myOtherCat.Greet();
    myOtherCat.Greet("Daniel");
    myOtherCat.Greet(myCat);

    // Loopa igenom en array med katter.
    //foreach (Cat cat in cats)
    //{
    //    Console.WriteLine($"{cat.name} är {cat.age} år gammal.");
    //}
    //Console.WriteLine($"{myCat.name} är {myCat.age} år gammal.");
    //Console.WriteLine($"{myOtherCat.name} är {myOtherCat.age} år gammal.");

    // Skapa 100 katter i en array.
    int amountOfCats = 100;
    Cat[] cats2 = new Cat[amountOfCats];
    for (int i = 0; i < amountOfCats; i++)
    {
        cats2[i] = new Cat()
        {
            name = $"Katt{i + 1}",
            age = i + 1
        };
    }
    
    // Väldigt ineffektiv lösning på att lösa ovanstående problem
    Cat[] cats3 = [
        new Cat() { name = "Katt1", age = 1 },
        new Cat() { name = "Katt2", age = 2 },
        new Cat() { name = "Katt3", age = 3 },
        new Cat() { name = "Katt4", age = 4 },
        new Cat() { name = "Katt5", age = 5 },
        new Cat() { name = "Katt6", age = 6 },
        new Cat() { name = "Katt7", age = 7 },
        new Cat() { name = "Katt8", age = 8 },
        new Cat() { name = "Katt9", age = 9 },
        new Cat() { name = "Katt10", age = 10 },
        new Cat() { name = "Katt11", age = 11},
        new Cat() { name = "Katt12", age = 12 },
        new Cat() { name = "Katt13", age = 13 },
        new Cat() { name = "Katt14", age = 14 },
        new Cat() { name = "Katt15", age = 15 },
        new Cat() { name = "Katt16", age = 16 },
        new Cat() { name = "Katt17", age = 17 },
        new Cat() { name = "Katt18", age = 18 },
        new Cat() { name = "Katt19", age = 19 },
        new Cat() { name = "Katt20", age = 20 },
        new Cat() { name = "Katt21", age = 21 },
        new Cat() { name = "Katt22", age = 22 },
        new Cat() { name = "Katt23", age = 23 },
        new Cat() { name = "Katt24", age = 24 },
        new Cat() { name = "Katt25", age = 25 },
        new Cat() { name = "Katt26", age = 26 },
        new Cat() { name = "Katt27", age = 27 },
        new Cat() { name = "Katt28", age = 28 },
        new Cat() { name = "Katt29", age = 29 },
        new Cat() { name = "Katt30", age = 30 },
        new Cat() { name = "Katt31", age = 31 },
        new Cat() { name = "Katt32", age = 32 },
        new Cat() { name = "Katt33", age = 33 },
        new Cat() { name = "Katt34", age = 34 },
        new Cat() { name = "Katt35", age = 35 },
        new Cat() { name = "Katt36", age = 36 },
        new Cat() { name = "Katt37", age = 37 },
        new Cat() { name = "Katt38", age = 38 },
        new Cat() { name = "Katt39", age = 39 },
        new Cat() { name = "Katt40", age = 40 },
        new Cat() { name = "Katt41", age = 41 },
        new Cat() { name = "Katt42", age = 42 },
        new Cat() { name = "Katt43", age = 43 },
        new Cat() { name = "Katt44", age = 44 },
        new Cat() { name = "Katt45", age = 45 },
        new Cat() { name = "Katt46", age = 46 },
        new Cat() { name = "Katt47", age = 47 },
        new Cat() { name = "Katt48", age = 48 },
        new Cat() { name = "Katt49", age = 49 },
        new Cat() { name = "Katt50", age = 50 },
        new Cat() { name = "Katt51", age = 51 },
        new Cat() { name = "Katt52", age = 52 },
        new Cat() { name = "Katt53", age = 53 },
        new Cat() { name = "Katt54", age = 54 },
        new Cat() { name = "Katt55", age = 55 },
        new Cat() { name = "Katt56", age = 56 },
        new Cat() { name = "Katt57", age = 57 },
        new Cat() { name = "Katt58", age = 58 },
        new Cat() { name = "Katt59", age = 59 },
        new Cat() { name = "Katt60", age = 60 },
        new Cat() { name = "Katt61", age = 61 },
        new Cat() { name = "Katt62", age = 62 },
        new Cat() { name = "Katt63", age = 63 },
        new Cat() { name = "Katt64", age = 64 },
        new Cat() { name = "Katt65", age = 65 },
        new Cat() { name = "Katt66", age = 66 },
        new Cat() { name = "Katt67", age = 67 },
        new Cat() { name = "Katt68", age = 68 },
        new Cat() { name = "Katt69", age = 69 },
        new Cat() { name = "Katt70", age = 70 },
        new Cat() { name = "Katt71", age = 71 },
        new Cat() { name = "Katt72", age = 72 },
        new Cat() { name = "Katt73", age = 73 },
        new Cat() { name = "Katt74", age = 74 },
        new Cat() { name = "Katt75", age = 75 },
        new Cat() { name = "Katt76", age = 76 },
        new Cat() { name = "Katt77", age = 77 },
        new Cat() { name = "Katt78", age = 78 },
        new Cat() { name = "Katt79", age = 79 },
        new Cat() { name = "Katt80", age = 80 },
        new Cat() { name = "Katt81", age = 81 },
        new Cat() { name = "Katt82", age = 82 },
        new Cat() { name = "Katt83", age = 83 },
        new Cat() { name = "Katt84", age = 84 },
        new Cat() { name = "Katt85", age = 85 },
        new Cat() { name = "Katt86", age = 86 },
        new Cat() { name = "Katt87", age = 87 },
        new Cat() { name = "Katt88", age = 88 },
        new Cat() { name = "Katt89", age = 89 },
        new Cat() { name = "Katt90", age = 90 },
        new Cat() { name = "Katt91", age = 91 },
        new Cat() { name = "Katt92", age = 92 },
        new Cat() { name = "Katt93", age = 93 },
        new Cat() { name = "Katt94", age = 94 },
        new Cat() { name = "Katt95", age = 95 },
        new Cat() { name = "Katt96", age = 96 },
        new Cat() { name = "Katt97", age = 97 },
        new Cat() { name = "Katt98", age = 98 },
        new Cat() { name = "Katt99", age = 99 },
        new Cat() { name = "Katt100", age = 100 }
    ];
}

class Cat
{
    public string name = "default name";
    public int age = 0;

    public void Greet()
    {
        Console.WriteLine($"Hej, jag heter {name}!");
        //Console.WriteLine($"Hej, jag heter {name}, och min dubbla ålder är {GetDoubleAge()}");
    }
    public void Greet(string name)
    {
        Console.WriteLine($"Hej {name}! Jag heter {this.name}!");
    }
    public void Greet(Cat cat)
    {
        Console.WriteLine($"Hej {cat.name}! Jag heter {this.name}!");
    }
    private int GetDoubleAge() => age * 2;

    //public string GetName() => name;
    //public int GetAge() => age;
    //public void SetName(string setName) { name = setName; }
    //public void SetAge(int setAge) { age = setAge; }
}