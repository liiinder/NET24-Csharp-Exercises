
// Övningsuppgifter med klasser och objekt
// https://github.com/everyloop/NET24-Csharp/blob/master/Exercises/BasicOOP.md

// 1. Skriva ut namn på personer

// Skriv en klass som representerar en person.
// Klassen ska ha två publika fält (fields): firstName, lastName.
// Skapa två instanser av personer med olika för och efternamn,
// och använd sedan dessa för att printa ut (hela) namnen på de olika personerna.
Person user1 = new Person() { firstName = "Krister", lastName = "Eriksson" };
Person user2 = new Person() { firstName = "Annica", lastName = "Svensson" };

Console.WriteLine("\n--- Uppgift 1 ---");
Console.WriteLine($"{user1.firstName} {user1.lastName}");
Console.WriteLine($"{user2.firstName} {user2.lastName}");

// 2. Lägg till en metod som returnerar hela namnet

// Uppdatera klassen i uppgift 1 med en metod: public string GetFullName(),
// som returnerar en sträng med hela namnet.
Console.WriteLine("\n--- Uppgift 2 ---");
Console.WriteLine(user1.GetFullName());

// 3. Lägg till en metod som returnerar namnet baklänges
// Uppdatera klassen med en ny metod: public string GetFullNameReversed()
// som returnerar en sträng med hela namnet baklänges.
// Låt denna metoden använda sig av metoden i uppgift 2.
Console.WriteLine("\n--- Uppgift 3 ---");
Console.WriteLine(user1.GetFullNameReverse());

// 4. Overload av GetFullName med titel.
// GetFullName ska finnas i två versioner:
// en utan parametrar som i uppgift 2;
// och en där man kan skicka in en titel, t.ex.
// "Dr." eller "Mr." som returnerar namnet på personen med titeln framför.
Console.WriteLine("\n--- Uppgift 4 ---");
Console.WriteLine(user1.GetFullName("Dr."));

// 5. Lägg till så personer kan ha föräldrar.
// Uppdatera person-klassen så att varje person kan ha en mamma och en pappa.
// Dessa representeras som publika fält(fields) av typen Person
// (eller vad du kallade klassen i uppgift 1).
user1.mother = user2;

// 6. Skapa ett objekt som representerar dig och dina föräldrar
// Gör en instans av en person och ge den ditt för- och efternamn.
// Lägg även in dina föräldrars namn, kopplade till dig.
// Så t.ex myself.GetFullName() returnerar ditt namn,
// och myself.mother.GetFullName() returnerar din mammas namn
Console.WriteLine("\n--- Uppgift 6 ---");
Person myMother = new Person() { firstName = "Irene", lastName = "Linder" };
Person myFather = new Person() { firstName = "Bengt-Åke", lastName = "Linder" };
Person myself = new Person() {
    firstName = "Kristoffer",
    lastName = "Linder",
    mother = myMother,
    father = myFather
};
Person myGrandMother = new Person() { firstName = "Ruth", lastName = "Andersson" };
myMother.mother = myGrandMother;

Console.WriteLine(myself.GetFullName());
Console.WriteLine(myself.mother.GetFullName());

// 7. Hämta information on dig och dina föräldrar.
Console.WriteLine("\n--- Uppgift 7 ---");
Console.WriteLine(myself.GetSelfAndParents());
Console.WriteLine(myself.mother.GetSelfAndParents());

// 8.Privat fält, med metoder för att sätta och hämta värdet.
// Uppdatera klassen med ett fält, private double length,
// som kan lagra längden på personen.
// Eftersom denna är markerad som private kommer man inte kunna läsa/skriva denna utanför klassen.
// Lägg därför till en metod void SetLength(double length) som sätter värdet på det privat fältet length,
// samt en double GetLength() som returnerar värdet på fältet length.
Console.WriteLine("\n--- Uppgift 8 ---");
myself.Length = 1.78;
Console.WriteLine($"{myself.Length}m");

// När du är klar ska följande kod ge utskriften 1.82

//Person myPerson = new Person();
//myPerson.SetLength(1.82);
//Console.Write(myPerson.GetLength());

// 9.Vikt och BMI
// Gör motsvarande för Vikt,
// alltså ett privat fält med publika metoder:
// double GetWeight() och void SetWeight(double weight).
// Gör sedan även en publik metod double GetBMI()
// som returnerar personens BMI.
// Detta ska dock inte finnas representerat som en private field.
Console.WriteLine("\n--- Uppgift 9 ---");
myself.Weight = 76;
Console.WriteLine($"{myself.Weight} kg");
Console.WriteLine($"BMI: {myself.GetBMI()}");
myself.PrintBMI();

class Person
{
    public string firstName;
    public string lastName;
    public Person mother;
    public Person father;
    public double Weight { get; set; } // snippet prop för detta...
    public double Length { get; set; }

    public string GetFullName() => $"{firstName} {lastName}";

    public string GetFullName(string title) => $"{title} {GetFullName()}";

    public string GetFullNameReverse()
    {
        char[] reverseName = GetFullName().ToCharArray();
        Array.Reverse(reverseName);
        return new string(reverseName);
    }

    public string GetSelfAndParents()
    {
        // Lägg till en public string GetSelfAndParents()
        // som returnerar en sträng på formatet
        // "Ditt Namn - Mamma: Mammans Namn - Pappa: Pappans namn".
        // Om mammans eller pappans namn saknas (null) markera det med "okänd" i strängen.
        // Exempel: "Fredrik Johansson - Mamma: okänd - Pappa: Göran Johansson"

        //string motherName = mother == null ? "Okänd" : mother.GetFullName();
        //string fatherName = father == null ? "Okänd" : father.GetFullName();
        //return $"Namn: {GetFullName(), -20}Mamma: {motherName, -20}Pappa: {fatherName, -20}";

        // Samma som dom tre övre raderna men använder...
        return $"Namn: {GetFullName(), -20}" +
               $"Mamma: {mother?.GetFullName() ?? "Okänd", -20}" +
               $"Pappa: {father?.GetFullName() ?? "Okänd", -20}";

        // Null Conditional Operators
        // Om mother är null, returnera null på hela. mother?.GetFullName() 
        // https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/operators/member-access-operators#null-conditional-operators--and-
        
        // Null Coalescing Operator -> mother?.GetFullName() ?? "Okänd"
        // ?? är det innan null använd det som är efter.
        // https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/operators/null-coalescing-operator
    }

    public double GetBMI() => Weight / (Length * Length);

    public void PrintBMI() => Console.WriteLine("BMI: " + GetBMI().ToString("F2"));
}