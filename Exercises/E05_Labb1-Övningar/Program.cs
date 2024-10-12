
// Förberedelseövningar - Labb 1
// https://github.com/everyloop/NET24-Csharp/blob/master/Exercises/F%C3%B6rberedelse%C3%B6vningar_Labb1.md

using System.Text.RegularExpressions;

string wood = "chuckchuckHow much wood would a woodchuck chuck if a woodchuck could chuck wood?chuckchuck";
string hello = "Hello World!";
string abc = "abcdefghijklmnopqrstuvwxyz";

//Exercise1(hello);
//Exercise2();
//Exercise3();
//Exercise4(hello);
//Exercise5(hello);
//Exercise6(wood, "oo");
//Exercise6regex(wood, "oo");
//Exercise7(wood, "chuck");
//Exercise8(wood);
//Exercise8regex(wood);
//Exercise9(hello);
//Exercise10(wood);
//Exercise11(wood);
//Exercise12(wood);
//Exercise13(abc);
//Exercise13split(abc, 7 );
//Exercise14();
//Exercise15();

// 1. Bokstav för bokstav - fram till space
static void Exercise1(string hello)
{
// Utgå från strängen (skapa en variabel med) "Hello World!",
// skriv ut hela strängen bokstav för bokstav, men avsluta när det kommer ett space. (Den ska alltså bara skriva “Hello”).
    static string lettersUntilSpace(string input) => input.Split(' ')[0];
    Console.WriteLine(lettersUntilSpace(hello));
}

// 2.Bokstav för bokstav - radbyte på space
static void Exercise2()
{
// Utgå från strängen "This is just some other text".
// Skriv ut strängen bokstav för bokstav, men när det kommer ett space,
// gör radbyte istället. (Du ska få ett ord på varje rad).
    static void newLineOnSpace(string input)
    {
        string[] subStrings = input.Split(' ');
        foreach (string subString in subStrings)
        {
            Console.WriteLine(subString);
        }
    }
    newLineOnSpace("This is just some other text");
}

// 3.Bokstav för bokstav - varannan stjärna
static void Exercise3()
{
// Utgå från strängen "Detta är uppgift 3". Skriv ut bokstav för bokstav.
// Men om index är en jämn siffra, skriv istället ut *
    string text = "Detta är uppgift 3";
    for (int i = 0; i < text.Length; i++)
    {
        if (i % 2 == 0) Console.Write(text[i]);
        else Console.Write('*');
    }
}

// 4.Bokstav för bokstav - gröna o, röda l
static void Exercise4(string hello)
{
// Utgå från strängen "Hello world!". Skriv ut bokstav för bokstav.
// Alla 'o' ska vara grön färg, alla 'l' ska vara röd färg. Övriga bokstäver är vita/grå.
    foreach (char c in hello)
    {
        if (c == 'l') Console.ForegroundColor = ConsoleColor.Red;
        if (c == 'o') Console.ForegroundColor = ConsoleColor.Green;
        Console.Write(c);
        Console.ResetColor();
    }
}

// 5.Bokstav för bokstav - dubbla med grön färg
static void Exercise5(string text)
{
// Utgå från strängen "Hello world". Skriv ut bokstav för bokstav.
// Om två tecken på rad är samma så ska dessa vara grön färg. Övriga bokstäver är vita/grå.
    for (int i = 0; i < text.Length; i++)
    {
        if (i < text.Length - 1 && text[i] == text[i + 1])
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write($"{text[i]}{text[i]}");
            Console.ResetColor();
            i++;
        }
        else Console.Write(text[i]);
    }
}

// 6.Bokstav för bokstav - grön substring
static void Exercise6(string input, string subString)
{
// Utgå från strängen "How much wood would a woodchuck chuck if a woodchuck could chuck wood?",
// samt den mindre strängen "oo". Skriv ut den långa strängen bokstav för bokstav.
// Varje gång den mindre strängen förekommer (två 'o' på raken) så ska dessa vara med grön färg. Övriga bokstäver är vita/grå.
    for (int i = 0; i < input.Length; i++)
    {
        if (i <= input.Length - subString.Length && input.Substring(i, subString.Length) == subString)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(subString);
            Console.ResetColor();
            i += subString.Length - 1;
        }
        else Console.Write(input[i]);
    }
}

// Övning 6 löst med regex istället
static void Exercise6regex(string input, string subString)
{
    string[] subStrings = Regex.Split(input, $"({subString})");
    foreach (string part in subStrings)
    {
        if (part == subString) Console.ForegroundColor = ConsoleColor.Green;
        else Console.ForegroundColor = ConsoleColor.Gray;
        Console.Write(part);
    }
}

// 7.Bokstav för bokstav - grön substring 2
static void Exercise7(string input, string subString)
{
// Samma som uppgift 6, men den mindre strängen är "chuck" istället för "oo".
// D.v.s. alla gånger "chuck" förekommer i den längre strängen skrivs dessa med grön text.
    for (int i = 0; i < input.Length; i++)
    {
        if (i + subString.Length < input.Length && input.Substring(i, subString.Length) == subString)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(subString);
            Console.ResetColor();
            i += subString.Length - 1;
        }
        else Console.Write(input[i]);
    }
}

// 8.Bokstav för bokstav - grön substring 3
static void Exercise8(string input)
{
// Samma som uppgift 6 igen, men denna gången kan användaren mata in den kortare strängen, 
// alltså valfri text som ska sökas (färgas grön) i den längre texten.
    Console.ResetColor();
    Console.WriteLine(input);

    string subString = "chuck";
    string[] subStrings = input.Split(subString);
    for (int i = 0; i < subStrings.Length; i++)
    {
        string part = subStrings[i];
        if (part == "")
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(subString);
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Write(part);
        }
        if (i < subStrings.Length - 1 && part != "" && subStrings[i + 1] != "")
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(subString);
        }
    }
}

static void Exercise8regex(string input)
{
    Console.WriteLine(input);
    Console.Write("Vilken substring i ovanstående mening vill du highlighta: ");
    string subString = Console.ReadLine();
    string[] subStrings = Regex.Split(input, $"((?i){subString})"); // la till case insensitivity för att testa
    foreach (string part in subStrings)
    {
        if (part.ToLower() == subString.ToLower()) Console.ForegroundColor = ConsoleColor.Green;
        else Console.ForegroundColor = ConsoleColor.Gray;
        Console.Write(part);
    }
}

// 9.Bokstavspyramid
static void Exercise9(string hello)
{
// Utgå från strängen "Hello world!". Gör ett program som skriver ut första bokstaven en gång på första raden.
// Andra bokstaven 2 gånger på andra raden. Tredje 3 gånger på nästa rad osv.
    for (int i = 0; i < hello.Length; i++)
    {
        for (int j = 0; j <= i; j++)
        {
            Console.Write(hello[j]);
        }
        Console.WriteLine();
    }
}

// 10. Ordpyramid
static void Exercise10(string input)
{
// Utgå från strängen “How much wood would a woodchuck chuck if a woodchuck could chuck wood?”.
// Gör ett program som skriver ut första ordet en gång på första raden;
// andra ordet två gånger på nästa rad. Tredje ordet tre gånger på nästa. etc. alltså:
    string[] subStrings = input.Split(' ');
    for (int i = 0; i < subStrings.Length; i++)
    {
        for (int j = 0; j <= i; j++)
        {
            Console.Write($"{subStrings[i]} ");
        }
        Console.WriteLine();
    }
}

// 11.Ordpyramid 2
static void Exercise11(string input)
{
// Utgå från strängen “How much wood would a woodchuck chuck if a woodchuck could chuck wood?”.
// Gör ett program som på första raden skriver ut första ordet.
// På nästa rad skriver ut de två första orden, sedan de tre första orden på nästa rad o.s.v till man kommit till raden som skriver ut hela meningen.
    string[] subStrings = input.Split(' ');
    for (int i = 0; i < subStrings.Length; i++)
    {
        for (int j = 0; j <= i; j++)
        {
            Console.Write($"{subStrings[j]} ");
        }
        Console.WriteLine();
    }
}

// 12.Rödmarkerade ord
static void Exercise12(string input)
{
// Utgå från samma sträng igen, men denna gång ska programmet skriva ut hela strängen på varje rad.
// På första raden ska första ordet vara rött (övriga vita), på andra raden ska andra ordet vara rött.
// På tredje raden ska tredje vara rött osv.
    string[] subStrings = input.Split(' ');
    for (int i = 0; i < subStrings.Length; i++)
    {
        for (int j = 0; j < subStrings.Length; j++)
        {
            if (j == i) Console.ForegroundColor = ConsoleColor.Red;
            Console.Write($"{subStrings[j]} ");
            Console.ResetColor();
        }
        Console.WriteLine();
    }
}

// 13. Rödmarkerade bokstäver
static void Exercise13(string input)
{
// Utgå från strängen "abcdefghijklmnopqrstuvwxyz".
// Hela strängen skrivs ut på varje rad. På första raden är de 5 första tecknen röda.
// På nästa rad är “bcdef” röda, sedan “cedfg” osv..
// alltså alltid 5 tecken, men de flyttas ett steg åt höger för varje rad, tills sista raden har “vwxyz” rödfärgad
    int length = 5;
    for (int i = 0; i <= input.Length - length; i++)
    {
        for (int j = 0; j < input.Length; j++)
        {
            if (j == i) Console.ForegroundColor = ConsoleColor.Red;
            if (j == i + length) Console.ResetColor();
            Console.Write(input[j]);
        }
        Console.WriteLine();
    }
}

static void Exercise13split(string input, int length = 5)
{
    for (int i = 0; i <= input.Length - length; i++)
    {
        string firstPart = input.Substring(0, i);
        string secondPart = input.Substring(i, length);
        string thirdPart = input.Substring(i + length) + "\n";

        Console.Write(firstPart);
        Console.ForegroundColor = ConsoleColor.Red;
        Console.Write(secondPart);
        Console.ResetColor();
        Console.Write(thirdPart);
    }
}

// 14.Rödmarkerade bokstäver 2
static void Exercise14()
{
// Användaren matar in valfri sträng.
// Programmet skriver ut hela strängen bokstav för bokstav.
// Alla bokstäverna är röda fram tills du stöter på ett tecken som är samma som första tecknet i strängen.
// Därefter skriver den ut resten av bokstäverna med vit/grå färg. Några exempel vid olika inmatningar/körningar:

//ajdfhvajhdfd
//hhfgijff
//fjpdpog
    Console.Write("Mata in en sträng: ");
    string input = Console.ReadLine();

    Console.ForegroundColor = ConsoleColor.Red;
    for (int i = 0; i < input.Length; i++)
    {
        Console.Write(input[i]);
        if (input[i] == input[0] && i != 0) Console.ResetColor();
    }
}

// 15.Rödmarkerade bokstäver 3
static void Exercise15()
{
// Användaren matar in valfri sträng.
// Programmet skriver sedan ut en hela strängen flera gånger.
// På första raden börjar den skriva med röd färg på första bokstaven och fram tills den hittar samma bokstav igen.
// På andra raden börjar den skriva med röd färg på andra bokstaven och fram tills den hittar samma bokstav igen.
// På tredje raden börjar den skriva med röd text på tredje bokstaven och fram tills den hittar samma igen... etc. Om man t.ex matar in “ajdfhvajhdfd” blir det då:

//ajdfhvajhdfd
//hhfgijff
//fjpdpog
    Console.Write("Mata in en sträng: ");
    string input = Console.ReadLine();

    for (int i = 0; i < input.Length; i++)
    {
        for (int j = 0; j < input.Length; j++)
        {
            if (j == i) Console.ForegroundColor = ConsoleColor.Red;
            Console.Write(input[j]);
            if (input[i] == input[j] && j != i) Console.ResetColor();
        }
        Console.WriteLine();
        Console.ResetColor();
    }
}

Console.WriteLine();
Console.ResetColor();