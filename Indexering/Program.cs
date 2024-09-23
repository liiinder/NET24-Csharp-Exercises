
// Övningsuppgifter med indexering av strängar och arrayer
// https://github.com/everyloop/NET24-Csharp/blob/master/Exercises/Indexering.md

//Exercise1();
//Exercise2();
//Exercise2extra();
//Exercise3();
//Exercise4();
//Exercise4extra();
//Exercise5();
//Exercise5loop();
//Exercise6();
//Exercise7();
//Exercise8();
//Exercise9();
//Exercise10();
//Exercise11();
//Exercise12();

//## 1. En bokstav på varje rad
static void Exercise1()
{
    Console.Write("Skriv något: ");
    string input = Console.ReadLine();
    //for (int i = 0; i < input.Length; i++) Console.WriteLine(input[i]);
    foreach (char c in input) Console.WriteLine(c); // foreach känns lite enklare att förstå vid snabb överblick.
}

//## 2. Siffror till text
static void Exercise2()
{
    Console.Write("Skriv in ett heltal (0 - 9): ");
    string[] nummer = { "noll", "ett", "två", "tre", "fyra", "fem", "sex", "sju", "åtta", "nio" };
    int input = Int32.Parse(Console.ReadLine());
    Console.WriteLine($"{nummer[input]}");
}

//***Extra utmaning:****Användaren kan mata in en sträng med fritt antal siffror, om man skriver in t.ex 432 så svarar programmet: "fyra - tre - två".*
static void Exercise2extra()
{
    Console.Write("Skriv in ett heltal (0 - 9): ");
    string[] nummer = { "noll", "ett", "två", "tre", "fyra", "fem", "sex", "sju", "åtta", "nio" };
    string input = Console.ReadLine();
    string[] result = new string[input.Length]; // Deklarera en tom array med plats att lagra utskriften i.
    for (int i = 0; i < input.Length; i++)
    {
        result[i] = nummer[input[i] - '0']; // - '0' gör tydligen om en char till int om det är möjligt. Kommer krascha om användaren skriver in annat än siffror.
    }
    Console.WriteLine(String.Join(" - ", result));
}

//## 3. Baklänges
static void Exercise3()
{
    Console.Write("Skriv något: ");
    string input = Console.ReadLine();
    // Lösning med både for och foreach. For loopen blir lite "tydligare" då den inte använder en metod (reverse()) för att vända på stringen/arrayen.

    //for (int i = input.Length - 1; i >= 0; i--) Console.WriteLine(input[i]);
    foreach (char c in input.Reverse()) Console.Write(c);
}

//## 4. Dölj vokaler
static void Exercise4()
{
    string vowels = "aAeEiIoOuUyYåÅäÄöÖ";
    Console.Write("Skriv en text: ");
    string input = Console.ReadLine();
    for (int i = 0; i < vowels.Length; i++)
    {
        input = input.Replace(vowels[i], '*');
    }
    Console.WriteLine(input);
}

//***Extra utmaning:****Skriv ut texten översatt till [rövarspråket] (https://sv.wikipedia.org/wiki/R%C3%B6varspr%C3%A5ket).*
static void Exercise4extra()
{
    string vowels = "aAeEiIoOuUyYåÅäÄöÖ";
    Console.Write("Skriv en text: ");
    string input = Console.ReadLine();
    string result = "";
    for (int i = 0; i < input.Length; i++)
    {
        if (!vowels.Contains(input[i]))
        {
            result += $"{input[i]}o{input[i]}";
        }
        else
        {
            result += input[i];
        }
    }
    Console.WriteLine(result);
}

//## 5. Palindrom
static void Exercise5()
{
    Console.Write("Skriv ett ord: ");
    string input = Console.ReadLine();

    char[] reverse = input.ToCharArray();
    Array.Reverse(reverse);
    string reverseString = reverse.ToString();

    if (reverseString.ToLower() == input.ToLower())
    {
        Console.WriteLine($"{input} är ett palindrom!");
    }
    else
    {
        Console.WriteLine($"{input} är inget palindrom då det blir {reverseString} baklänges!");
    }
}

static void Exercise5loop()
{
    Console.Write("Skriv ett ord: ");
    string input = Console.ReadLine();

    int j = input.Length;
    bool palindrome = true;
    for (int i = 0; i < input.Length / 2; i++)
    {
        j--;
        if (input[i] != input[j])
        {
            palindrome = false;
            break;
        }
    }
    if (palindrome) Console.WriteLine($"{input} är ett palindrom");
    else Console.WriteLine($"{input} är inget palindrom");
}

//## 6. Miniräknare
static void Exercise6()
{
    Console.Write("Vad vill du räkna ut? ");
    string input = Console.ReadLine();
    input = input.Replace(" ", "");
    if (input.Contains("+"))
    {
        string[] nummer = input.Split("+");
        int result = Int32.Parse(nummer[0]) + Int32.Parse(nummer[1]);
        Console.WriteLine($"{nummer[0]} + {nummer[1]} = {result}");
    }
    else if (input.Contains("-"))
    {
        string[] nummer = input.Split("-");
        int result = Int32.Parse(nummer[0]) - Int32.Parse(nummer[1]);
        Console.WriteLine($"{nummer[0]} - {nummer[1]} = {result}");
    }
    else if (input.Contains("*"))
    {
        string[] nummer = input.Split("*");
        double result = double.Parse(nummer[0]) * double.Parse(nummer[1]);
        Console.WriteLine($"{nummer[0]} * {nummer[1]} = {result}");
    }
    else if (input.Contains("/"))
    {
        string[] nummer = input.Split("/");
        double result = double.Parse(nummer[0]) / double.Parse(nummer[1]);
        Console.WriteLine($"{nummer[0]} / {nummer[1]} = {result}");
    }
// Inte det snyggaste men det fungerar iaf ...
}

//## 7. Omvänd ordning
static void Exercise7()
{
    String[] inputs = new string[7];
    Console.WriteLine("Skriv sju ord:");
    for (int i = 0; i < inputs.Length; i++)
    {
        Console.Write($"{i + 1}: ");
        inputs[i] = Console.ReadLine();
    }
    Array.Reverse(inputs);
    Console.WriteLine(string.Join(" ", inputs));
}

//## 8. Fördröjd utskrift
static void Exercise8()
{
// Skapa ett program som ber användaren att skriva in ett ord. Sedan ett till, och ett till i all evighet.
// Varje gång man skrivit in ett ord så ska programmet skriva ut det ord man skrev 10 inmatningar tidigare.
// Men om man inte skrivit in 10 ord än så kan den istället skriva just det: "Du har inte skrivit in 10 ord än."
    List<string> ordlista = new List<string>();
    Console.WriteLine("Nu ska vi bygga en ordlista! (avsluta med ctrl + c");
    while(true)
    {
        Console.Write("Skriv ett ord: ");
        ordlista.Add(Console.ReadLine());
        if (ordlista.Count < 10)
        {
            Console.WriteLine("Du har inte skrivit in 10 ord än.");
        }
        else
        {
            Console.WriteLine(ordlista[ordlista.Count-10]);
        }
    }
}

//## 9. Bokstavspyramid (Samma uppgift som Loopar "11. Sifferpyramid"?
static void Exercise9()
{
    string hello = "Hello World";
    for (int i = 0; i < hello.Length; i++)
    {
        for (int j = 0; j <= i; j++)
        {
            Console.Write(hello[j]);
        }
        Console.WriteLine("");
    }
}

//## 10. Färgade bokstäver
static void Exercise10()
{
    Console.Write("Skriv något: ");
    string input = Console.ReadLine();
    Console.Write("Skriv en bokstav: ");
    string input2 = Console.ReadLine();
    char colored = input2[0];
    foreach (char c in input)
    {
        if (c == colored) Console.ForegroundColor = ConsoleColor.Red;
        else Console.ForegroundColor = ConsoleColor.Gray;
        Console.Write(c);
    }
    Console.ForegroundColor = ConsoleColor.Gray;
}

//## 11. Start & Stop
static void Exercise11()
{
    Console.Write("Mata in en text: ");
    string text = Console.ReadLine();
    Console.Write("Välj startindex: ");
    int start = Int32.Parse(Console.ReadLine()) - 1;
    Console.Write("Välj stopindex: ");
    int stopp = Int32.Parse(Console.ReadLine()) - 1;
    for (int i = 0; i < text.Length; i++)
    {
        if (i == start) Console.ForegroundColor = ConsoleColor.Red;
        Console.Write(text[i]);
        if (i == stopp) Console.ForegroundColor = ConsoleColor.Gray;
    }
}

//## 12. Växla färg
static void Exercise12()
{
    Console.Write("Mata in en text: ");
    string text = Console.ReadLine();
    Console.Write("Välj bokstav: ");
    char bokstav = Console.ReadLine()[0];
    bool red = false;
    foreach (char c in text)
    {
        if (c == bokstav) red = !red;
        if (c == bokstav && red) Console.ForegroundColor = ConsoleColor.Red;
        Console.Write(c);
        if (c == bokstav && !red) Console.ForegroundColor = ConsoleColor.Gray;
    }
    Console.ForegroundColor = ConsoleColor.Gray;
}