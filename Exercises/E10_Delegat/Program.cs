
// Övningsuppgifter med delegat och lambda
// https://github.com/everyloop/NET24-Csharp/blob/master/Exercises/Delegat.md




// 1. Deklarera en egen delegat-typ
Console.WriteLine("\n\n───[ Uppgift 1 ]────────────────────────────────────────────────────────\n");

// Skriv en metod som tar två strängar: firstName och lastName.
// Metoden ska returnera en ny sträng som är hela namnet.
static string Concat(string a, string b) => a + " " + b;

// Deklarera en delegat-typ, och gör en variabel som är en referens till metoden.
ConcatStrings myDelegate = new ConcatStrings(Concat); // Den egna delegaten finns längst ner i filen. (pga toplevel osv...)

string firstName = "Robert";
string lastName = "Gustavsson";

// Anropa metoden via delegatet.
Console.WriteLine(myDelegate(firstName, lastName));




// 2. Använd generiskt delegat
// Ändra koden i uppgiften ovan så att den använder ett
// generiskt delegat istället för den du själv deklarerade.
Console.WriteLine("\n\n───[ Uppgift 2 ]────────────────────────────────────────────────────────\n");

Func<string, string, string> concatStrings = Concat;
Console.WriteLine(concatStrings(firstName, lastName));




// 3. Metod som tar delegat som inparameter
Console.WriteLine("\n\n───[ Uppgift 3 ]────────────────────────────────────────────────────────\n");

// Skriv en ny metod som också tar firstName och lastName.
// Denna metoden ska returnera en sträng som innehåller variabelnamnen och dess värden på två rader.
static string Concat2(string firstName, string lastName) => $"{nameof(firstName)}: {firstName}\n{nameof(lastName)}: {lastName}";

//Exempel:
// firstName: Fredrik
// lastName: Johansson
Console.WriteLine(Concat2("Fredrik", "Johansson"));

// Skriv sedan en metod som tar ett generiskt delegat (som matchar metoden ovan) som inparameter.
// Metoden ska, i tur och ordning, anropa delegatet med 3 olika för- och efternamn och skriva ut resultatet.
static void ConcatDelegate(string a, string b, Func<string, string, string> Generic)
{
    Console.WriteLine(Generic?.Invoke(a, b));
}

// Testa att anropa denna metod först med en referens till metoden i uppgift 1 och sedan med metoden ovan (uppgift 3).
Console.WriteLine("\nMetod från uppgift 1");
Console.WriteLine("────────────────────");
ConcatDelegate("Måns", "Möller", Concat);

Console.WriteLine("\nMetod från uppgift 3");
Console.WriteLine("────────────────────");
ConcatDelegate("Berit", "Andersson", Concat2);
ConcatDelegate("Conny", "Bengtsson", Concat2);
ConcatDelegate("Kolle", "Lövfen", Concat2);




// 4. Skriv ut summan av två värden
// Skapa ett generiskt delegat med ett lambda uttryck
// som tar två tal och skriver ut summan av dessa på konsolen.
// Testa genom att anropa med två värden.
Console.WriteLine("\n\n───[ Uppgift 4 ]────────────────────────────────────────────────────────\n");

Action<int, int> printSum = (x, y) => Console.WriteLine(x + y);

Console.Write(" 3 + 5 = ");
printSum(3, 5);

Console.Write(" 3 + 2 = ");
printSum(3, 2);




// 5. Returnera summan av två värden
// Skapa ett generiskt delegat med ett lambda uttryck som tar två tal och returnerar summan av dessa.
// Testa genom att anropa med två värden, och skriva ut resultatet.
Console.WriteLine("\n\n───[ Uppgift 5 ]────────────────────────────────────────────────────────\n");

Func<int, int, int> returnSum = (x, y) => x + y;

Console.WriteLine(" 6 + 1 = " + returnSum(6, 1));
Console.WriteLine(" 4 + 2 = " + returnSum(4, 2));




// 6. Lambda som argument
// Anropa metoden (den som tar ett generiskt delegat) i uppgift 3.
// Som argument skriver du ett lambdauttryck som returnerar en string med antal tecken i namnen:
// Ex. "firstName has 7 letters, lastName has 9 letters."
Console.WriteLine("\n\n───[ Uppgift 6 ]────────────────────────────────────────────────────────\n");

Func<string, string, string> LettersInName = (firstName, lastName) => $"{nameof(firstName)} has {firstName.Length} letters, {nameof(lastName)} has {lastName.Length} letters.";
ConcatDelegate("Anna", "Book", LettersInName);




// 7.Modifiera utskrift med lambdauttryck
// Skriv en metod som tar en string[] som inparameter och skriver ut alla strängar i arrayen på varsin rad.
// Uppdatera sedan metoden så att den tar en andra parameter: Func<string, string> modifier,
// och anropa modifier() på varje string i arrayen innan du skriver ut den.
Console.WriteLine("\n\n───[ Uppgift 7 ]────────────────────────────────────────────────────────\n");
static void PrintStrings(string[] strings, Func<string, string> modifier)
{
	foreach (string s in strings) Console.WriteLine(modifier(s));
}

//Skapa en en string[] med namnen på fem städer som du kan skicka in i metoden.
string[] words = ["Paris", "Berlin", "London", "Prag", "Gothenburg"];

// Gör 3 anrop till metoden (med olika lambda-uttryck):
// ────────────────────────────────────────────────────
// Ett som skriver ut alla städer i UPPERCASE
Console.WriteLine("Ett som skriver ut alla städer i UPPERCASE");
Console.WriteLine("──────────────────────────────────────────");
Func<string, string> toUpper = s => s.ToUpper();
PrintStrings(words, toUpper);

// Ett som skriver ut de 3 första tecknen i varje stad
Console.WriteLine("\nEtt som skriver ut de 3 första tecknen i varje stad");
Console.WriteLine("───────────────────────────────────────────────────");
Func<string, string> threeLetters = s => s[..3];
PrintStrings(words, threeLetters);

// Ett som skriver ut längden på varje stads namn
Console.WriteLine("\nEtt som skriver ut längden på varje stads namn");
Console.WriteLine("──────────────────────────────────────────────");
Func<string, string> lengthOf = s => $"{s} contains {s.Length} letters";
PrintStrings(words, lengthOf);




// 8. Filtrera array (utskrift)
// Skapa en metod som tar en array med heltal,
// samt ett delegat som tar en int som inparameter och returnerar en bool.
// Metoden ska sedan anropa delegatet för varje tal i arrayen och endast skriva ut de tal som returnerar true.
Console.WriteLine("\n\n───[ Uppgift 8 ]────────────────────────────────────────────────────────\n");

static void PrintInts(int[] numbers, Func<int, bool> isIntTrue)
{
    string results = String.Empty;
    foreach (int number in numbers)
    {
        if (isIntTrue(number)) results += $"{number}, "; 
    }
    Console.WriteLine(results[..^2]); 
    // Skriver ut en substräng av results, [..^2] uttrycket betyder från första tecknet till ^2
    // ^ betyder att den räknar bakifrån och 2. Alltså skriver den ut hela meningen förutom dom två sista tecknena (vilket alltid blir ", ")
}

// Skapa en int[] med 10 tal som du kan skicka in i metoden:
int[] ints = [1, 2, 3, 4, 10, 14, 13, 15, 20, 30];

// Gör 3 anrop till metoden:
// ─────────────────────────

// Ett som listar alla negativa tal
Console.Write("Ett som listar alla negativa tal:".PadRight(45));
PrintInts(ints, (x => x % 2 != 0));

// Ett som listar alla tal mellan 10 och 20
Console.Write("Ett som listar alla tal mellan 10 och 20:".PadRight(45));
PrintInts(ints, (x => 10 < x && x < 20));

// Ett som listar alla jämna tal
Console.Write("Ett som listar alla jämna tal:".PadRight(45));
PrintInts(ints, (x => x % 2 == 0));




// 9. Filtrera array (till ny array)
// Gör om metoden i uppgift 8 så att den istället för att skriva ut talen returnerar en ny array med de tal som matchar villkoren i lambdautrycket man skickar in.
Console.WriteLine("\n\n───[ Uppgift 9 ]────────────────────────────────────────────────────────\n");
static int[] ReturnInts(int[] numbers, Func<int, bool> isIntTrue)
{
    List<int> results = new List<int>(); 
    foreach (int number in numbers)
    {
        if (isIntTrue(number)) results.Add(number);
    }
    return results.ToArray();
}
int[] newInts = Array.Empty<int>();

// Gör 3 anrop till metoden:
// ─────────────────────────
// Ett som listar alla negativa tal
newInts = ReturnInts(ints, (x => x % 2 != 0));
Console.WriteLine("Ett som listar alla negativa tal".PadRight(45) + "[{0}]", string.Join(", ", newInts));

// Ett som listar alla tal mellan 10 och 20
newInts = ReturnInts(ints, (x => 10 < x && x < 20));
Console.WriteLine("Ett som listar alla tal mellan 10 och 20".PadRight(45) + "[{0}]", string.Join(", ", newInts));

// Ett som listar alla jämna tal
newInts = ReturnInts(ints, (x => x % 2 == 0));
Console.WriteLine("Ett som listar alla jämna tal".PadRight(45) + "[{0}]", string.Join(", ", newInts));




// Uppgift 1.
public delegate string ConcatStrings(string a, string b);