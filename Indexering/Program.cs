﻿//exercise1();
//exercise2();
//exercise2extra();
exercise3();
//exercise4();
//exercise5();
//exercise6();
//exercise7();
//exercise8();
//exercise9();
//exercise10();
//exercise11();
//exercise12();

//# Övningsuppgifter med indexering av strängar och arrayer

//## 1. En bokstav på varje rad
static void exercise1()
{
    Console.Write("Skriv något: ");
    string input = Console.ReadLine();
    //for (int i = 0; i < input.Length; i++) Console.WriteLine(input[i]);
    foreach (char c in input) Console.WriteLine(c); // foreach känns lite enklare att förstå vid snabb överblick.
}

//## 2. Siffror till text
static void exercise2()
{
    Console.Write("Skriv in ett heltal (0 - 9): ");
    string[] nummer = { "noll", "ett", "två", "tre", "fyra", "fem", "sex", "sju", "åtta", "nio" };
    int input = Int32.Parse(Console.ReadLine());
    Console.WriteLine($"{nummer[input]}");
}

//***Extra utmaning:****Användaren kan mata in en sträng med fritt antal siffror, om man skriver in t.ex 432 så svarar programmet: "fyra - tre - två".*
static void exercise2extra()
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
static void exercise3()
{
    Console.Write("Skriv något: ");
    string input = Console.ReadLine();
    // Lösning med både for och foreach. For loopen blir lite "tydligare" då den inte använder en metod (reverse()) för att vända på stringen/arrayen.
    //for (int i = input.Length - 1; i >= 0; i--) Console.WriteLine(input[i]);
    foreach (char c in input.Reverse()) Console.Write(c);
}

//## 4. Dölj vokaler

//Be användaren mata in en text. Skriv ut texten med alla vokaler ersatta med *

//**Exempel:**
//```
//Skriv något: Hejsan, jag heter Fredrik!
//H*js*n, j*g h*t*r Fr*dr*k!
//```
//***Extra utmaning:****Skriv ut texten översatt till [rövarspråket] (https://sv.wikipedia.org/wiki/R%C3%B6varspr%C3%A5ket).*

//## 5. Palindrom

//Ett palindrom är ett ord som blir samma framlänges som baklänges. Be användaren skriva in ett ord och ange sedan om det är ett palindrom eller inte.

//**Exempel:**
//```
//Skriv ett ord: Kajak
//Kajak är ett palindrom.
//```

//## 6. Miniräknare

//Skapa en enkel miniräknare som kan hantera de fyra räknesätten med två operander. Till skillnad från [uppgift 6 i övningsuppgifter med variabler] (https://github.com/everyloop/NET24-Csharp/blob/master/Exercises/Variabler.md), så ska inmatningen nu ske på en rad (första talet, operator, andra talet). Ignorera inmatade mellanslag i strängen. Om man t.ex. matar in strängen "34 - 14", så ska programmet skriva ut "= 20".

//**Exempel:**
//```
//Vad vill du räkna ut? 15 * 4
//= 60
//```

//## 7. Omvänd ordning

//Be användaren skriva in ett ord, sedan ett till, och ett till; tills man skrivit in 7 ord. Skriv sedan ut orden på skärmen i bakvänd ordning mot hur de matades in. Alltså ordet man skrev in sist, skrivs ut först.

//## 8. Fördröjd utskrift

//Skapa ett program som ber användaren att skriva in ett ord. Sedan ett till, och ett till i all evighet. Varje gång man skrivit in ett ord så ska programmet skriva ut det ord man skrev 10 inmatningar tidigare. Men om man inte skrivit in 10 ord än så kan den istället skriva just det: "Du har inte skrivit in 10 ord än."

//## 9. Bokstavspyramid

//Skapa ett program som skriver ut första tecknet i "Hello World" på första raden, de 2 första tecknen på andra raden osv.

//**Exempel:**
//```
//H
//He
//Hel
//...
//Hello Worl
//Hello World
//```

//## 10. Färgade bokstäver

//Man kan byta färg som används för utskrift i console med hjälp av Console.ForegroundColor (t.ex Console.ForegroundColor = ConsoleColor.Red)

//Skapa ett program som ber användaren mata in en text. Be sedan användaren mata in en bokstav. Skriv ut strängen som matades in; de bokstäver som är samma som den användaren valde ska skriva ut med röd färg, alla andra med grå..

//**Exempel:**

//Mata in en text: Hejsan hoppsan!  
//Välj en bokstav: s
//Hej<span style = "color:red" > s </ span > an hopp<span style="color:red">s</span>an!

//***OBS!*** *Färgkodning i markdown verkar inte visas på GitHub. Check ut och visa denna filen i visual studio eller visual studio code istället!*

//## 11. Start & Stop

//Be användaren mata in en text. Be sedan om ett startindex, och sedan om ett stopindex. Skriv ut hela texten, men alla tecken från startindex till stopindex ska vara röda.

//**Exempel:**

//Mata in en text: Detta är en text  
//Välj startindex: 3
//Välj stopindex: 9
//Det<span style = "color:red" > ta är e</span>n text

//## 12. Växla färg

//Be användaren mata in en text. Be sedan användaren mata in en bokstav. Skriv ut hela texten, rödmarkera från första stället den hittar bokstaven till andra stället den hittar bokstaven, från tredje stället till fjärde o.s.v.

//**Exempel:**

//Mata in text: How much wood would a woodchuck chuck if a woodchuck could chuck wood?  
//Välj bokstav: o

//H<span style = "color:red" > ow much wood wo</span>uld a w<span style="color:red">oo</span>dchuck chuck if a w<span style="color:red">oo</span>dchuck c<span style="color:red">ould chuck wo</span>od?