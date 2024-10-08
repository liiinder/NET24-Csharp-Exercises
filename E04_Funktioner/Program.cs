﻿
using System.Globalization;

string hello = "Hello World!";



// Övningsuppgifter med funktioner
// https://github.com/everyloop/NET24-Csharp/blob/master/Exercises/Funktioner.md

//Exercise1();
//Exercise2();
//Exercise3();
//Exercise4();
//Exercise5();
//Exercise6();
//Exercise7();
//Exercise8();
//Exercise9();
//Exercise10();
//Exercise11();
//Exercise12();
//Exercise12extra();
//Exercise13();

//## 1. Slå ihop för- och efternamn
static void Exercise1() 
{
    //Skriv en funktion som tar två parametrar: firstName och lastName. Funktionen ska skriva ut hela namnet på skärmen. Testa genom att anropa funktionen med ditt namn.
    
    //**Exempel
    //PrintName("Fredrik", "Johansson");
    //```
    //*Skriver ut: *Fredrik Johansson
    static void NameConcat(string firstName, string lastName) => Console.WriteLine($"{firstName} {lastName}");

    NameConcat("Kristoffer", "Linder");
    NameConcat("Irene", "Linder");
    NameConcat("Martin", "Andersson");
}

//## 2. Slå ihop för- och efternamn - returnera
static void Exercise2()
{
    //Skriv om funktionen ovan så att den istället för att skriva ut namnet returnerar en string med hela namnet. Anropa funktionen och skriv ut returvärdet.
    static string NameConcat(string firstName, string lastName) => $"{firstName} {lastName}";

    string namn1 = NameConcat("Kristoffer", "Linder");
    Console.WriteLine(NameConcat("Irene", "Linder"));
    Console.WriteLine(namn1);
}

//## 3. Kolla om stängen är längre än ett givet antal tecken.
static void Exercise3()
{
    //Skriv en funktion som tar in en sträng och ett heltal. Om längden på strängen är större än heltalet returnera true, annars false.
    static bool LengthCheck(string input, int length) => (input.Length > length);

    Console.WriteLine($"Är \"Kristoffer\" längre än 5 tecken? {LengthCheck("Kristoffer", 5)}");
}

//## 4. Omvandla Celsius till Fahrenheit
static void Exercise4()
{
    //Skriv en funktion som översätter ett värde från Celsius till Fahrenheit. Både in-parameter och returvärde ska vara av datatyp double.
    static double CelciusToFahrenheit(double celcius) => (celcius * 1.8) + 32;

    Console.WriteLine($"20 celcius är {CelciusToFahrenheit(20)} fahrenheit");
    Console.WriteLine($"40.3 celcius är {CelciusToFahrenheit(40.3)} fahrenheit");
    Console.WriteLine($"-20.5 celcius är {CelciusToFahrenheit(-20.5)} fahrenheit");
}

//## 5. Lägg in bindesträck mellan tecken i en sträng
static void Exercise5()
{
    //Skriv en funktion som tar in en sträng och returnerar en sträng med ett bindestreck mellan varje tecken. T.ex om man skickar in “Fredrik” , så returnerar den “F-r-e-d-r-i-k”
    static string HyphenAdder(string input)
    {
        string joinedString = "";
        for (int i = 0; i < input.Length; i++)
        {
            joinedString += (i != input.Length - 1) ? input[i] + "-": input[i]; // Kortare variant av den utkommenterade koden under

            //if (i != input.Length - 1) // Alla tecken förutom sista, detta då sista index är 1 mindre än längden på arrayen.
            //{
            //    joinedString += $"{input[i]}-";
            //}
            //else // Då är vi på sista tecknet
            //{
            //    joinedString += input[i];
            //}
        }
        return joinedString;
    }
    string test = HyphenAdder("Testing");
    Console.WriteLine(test);
}

//## 6. Egen version av String.Join();
static void Exercise6()
{
    //Skriv en egen funktion som fungerar på samma sätt som String.Join();

    //**Exempel:**
    //```
    //MyJoin("->", "Sverige", "Norge", "Finland");
    //```
    //*Returvärde:*"Sverige->Norge->Finland"
    
    static string MyJoin(string joiner, params string[] inputs)
    {
        string joinedString = "";
        for (int i = 0; i < inputs.Length; i++)
        {
            joinedString += (i != inputs.Length - 1) ? inputs[i] + joiner : inputs[i];
        }
        return joinedString;
    }

    Console.WriteLine(MyJoin("->", "Kristoffer", "Martin", "Irene", "Joakim", "Bengt-Åke"));
    Console.WriteLine(MyJoin(" <-> ", "Jag", "kanske", "kan", "skriva", "koden", "lite", "enklare"));
}

//## 7. Beräkna medelvärde av int-array
static void Exercise7()
{
    //Skriv en funktion som tar en int[] in, och returnerar medelvärdet som en double.
    static double Average(int[] values)
    {
        double sum = 0;
        foreach (int number in values)
        {
            sum += number;
        }
        return sum / values.Length;
    }
    Console.WriteLine($"Medelvärdet är: {Average([10, 9, 3, 20, -2])}");
}

//## 8. Siffror till text
static void Exercise8()
{
    //Skriv en funktion som tar ett heltal in, och returnerar en string[] där varje element innehåller ordet för varje siffra i talet.
    //**Exempel:**
    //```
    //NumberToWords(6543);
    //```
    //*Returvärde:* { "sex", "fem", "fyra", "tre"}
    static string[] NumberToWords(int numberInt)
    {
        string numberString = numberInt.ToString();

        string[] words = new string[numberString.Length];
        for (int i = 0; i < numberString.Length; i++)
        {
            if (numberString[i] == '0') words[i] = "noll";
            else if (numberString[i] == '1') words[i] = "ett";
            else if (numberString[i] == '2') words[i] = "två";
            else if (numberString[i] == '3') words[i] = "tre";
            else if (numberString[i] == '4') words[i] = "fyra";
            else if (numberString[i] == '5') words[i] = "fem";
            else if (numberString[i] == '6') words[i] = "sex";
            else if (numberString[i] == '7') words[i] = "sju";
            else if (numberString[i] == '8') words[i] = "åtta";
            else if (numberString[i] == '9') words[i] = "nio";
            else if (numberString[i] == '-') words[i] = "minus";
        }
        return words;
    }

    foreach (string number in NumberToWords(-985631))
    {
        Console.Write($"\"{number}\" ");
    }
}

//## 9. Heltal till text
static void Exercise9()
{
//  Skriv en funktion som tar en *ushort* som parameter, och returnerar en sträng med numret utskrivet i ord.

//  ushort = 0 -> 65535

//  **Exempel:**
//  ```
//  IntegerToText(6543);
//  ```
//  *Returvärde:*"six thousand five hundred forty three"

//  https://www.c-sharpcorner.com/blogs/convert-number-to-words-in-c-sharp
//  Copy paste most from this.
    static string NumberToWords(ushort i) // Takes a number between 0 - 65535
    {
        String[] units = { "Zero", "One", "Two", "Three",
            "Four", "Five", "Six", "Seven", "Eight", "Nine", "Ten", "Eleven",
            "Twelve", "Thirteen", "Fourteen", "Fifteen", "Sixteen",
            "Seventeen", "Eighteen", "Nineteen" };

        String[] tens = { "", "", "Twenty", "Thirty", "Forty",
            "Fifty", "Sixty", "Seventy", "Eighty", "Ninety" };

        if (i < 20)
        {
            return units[i];
        }
        if (i < 100)
        {
            return tens[i / 10] + ((i % 10 > 0) ? " " + NumberToWords((ushort)(i % 10)) : "");
        }
        if (i < 1000)
        {
            return units[i / 100] + " Hundred"
                    + ((i % 100 > 0) ? " And " + NumberToWords((ushort)(i % 100)) : "");
        }
        return NumberToWords((ushort)(i / 1000)) + " Thousand"
                    + ((i % 1000 > 0) ? " " + NumberToWords((ushort)(i % 1000)) : "");
    }
    Console.WriteLine(NumberToWords((ushort)31235));
    Console.WriteLine(NumberToWords((ushort)1000));
    Console.WriteLine(NumberToWords((ushort)503));
}

//## 10. Hitta index för alla förekomster av ett givet tecken.
static void Exercise10()
{
//  Skapa funktionen int[] IndexesOf(string text, char c) som söker igenom strängen text och returnerar en int[] med index till alla förekomster av *c* i *text*.

//  **Exempel:**
//  ```
//  IndexesOf("Hello World!", 'o');
//  ```
//  *Returvärde:* { 4, 7}
    static int[] IndexesOf(string input, char c)
    {
        string result = string.Empty;
        for (int i = 0; i < input.Length; i++)
        {
            int nextIndex = input.Substring(i).IndexOf(c);
            // i=0 -> Substring(i) -> "Hello World!" indexOf(c) -> 4
            // i += nextIndex ...
            // i=5 -> Substring(i) -> " World!" indexOf(c) -> 2 + i = 7
            // i += nextIndex ...
            // i=8 -> Substring(i) -> "rld!" indexOf(c) -> -1 breal;
            if (nextIndex < 0) break;
            else i += nextIndex;
            result += i;
        }
        int[] resArray = new int[result.Length];
        for (int i = 0; i < resArray.Length; i++)
        {
            resArray[i] = Int32.Parse(result[i].ToString());
        }
        return resArray;
    }

    PrintIntArray(IndexesOf("Hello World!", 'o'));
    PrintIntArray(IndexesOf("Hello World!", 'l'));
}

//## 11. Kasta tärning
static void Exercise11()
{
//  Skriv en funktion ThrowDice() som returnerar ett slumpmässigt heltal 1-6.
//  Skriv en annan funktion ThrowMultipleDice(int n) som returnerar resultatet av att man slagit *n* tärningar.
//  ***Extra utmaning:****Lägg till en frivillig(optional) int på båda funktionerna, där man kan ange antal sidor på tärningen (default 6).*
//  ***Tips:***Kolla exempelkoden för[Random.Next()](https://learn.microsoft.com/en-us/dotnet/api/system.random.next?view=net-8.0) för att få ut slumpmässiga heltal. 
    static int[] ThrowMultipleDice(int amount, int sides = 6)
    {
        if (sides <= 1) sides = 2; // We don't want a result that is less than a coin flip.
        int[] result = new int[amount];

        for (int i = 0; i < amount; i++)
        {
            result[i] = new Random().Next(1, (sides + 1));
        }
        return result;
    }

    for (int i = 0; i < 10; i++)
    {
        PrintIntArray(ThrowMultipleDice(5));
    }
}

//## 12. Rita en box
static void Exercise12()
{
    //Skriv en funktion *DrawBox(int width, int height)*.
    //När man anropar funktionen ska den skriva ut en rektangel där de yttre tecknen består av ‘#’ och de inre av ‘-’.

    //**Exempel:**DrawBox(7, 4);
    //```
    //#######
    //#-----#
    //#-----#
    //#######
    //```
    DrawBox(5, 10);
    DrawBox(7, 7);
}

static void DrawBox(int width, int height)
{
    for (int i = 1; i <= height; i++)
    {
        for (int j = 1; j <= width; j++)
        {
            if (i == 1 || i == height || j == 1 || j == width) Console.Write('#');
            else Console.Write('-');
        }
        Console.WriteLine();
    }
    Console.WriteLine();
}

static void Exercise12extra()
{
//  ***Extrauppgift:
//  ****Uppdatera funktionen och lägg till parametrar left och top
//  (för positionen på översta vänstra hörnet av boxen.
//  Skriv en loop som printar ut rektanglar med random storlek och position på skärmen.*

//  ***Tips:****Använd
//  [Console.SetCursorPosition();](https://learn.microsoft.com/en-us/dotnet/api/system.console.setcursorposition?view=net-8.0)
//  för att flytta Cursorn,
//  d.v.s var nästa tecken ska skrivas. Om du vill kan du även dölja cursorn genom att sätta
//  [Console.CursorVisible = false;](https://learn.microsoft.com/en-us/dotnet/api/system.console.cursorvisible?view=net-8.0)*

//  ***Tips:****Använd[Thread.Sleep(n);](https://learn.microsoft.com/en-us/dotnet/api/system.threading.thread.sleep?view=net-8.0)
//  för att lägga in en fördröjning på n millisekunder innan nästa rektangel ritas ut.*
    Console.CursorVisible = false;
    while (!Console.KeyAvailable)
    {
        SetRandomConsoleColor();
        DrawRandomSizeBox(3, 15);
        Thread.Sleep(50);
    }
    Console.CursorVisible = true;
    Console.ResetColor();
}

static void DrawBoxAtPlace(int width, int height, int left, int top)
{
    int origWidth = Console.WindowWidth - 1;
    int origHeight = Console.WindowHeight - 1;
    int startIndexJ = 1;

    for (int i = 1; i <= height; i++)
    {
        if (top < 0)
        {
            i += Math.Abs(top) - 1;
            top = 0;
        }
        if (left < 0)
        {
            startIndexJ += Math.Abs(left);
            left = 0;
        }
        Console.SetCursorPosition(left, top);
        for (int j = startIndexJ; j <= width; j++)
        {
            if (i == 1 || i == height ||
                j == 1 || j == width) Console.Write('#');
            else Console.Write('-');
            if (Console.GetCursorPosition().Left == origWidth) break;
        }
        if (top == origHeight) break;
        top++;
    }
static void DrawBoxAtPlace(int width, int height, int left, int top)
{
    int origWidth = Console.WindowWidth - 1;
    int origHeight = Console.WindowHeight - 1;
    int startIndexJ = 1;

    for (int i = 1; i <= height; i++)
    {
        if (top < 0)
        {
            i += Math.Abs(top) - 1;
            top = 0;
        }
        if (left < 0)
        {
            startIndexJ += Math.Abs(left);
            left = 0;
        }
        Console.SetCursorPosition(left, top);
        for (int j = startIndexJ; j <= width; j++)
        {
            if (i == 1 || i == height ||
                j == 1 || j == width) Console.Write('#');
            else Console.Write('-');
            if (Console.GetCursorPosition().Left == origWidth) break;
        }
        if (top == origHeight) break;
        top++;
    }
}
}

static void DrawColoredBoxAtPlace(int width, int height, int left, int top, ConsoleColor frame, ConsoleColor inside)
{
    int origWidth = Console.WindowWidth - 1;
    int origHeight = Console.WindowHeight - 1;
    int startIndexJ = 1;

    for (int i = 1; i <= height; i++)
    {
        if (i == 1 || i == height)
        {
            Console.ForegroundColor = frame;
            Console.BackgroundColor = frame;
        }
        if (top < 0)
        {
            i += Math.Abs(top) - 1;
            top = 0;
        }
        if (left < 0)
        {
            startIndexJ += Math.Abs(left);
            left = 0;
        }
        Console.SetCursorPosition(left, top);
        for (int j = startIndexJ; j <= width; j++)
        {
            if (i == 1 || i == height);
            else if (j == 1 || j == width)
            {
                Console.ForegroundColor = frame;
                Console.BackgroundColor = frame;
            }
            else if (j == 2 )
            {
                Console.ForegroundColor = inside;
                Console.BackgroundColor = inside;
            }

            if (i == 1 || i == height ||
                j == 1 || j == width) Console.Write('#');
            else Console.Write('-');
            if (Console.GetCursorPosition().Left == origWidth) break;
        }
        if (top == origHeight) break;
        top++;
    }
    ResetColor();
}

static void DrawRandomSizeBox(int min, int max)
{
    int width = new Random().Next(min, max + 1);
    int height = new Random().Next(min, max + 1);
    int left = new Random().Next(-(width / 2), Console.WindowWidth - (width / 2));
    int top = new Random().Next(-height / 2, Console.WindowHeight - (height / 2));
    DrawBoxAtPlace(width, height, left, top);
}

static void SetRandomConsoleColor()
{
    var consoleColors = Enum.GetValues(typeof(ConsoleColor));
    var color = (ConsoleColor)consoleColors.GetValue(new Random().Next(consoleColors.Length));
    Console.BackgroundColor = color;
    Console.ForegroundColor = color;
}

//## 13. Flytta runt ett @ med piltangenterna.
static void Exercise13()
{
    ResetColor();
    Console.Clear();
    //  Låt oss skriva början till ett enkelt spel:
    int width = Console.WindowWidth - 2;
    int height = Console.WindowHeight - 2;
    int left = 1;
    int top = 1;
    ConsoleColor inside = ConsoleColor.Gray;
    ConsoleColor frame = ConsoleColor.Magenta;
    DrawColoredBoxAtPlace(width, height, left, top, frame, inside);
//  Använd DrawBox-funktionen i föregående uppgift för att rita en box på skärmen.
//  Placera sedan ett @ i mitten av boxen. Om man använder piltangenterna ska man kunna flytta runt @.
//  När den kommer till kanten av boxen så ska den inte kunna gå längre åt det hållet.

//  ***Tips:****För att flytta @ behöver du skriva ‘-’ på dess tidigare position och ‘@’ på den nya positionen.
//  Spara bredd och höjd på boxen så du vet när den ska stanna.*

//  ***Tips:****Kolla upp[Console.ReadKey();](https://learn.microsoft.com/en-us/dotnet/api/system.console.readkey?view=net-8.0)
//  och [Console.KeyAvailable;](https://learn.microsoft.com/en-us/dotnet/api/system.console.keyavailable?view=net-8.0)*

}

//## 14. Masken
static void Exercise14()
{
//Skriv om DrawBox() så den istället returnerar en 2D-array av char med tecknen som den tidigare skrev ut på displayen. Man ska också kunna mata in en tredje parameter för antal slumpade ‘#’.
//Om man anger t.ex 5 så ska 5 stycken extra ‘#’ slumpas ut på random ställen inne i boxen. 

//Skriv sedan en annan funktion som tar och ritar ut arrayen på skärmen. Fixa så man kan flytta runt @ med piltangenterna. Jämför positionen mot arrayen och gör så man inte kan gå på någon '#'.

//***Extra utmaning:****Gör en "orm" av '@'. När man flyttar positionen på @ så följer (t.ex) 5 andra @ efter i samma spår som man förflyttat sig.*

//***Extra utmaning 2:****I det klassiska spelet "masken" (snake) förflyttar sig en mask i jämna tidsintervall i den riktning spelaren senast angav med piltangenterna.
//Någonstans på banan finns ett äpple masken ska äta. Det gäller för spelaren att ta sig dit utan att krocka med något hinder,
//eller sin egen svans. När man tar äpplet blir masken längre och ett nytt äpple dyker upp på slumpvis vald plats på banan.*

//*Implementera din egen version av spelet. Försök dela in koden i lämpliga funktioner.*

//***Förslag:****När du fått en första version av spelet att fungera, lägg till flera banor genom att hårdkoda in olika banlayout i olika 2D-arrayer.
//När man tagit ett visst antal äpplen på en bana så kommer man vidare till nästa.*
}

static void PrintIntArray(int[] arr)
{
    string result = string.Join(", ", arr);
    Console.WriteLine($"{{{result}}}");
}

static void ResetColor()
{
    Console.ForegroundColor = ConsoleColor.Gray;
    Console.BackgroundColor = ConsoleColor.Black;
}