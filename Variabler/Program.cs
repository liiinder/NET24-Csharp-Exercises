// Uppgifter från https://github.com/everyloop/NET24-Csharp/blob/master/Exercises/Variabler.md
//exercise1();
//exercise2();
//exercise3();
//exercise4();
//exercise5();
//exercise6();
//exercise7();

// TODO: Change name on all the functions / methods to PascalCase

// 1. Hälsa på användaren
static void exercise1()
{
    Console.Write("Skriv ditt namn: ");
    String name = Console.ReadLine();
    Console.WriteLine($"Hej {name}!");
}

// 2. Multiplicera två tal
static void exercise2()
{
    Console.Write("Skriv in första talet: ");
    int firstNumber = Int32.Parse(Console.ReadLine());
    Console.Write("Skriv in andra talet: ");
    int secondNumber = Int32.Parse(Console.ReadLine());
    Console.WriteLine($"{firstNumber} * {secondNumber} = {firstNumber * secondNumber}");
}

// 3. Verifiera lösenord
static void exercise3()
{
    string password = "qwerty";
    Console.Write("Lösenord: ");
    string input = Console.ReadLine();
    if (input == password)
    {
        Console.WriteLine("Rätt lösenord!");
    }
    else
    {
        Console.WriteLine("Fel lösenord!");
    }
}

// 4. Jämför tal
static void exercise4()
{
    Console.Write("Skriv ett tal: ");
    int tal = Int32.Parse(Console.ReadLine());
    if (tal == 100)
    {
        Console.WriteLine("Ditt tal är 100.");
    }
    else if (tal > 100)
    {
        Console.WriteLine("Ditt tal är större än 100.");
    }
    else
    {
        Console.WriteLine("Ditt tal är mindre än 100.");
    }
}

// 5. Dubblera och halvera tal
static void exercise5()
{
    Console.Write("Skriv in ett tal: ");
    double tal2 = Double.Parse(Console.ReadLine());
    Console.WriteLine($"{tal2 * 2} är dubbelt så mycket som {tal2}.");
    Console.WriteLine($"{tal2 / 2} är hälften så mycket som {tal2}.");
}

// 6. Miniräknare
static void exercise6()
{
    Console.Write("Första talet: ");
    double firstNumber2 = Double.Parse(Console.ReadLine());
    Console.Write("Välj +, -, *, / : ");
    string choice = Console.ReadLine();
    Console.Write("Andra talet: ");
    double secondNumber2 = Double.Parse(Console.ReadLine());

    if (choice == "+") Console.WriteLine($"{firstNumber2} {choice} {secondNumber2} = {firstNumber2 + secondNumber2}");
    else if (choice == "-") Console.WriteLine($"{firstNumber2} {choice} {secondNumber2} = {firstNumber2 - secondNumber2}");
    else if (choice == "*") Console.WriteLine($"{firstNumber2} {choice} {secondNumber2} = {firstNumber2 * secondNumber2}");
    else if (choice == "/") Console.WriteLine($"{firstNumber2} {choice} {secondNumber2} = {firstNumber2 / secondNumber2}");
}

// 7. Summa och medelvärde
static void exercise7()
{
    double number;
    double summa = 0;
    double antal = 0;
    while (true)
    {
        Console.Write("Skriv in ett tal: ");
        if (double.TryParse(Console.ReadLine(), out number))
        {
            summa += number;
            ++antal;
        }
        else break;
    }
    Console.WriteLine($"Medelvärde: {summa / antal}");
}