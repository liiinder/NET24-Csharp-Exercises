
// Övningsuppgifter med properties
// https://github.com/everyloop/NET24-Csharp/blob/master/Exercises/Properties.md

// För att köra testkoden, ta bara bort första två tecknen /* framför Console.WriteLine raderna med "Testkod för..."
// Slutkommentaren är redan utkommenterad så den behöver inte ändras/tas bort :)

// ----------------------------------------------------------------------------------------------------
/*Console.WriteLine("\n--- Testkod för uppgift 1 - 3 -----------------------------------------------\n");
// ----------------------------------------------------------------------------------------------------
Person myself = new Person();
myself.FirstName = "Kristoffer";
Console.WriteLine(myself.FirstName);
myself.LastName = "Linder";
Console.WriteLine(myself.LastName);
Console.WriteLine(myself.FullName);
//*/
// ----------------------------------------------------------------------------------------------------
/*Console.WriteLine("\n--- Testkod för uppgift 4 ---------------------------------------------------\n");
// ----------------------------------------------------------------------------------------------------

Pedometer stegraknare = new Pedometer();
for (int i = 0; i < 1000; i++)
{
    stegraknare.Step();
}
Console.WriteLine($"Antal steg: {stegraknare.Steps}");
stegraknare.Reset();
Console.WriteLine($"Antal steg: {stegraknare.Steps}");
//*/
// ----------------------------------------------------------------------------------------------------
/*Console.WriteLine("\n--- Testkod för uppgift 5 ---------------------------------------------------\n");
// ----------------------------------------------------------------------------------------------------

Car bil1 = new Car();
Car bil2 = new Car("Audi A6", 50000, "Grå");
Console.WriteLine($"{bil2.Model} kostar {bil2.Price}");
bil2.HalfPrice();
Console.WriteLine($"{bil2.Model} kostar {bil2.Price}");
//*/
// ----------------------------------------------------------------------------------------------------
/*Console.WriteLine("\n--- Testkod för uppgift 6 ---------------------------------------------------\n");
// ----------------------------------------------------------------------------------------------------

Glass glas = new Glass();
glas.Empty();
glas.Fill();
glas.Fill();
glas.Empty();
glas.Fill();
glas.Break();
glas.Break();
glas.Fill();
glas.Empty();
//*/
// ----------------------------------------------------------------------------------------------------
/*Console.WriteLine("\n--- Testkod för uppgift 7 ---------------------------------------------------\n");
// ----------------------------------------------------------------------------------------------------

BlueRed test = new BlueRed();

Console.WriteLine("\nObjektet är instansierat och har värdena");
Console.WriteLine($"Blå: {test.Blue} - Röd: {test.Red}");
Console.WriteLine("\nÄndrar blå till 20");
test.Blue = 20;
Console.WriteLine($"Blå: {test.Blue} - Röd: {test.Red}");
Console.WriteLine("\nÄndrar röd till 3.75");
test.Red = 3.75;
Console.WriteLine($"Blå: {test.Blue} - Röd: {test.Red}");
Console.WriteLine("\nFörsöker ändra röd till -20");
test.Red = -20;
Console.WriteLine($"Blå: {test.Blue} - Röd: {test.Red}");

//*/
// ----------------------------------------------------------------------------------------------------
/*Console.WriteLine("\n--- Testkod för uppgift 8 - 9 -----------------------------------------------\n");
// ----------------------------------------------------------------------------------------------------

Car2[] cars = new Car2[1000];
for (int i = 0; i < cars.Length; i++) { cars[i] = new Car2(); }

Console.WriteLine($"Den totala längden på alla gröna bilar är {LengthOfColor(cars, ConsoleColor.Green):f2} meter");
double LengthOfColor(Car2[] cars, ConsoleColor color)
{
    double totLength = 0;
    foreach (Car2 car in cars)
    {
        if (car.Color == color) totLength += car.Length;
    }
    return totLength;
}

Car2[] tenCars = cars[5].TenCars();
//*/
// ----------------------------------------------------------------------------------------------------
/*Console.WriteLine("\n--- Testkod för uppgift 10 --------------------------------------------------\n");
// ----------------------------------------------------------------------------------------------------

Car2[] raceCars = new Car2[10];
for (int i = 0; i < raceCars.Length; i++) { raceCars[i] = new Car2(); }
Simulation(raceCars, 10000, 3);

//*/
// --------------------------------------------------------------------------------------------------
Console.WriteLine("\n-----------------------------------------------------------------------------");
// --------------------------------------------------------------------------------------------------
void Simulation(Car2[] cars, int goal = 10000, int multiplier = 1)
{
    bool run = true;
    int time = 1;
    Console.CursorVisible = false;

    while (run)
    {
        Console.Clear();
        Console.WriteLine();

        for (int i = 0; i < cars.Length; i++)
        {
            cars[i].DriveForOneHour();

            Console.ForegroundColor = cars[i].Color;
            Console.Write($"   Car {i + 1,2} ");
            Console.ResetColor();

            foreach (char c in cars[i].GetGraph(goal))
            {
                if (c == 'X')
                {
                    Console.ForegroundColor = cars[i].Color;
                    Console.Write('\u25A0');
                    Console.ResetColor();
                }
                else Console.Write(c);
            }
            if (cars[i].Distance >= goal)
            {
                Console.Write(" - Winner!");
                run = false;
            }
            Console.WriteLine();
        }
        Console.WriteLine($"   Time passed: {time} hour{((time == 1) ? "" : "s")}");
        Thread.Sleep(1000 / multiplier);
        time++;
    }
    Console.WriteLine("\n\n");
    Console.CursorVisible = true;
}
class Person
{
    private string _firstName;
    public string FirstName
    {
        get
        {
            return _firstName;
        }
        set
        {
            _firstName = value;
        }
    }
    public string LastName { get; set; }
    public string FullName
    {
        get
        {
            return $"{FirstName} {LastName}";
        }
    }

}
class Pedometer
{
    private int _steps;
    public int Steps { get => _steps; }
    public void Step() => _steps++;
    public void Reset() => _steps = 0;
}
class Car
{
    public string Model { get; set; }
    public int Price { get; set; }
    public string Color { get; set; }
    public Car() { }
    public Car(string model, int price, string color)
    {
        Model = model;
        Price = price;
        Color = color;
    }
    public void HalfPrice() => Price /= 2;
}
class Glass
{
    private bool hasWater;
    private bool isBroken;
    public void Status()
    {
        string liquid = (hasWater) ? "Glaset är fullt" : "Glaset är tomt";
        string whole = (isBroken) ? " och trasigt" : " och helt";
        Console.WriteLine(liquid + whole);
    }
    public void Fill()
    {
        if (isBroken) Console.WriteLine("Glaset kan inte fyllas, eftersom det är trasigt");
        else if (hasWater) Console.WriteLine("Glaset är redan fullt");
        else
        {
            Console.WriteLine("Fyller glaset");
            hasWater = true;
        }
    }
    public void Empty()
    {
        if (isBroken) Console.WriteLine("Glaset är trasigt");
        else if (hasWater) Console.WriteLine("Tömmer glaset");
        else Console.WriteLine("Glaset är redan tomt");
        hasWater = false;
    }
    public void Break()
    {
        if (!isBroken)
        {
            if (hasWater) Console.WriteLine("Glaset går sönder, och vattnet rinner ut på golvet");
            else Console.WriteLine("Glaset går sönder, det var tomt");
            isBroken = true;
            hasWater = false;
        }
        else Console.WriteLine("Glaset är redan trasigt");
    }
}
class BlueRed
{
    private double _blue = 50;
    public double Red
    {
        get => 100 - Blue;
        set
        { 
            if (0 <= value && value <= 100) Blue = 100 - value;
        } 
        
    }
    public double Blue
    {
        get => _blue;
        set 
        {
            if (0 <= value && value <= 100) _blue = value;
        } 
    }
}
class Car2
{
    public ConsoleColor Color { get; set; }
    public double Length { get; set; }
    public int Speed { get; set; }
    public int Distance { get; set; }
    public Car2()
    {
        Color = (ConsoleColor)new Random().Next(1, 16); // Random 1-15 (excluding 0, no black cars allowed
        Length = new Random().Next(300, 501) / (double)100; // Delat på en (double)/100 för att få ett decimaltal mellan 3.00 och 5.00
        Speed = new Random().Next(60, 241);
        Distance = 0;
    }
    public Car2(ConsoleColor color) : this() => Color = color;
    public Car2[] TenCars()
    {
        Car2[] cars = new Car2[10];
        for (int i = 0; i < cars.Length; i++)
        {
            cars[i] = new Car2(this.Color);
        }
        return cars;
    }
    public void DriveForOneHour() => Distance += Speed;
    public string GetGraph(float goal)
    {
        char[] output = $"──────────────────── {Distance,5} km".ToCharArray();
        int road = Array.IndexOf(output, ' ') - 1;

        // En ternary för att räkna ut vilket index vi ska sätta bilen på är vi i mål sätter vi det till sista indexet,
        // detta för att aldrig sätta den förbi "målet"
        float position = ((Distance / goal >= 1) ? road : Distance / goal * road);

        output[(int)position] = 'X';

        return new String(output);
    }
}