// Övningar - Loopar
//exercise1();
//exercise2();
//exercise3();
//exercise4();
//exercise5();
//exercise6();
//exercise7();
//exercise8();
//exercise9();
//exercise10();
//exercise11();
//exercise12();
//exercise13();
//exercise14();
//exercise14ex2();
exercise15();

// 1. Skriv talen 20 till 30
static void exercise1()
{
    for (int i = 20; i <= 30; i++)
    {
        Console.WriteLine(i);
    }
}

// 2. Jämna tal
static void exercise2()
{
    for (int i = 0; i <= 30; i++)
    {
        if (i % 2 == 0) Console.WriteLine(i);
    }
}

// 3. Var tredje "Hej"
static void exercise3()
{
    for (int i = 0; i <= 30; i++)
    {
        if (i % 3 == 0) Console.WriteLine("\"Hej\"");
        else Console.WriteLine(i);
    }
}

// 4. Gångertabell
static void exercise4()
{
    Console.Write("Skriv in ett tal: ");
    double tal;
    if (Double.TryParse(Console.ReadLine(), out tal))
    {
        for (int i = 0; i <= 10; i++)
        {
            Console.WriteLine($"{i} * {tal} = {i * tal}");
        }
    }
}

// 5. Summa
static void exercise5()
{
    int summa = 0;
    int antal = 1000;
    for (int i = 1; i <= antal; i++) summa += i;
    Console.WriteLine($"Summan av alla talen 1 till {antal} = {summa}");
}

// 6. Riskorn på shackbräde
static void exercise6()
{
    for (int i = 0; i < 64; i++) Console.WriteLine($"Ruta {i + 1}: {Math.Pow(2, i)}");
}

// 7. Fylld box
static void exercise7()
{
    Console.Write("Mata in höjd: ");
    int height = Int32.Parse(Console.ReadLine());
    Console.Write("Mata in bredd: ");
    int width = Int32.Parse(Console.ReadLine());
    for (int i = 0; i < height; i++)
    {
        for (int j = 0; j < width; j++)
        {
            Console.Write("X");
        }
        Console.Write($"\n");
    }
}

// 8. Randig box
static void exercise8()
{
    Console.Write("Mata in höjd: ");
    int height2 = Int32.Parse(Console.ReadLine());
    Console.Write("Mata in bredd: ");
    int width2 = Int32.Parse(Console.ReadLine());
    for (int i = 0; i < height2; i++)
    {
        for (int j = 0; j < width2; j++)
        {
            if (j % 2 == 0) Console.Write("X");
            else Console.Write("O");
        }
        Console.Write($"\n");
    }
}

// 9. Rutig box
static void exercise9()
{
    Console.Write("Mata in höjd: ");
    int height3 = Int32.Parse(Console.ReadLine());
    Console.Write("Mata in bredd: ");
    int width3 = Int32.Parse(Console.ReadLine());
    for (int i = 0; i < height3; i++)
    {
        for (int j = 0; j < width3; j++)

            if (j % 2 == i % 2) Console.Write("X");
            // Om kordinaterna har samma polaritet (odd/even) så skriver den ut ett X annars O
            // i + j % 2 == 0 skulle också fungera
            else Console.Write("O");
    }
    Console.Write($"\n");
}

// 10. Ihålig box
static void exercise10()
{
    Console.Write("Mata in höjd: ");
    int height = Int32.Parse(Console.ReadLine());
    Console.Write("Mata in bredd: ");
    int width = Int32.Parse(Console.ReadLine());
    for (int i = 0; i < height; i++)
    {
        for (int j = 0; j < width; j++)
        {
            if (i == 0 || i == height - 1) Console.Write("X"); // Om i (höjden) är på översta eller understa raden
            else if (j == 0 || j == width - 1) Console.Write("X"); // Om j (bredden) är på första eller sista kolumnen
            else Console.Write(" ");
        }
        Console.Write($"\n");
    }
}

// 11. Sifferpyramid
static void exercise11()
{
    for (int i = 1; i <= 9; i++)
    {
        for (int j = 1; j <= i; j++)
        {
            Console.Write(j);
        }
        Console.Write("\n");
    }
}

// 12.Nio Sifferpyramider
static void exercise12()
{
    for (int i = 1; i <= 9; i++)
    {
        for (int j = 1; j <= i; j++)
        {
            for (int n = 1; n < j; n++)
            {
                Console.Write(n);
            }
            Console.Write(j);
            Console.WriteLine();
        }
        Console.WriteLine();
    }
}

// 13. Primtal
static void exercise13()
{
    int[] prime = new int[20]; // En array som sparar alla primtal, längden bestämmer hur många vi vill hitta.
    int siffra = 2; // Nummret som vi undersöker, iom att uppgiften säger större än 1 så börjar vi på 2.
    int antal = 0;
    while (antal < prime.Length) // Så länge vi har färre tal än vad som får plats i arrayen så fortsätter vi leta efter primtal
    {
        if (siffra / 2 % 2 == 0) siffra++;
        for (int i = 2; i <= siffra; i++)
        {
            if (siffra % i == 0 && i != siffra) break;
            else if (siffra == i)
            {
                prime[antal] = siffra;
                antal++; // hittar vi ett primtal ökar vi antal och avancerar i while loopen.
            }
        }
        siffra++;
    }
    Console.WriteLine(string.Join(", ", prime));
}

// 14. Spel - Gissa tal
static void exercise14()
{
    int answer = new Random().Next(1, 101);
    Console.Write("Gissa ett tal mellan 1-100: ");
    int guess = Int32.Parse(Console.ReadLine());
    while (guess != answer)
    {
        if (guess < answer) Console.WriteLine($"Din gissning på {guess} är lägre än svaret");
        else Console.WriteLine($"Din gissning på {guess} är större än svaret");
        Console.Write("Gissa ett nytt tal: ");
        guess = Int32.Parse(Console.ReadLine());
    }
    Console.WriteLine($"{guess} är rätt gissat!");
}

// 14. Extrauppgift 2
static void exercise14ex2()
{
    int answer = new Random().Next(1, 101);// 70
    int guess = new Random().Next(1, 101); // 50
    int high = 101;
    int low = 0;
    int guesses = 0;
    Console.WriteLine($"Computer guessed on {guess}");
    Console.WriteLine("-----------------------------------");
    do
    {
        guesses++;
        if (guess < answer)  // yes
        {
            Console.WriteLine($"{guesses}: {guess} is lower than the answer");
            low = guess; // low = 50
            guess = (guess + high) / 2; // 50+101 = 151/2 = 75
        }
        else if (guess > answer) // 75 ... 75 
        {
            Console.WriteLine($"{guesses}: {guess} is higher than the answer");
            high = guess;
            guess = (guess + low) / 2;
        }
    } while (answer != guess);
    Console.WriteLine("-----------------------------------");
    Console.WriteLine($"{guess} is correct! It took {guesses} guesses");
}

// 15. Sten, sax, påse
static void exercise15()
{
    int player;
    string[] options = { "sten", "sax", "påse" };
    Console.WriteLine("Nu ska vi spela sten, sax, påse! Skriv något annat för att avsluta");
    do
    {
        Console.WriteLine("-----------------------------------------------");
        int answer = new Random().Next(0, 3);
        Console.Write("Välj sten, sax eller påse: ");
        string choice = Console.ReadLine();
        player = Array.IndexOf(options, choice);
        int result = (player - answer);
        if (player == -1)
        {
            Console.WriteLine("Tack för att du spelade!");
        }
        else if (result == 0)
        {
            Console.WriteLine($"Det blev lika! Ni båda valde {options[player]}");
        }
        else if (result == -1 || result == 2)
        {
            Console.WriteLine($"Du vann! Du valde {options[player]} medans datorn tog {options[answer]}");
        }
        else // else if (result == 1 || result == -2) eller om man kör det som en else if.
        {
            Console.WriteLine($"Du förlorade! Datorn valde {options[answer]} och du tog {options[player]}");
        }
    } while (player != -1);
}

// Logiken jag använde för att lösa uppgift 15. stem, sax, påse
//
//  00 01 02    lika    vinst   förlust     0   -1  -2
//  10 11 12    förlust lika    vinst       1    0  -1
//  20 21 22    vinst   förlust lika        2    1   0