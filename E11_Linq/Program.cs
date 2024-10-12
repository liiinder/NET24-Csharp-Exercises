// Övningsuppgifter med LINQ
// https://github.com/everyloop/NET24-Csharp/blob/master/Exercises/LINQ.md

// 1. Anonyma datatyper
// Skapa en array "people" med anonyma datatyper.
// Varje objekt i arrayen ska ha följande properties: FirstName, LastName, Age, Height, Weight.

//Lägg till minst 8 sådana objekt i arrayen.
var people = new[] {
      new { LastName = "Eriksson",  FirstName = "Anders",       Age = 39,   Height = 175,  Weight = 75 },
      new { LastName = "Palm",      FirstName = "Lisa",         Age = 40,   Height = 153,  Weight = 45 },
      new { LastName = "Andersson", FirstName = "Per",          Age = 31,   Height = 195,  Weight = 90 },
      new { LastName = "Lundberg",  FirstName = "Anna",         Age = 66,   Height = 170,  Weight = 60 },
      new { LastName = "Eriksson",  FirstName = "Camilla",      Age = 65,   Height = 165,  Weight = 58 },
      new { LastName = "Möller",    FirstName = "Måns",         Age = 49,   Height = 174,  Weight = 68 },
      new { LastName = "Svanslös",  FirstName = "Pelle",        Age = 76,   Height = 135,  Weight = 35 },
      new { LastName = "Lo",        FirstName = "Tove",         Age = 37,   Height = 168,  Weight = 63 },
      new { LastName = "Lövgren",   FirstName = "Bengt-Åke",    Age = 43,   Height = 185,  Weight = 90 },
      new { LastName = "Stark",     FirstName = "Arya",         Age = 11,   Height = 155,  Weight = 40 },
};




//Använd dig sedan av LINQ för att lösa följande uppgifter:

// 2.Filtrera på ålder
// Filtrera arrayen (uppgift 1) så du får en ny lista med endast de användare som är mellan 20 och 40 år gamla.
var method2 = people.Where(x => 20 < x.Age && x.Age < 40).ToArray();

var query2 =
(
    from person in people
    where 20 < person.Age && person.Age < 40
    select person
).ToArray();




// 3. Är någon längre än 190 cm?
// Är någon av personerna mellan 20 och 40 år längre än 190 cm lång?
bool method3 = method2.Any(x => x.Height > 190);

bool query3 =
(
    from person in people
    where person.Height > 190
    select person
).Any();




// 4. Filtrera på namn
// Filtrera arrayen från uppgift 1 så att du får en ny lista med endast de användare vars förnamn är längre än efternamnet
// (d.v.s större antal bokstäver). I den nya listan vill vi att objekten ska ha endast properties FirstName och LastName.
var method4 = people.Where(x => x.FirstName.Length > x.LastName.Length)
                    .Select(x => new {FirstName = x.FirstName, LastName = x.LastName})
                    .ToList();

var query4 = (
    from person in people
    where person.FirstName.Length > person.LastName.Length
    select person
).ToList();




// 5. Hela namnet tillsammans med BMI
// Skapa en ny lista från arrayen (från uppgift 1) som innehåller objekt med properties Name (hela namnet), samt BMI (uträknat från längd och vikt) för alla personer.
var method5 = people.Select(x => new { Name = $"{x.FirstName} {x.LastName}", BMI = GetBMI(x.Weight, x.Height) });

var query5 = (
    from person in people
    select new
    {
        Name = $"{person.FirstName} {person.LastName}",
        BMI = GetBMI(person.Weight, person.Height)
    }
).ToList();




// 6. Filtrera listan ovan på BMI
// Filtrera listan (från uppgift 5) så att du endast får med personer med BMI under 20 eller BMI över 25.
var method6 = method5.Where(x => x.BMI < 20 || 25 < x.BMI).ToList();

var query6 = (
    from person in query5
    where person.BMI < 20 || person.BMI > 25
    select person
).ToList();




// 7. Filtrera orginallistan på BMI
// Filtrera arrayen (från uppgift 1) så att du endast får med personer med BMI under 20 eller BMI över 25.
var method7 = people.Where(x => method6.Any(y => y.Name == $"{x.FirstName} {x.LastName}")).ToList();

var query7 = (
    from person in people
    where GetBMI(person.Weight, person.Height) < 20 ||
          GetBMI(person.Weight, person.Height) > 25
    select person
).ToList();




// 8. Username tillsammans med Category
// Skapa en ny lista från arrayen (i uppgift 1) som innehåller
// objekt med properties Username (förnamnet + åldern, ex. “Kalle23”), samt Category (som har värdet “Child” eller “Adult” beroende på om personen är under 18 eller inte).
var method8 = people.Select(x => new { Username = $"{x.FirstName}{x.Age}", Category = x.Age < 18 ? "Child" : "Adult" }).ToList();

var query8 = (
    from person in people
    select new
    {
        Username = $"{person.FirstName}{person.Age}",
        Category = person.Age < 18 ? "Child" : "Adult"
    }
).ToList();




// 9. Query syntax
// Lös alla uppgifter 2 - 8 med query-syntax (om du använt method-syntax, annars tvärtom).

// ...... *facepalm*




// 10. Sortera efter längd
// LINQ använder metoderna .OrderBy() och .OrderByDescending() för att sortera data.

// Skriv ut alla personer (från uppgift 1) i längdordning (kortast först).
foreach (var person in people.OrderBy(x => x.Height))
{
    Console.WriteLine($"Height: {person.Height}cm - Name: {person.FirstName} {person.LastName}");
}
Console.WriteLine();




// 11. Sortera äldst till yngst
// Skriv ut alla personer (från uppgift 1) sortera efter ålder; från äldst till yngst.
foreach (var person in people.OrderByDescending(x => x.Age))
{
    Console.WriteLine($"Age: {person.Age} - Name: {person.FirstName} {person.LastName}");
}
Console.WriteLine();




// 12. Sortering i första och andra hand
// Efter .OrderBy eller .OrderByDescending() kan man använda .ThenBy() och .ThenByDescending() för att sortera på något annat i andra hand
// (om flera objekt har samma värden i första sorteringen).

// Skriv ut alla personer (från uppgift 1) sorterade på efternamn i stigande ordning (A -> Z).
// Om flera personer har samma efternamn, sortera dessa på förnamn i fallande ordning (Z -> A).
foreach (var person in people
    .OrderBy(x => x.LastName)
    .ThenByDescending(x => x.FirstName)
){
    Console.WriteLine($"Name: {person.FirstName} {person.LastName}");
}
Console.WriteLine();




// 13. LINQ vs PLINQ
// Använd Enumerable.Range() för att skapa en sekvens av tal från 1 upp till 1 miljard.
// Filtrera sedan sekvensen på så vis att du får endast de tal som är jämnt delbara med 3 eller 5. Beräkna summan av talen.
Console.WriteLine("breakpoint...");

//OBS! Använd inte ToList() ovan, då detta till skillnad från Enumerable faktiskt skapar upp alla tal i minnet.
ulong result = Enumerable.Range(1, 1000000000).Where(n => n % 3 == 0 || n % 5 == 0).Select(n => (ulong)n).Aggregate((a, c) => a + c);

//Sätt breakpoints i din kod och använd debuggern för att kolla hur lång tid det tar att exekvera.
Console.WriteLine(result); // ~5750 ms ...

var squares2 = Enumerable
    .Range(0, 1000000000)
    .AsParallel()
    .Where(n => n % 3 == 0 || n % 5 == 0)
    .Select(n => (ulong)n)
    .Aggregate((a, c) => a + c);

//Prova sedan att köra samma beräkning som parallell LINQ; jämför tiden det tar att exekvera.
Console.WriteLine(squares2); // 2734 ms ... 1650 ms ... 2255 ... 1960 ... minst halva tiden om inte snabbare!




// Takes weight in kg and height in cm and returns BMI as a double.
static double GetBMI(int weight, int height) => weight / Math.Pow((double)height / 100, 2);