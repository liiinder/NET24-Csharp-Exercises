
// Övningsuppgifter med arv och polymorfism
// https://github.com/everyloop/NET24-Csharp/blob/master/Exercises/Arv.md

// ----------------------------------------------------------------------------------------------------
Console.WriteLine("\n--- Testkod för uppgift 1 - 5 -----------------------------------------------\n");
// ----------------------------------------------------------------------------------------------------

Vehicle bilen = new(Brand.Audi);
Vehicle andra = new(Brand.BMW, Color.Pink);

Console.WriteLine(new Vehicle(Brand.Toyota, Color.White));
Console.WriteLine(new Car(Brand.Toyota, "Yaris", Color.White));

// ----------------------------------------------------------------------------------------------------
Console.WriteLine("\n--- Testkod för uppgift 6 - 7 -----------------------------------------------\n");
// ----------------------------------------------------------------------------------------------------

var circle = new Circle(5);
Console.WriteLine(circle);
Console.WriteLine($"Area: {circle.Area:f2}");
Console.WriteLine($"Circumference: {circle.Circumference:f2}\n");

var square = new Square(5);
Console.WriteLine(square);
Console.WriteLine($"Area: {square.Area:f2}");
Console.WriteLine($"Circumference: {square.Circumference:f2}");

// ----------------------------------------------------------------------------------------------------
Console.WriteLine("\n--- Testkod för uppgift 8 ---------------------------------------------------\n");
// ----------------------------------------------------------------------------------------------------

var square2 = new Square(3.2);
square2.Print();

var circle2 = new Circle(4.5);
circle2.Print();

// ----------------------------------------------------------------------------------------------------
Console.WriteLine("\n--- Testkod för uppgift 9 - 12 ----------------------------------------------\n");
// ----------------------------------------------------------------------------------------------------

Shape[] shapes = new Shape[10];
for (int i = 0; i < shapes.Length; i++)
{
    // Enum.GetValues skapar en Array med alla färger från ConsoleColor
    // Sedan används längden på arrayen för att slumpa ett index som castas till en ConsoleColor
    var colors = Enum.GetValues(typeof(ConsoleColor));
    var color = (ConsoleColor)new Random().Next(colors.Length);

    // Skapar en random double mellan 0.1 - 9.9 med 1 decimal. (0 < sida < 10)
    double measurement = new Random().Next(1, 100) / (double)10;
    
    // Randomar mellan 0 och 1.
    bool isCircle = new Random().Next(2) > 0;

    if (isCircle) shapes[i] = new Circle(measurement, color);
    else shapes[i] = new Square(measurement, color);
}

Shape.PrintAll(shapes);
Console.WriteLine();
Shape.PrintCircles(shapes);

// --------------------------------------------------------------------------------------------------
Console.WriteLine("\n-----------------------------------------------------------------------------");
// --------------------------------------------------------------------------------------------------

// --- Kod för uppgift 1 - 5 ---
enum Brand { Audi, BMW, Citroen, VolksWagen, Mercedes, Toyota };
enum Color { Red, Green, Blue, Pink, Purple, White };
struct Size
{
    public double Length { get; set; }
    public double Width { get; set; }
    public double Height { get; set; }
    public Size(double length, double width, double height)
    { 
        Length = length;
        Width = width;
        Height = height;
    }
}
class Vehicle
{
    public Brand Brand { get; set; }
    public Color Color { get; set; }
    public Size Dimentions { get; set; }
    public Vehicle()
    {
        // Decimaltal mellan 2.5 - 7m (random double * range + offset)
        double length = new Random().NextDouble() * 4.5 + 2.5;
        double width = new Random().NextDouble() * 0.9 + 1.4;
        double height = new Random().NextDouble() * 2.7 + 0.8;
        this.Dimentions = new Size(length, width, height);
        this.Brand = Brand.Audi;
        this.Color = Color.Blue;
    }
    public Vehicle(Brand brand) : this() => this.Brand = brand;
    public Vehicle(Brand brand, Color color) : this(brand) => this.Color = color;

    //  Funkar att köra konstrukts i omvänd ordning också.
    //  --------------------------------------------------
    //  public Vehicle() : this(Brand.Audi, Color.Blue) {}
    //  public Vehicle(Brand brand) : this(brand, Color.Blue) {}
    //  public Vehicle(Brand brand, Color color)
    //  {
    //      all logik här...
    //  }

    public override string ToString() => $"A {Color} {Brand}";
}
class Car : Vehicle
{
    public string Model { get; set; }
    public Car(Brand brand, string model, Color color) : base(brand, color) => this.Model = model;
    public override string ToString()
    {
        return $"A {Color.ToString().ToLower()} {Dimentions.Length:f2} meter long {Model} from {Brand}";
    }
}

// --- Kod för uppgift 6 - 12 ---
public abstract class Shape
{
    protected ConsoleColor color = ConsoleColor.White;
    public abstract double Area { get; }
    public abstract double Circumference { get; }
    public void Print()
    {
        Console.WriteLine($"{this} has an area of {Area:f2} and a circumference of {Circumference:f2}.");
    }
    public static void PrintAll(Shape[] shapes)
    {
        foreach (Shape shape in shapes)
        {
            if (shape.color == ConsoleColor.Black) Console.BackgroundColor = ConsoleColor.DarkGray;
            Console.ForegroundColor = shape.color;

            shape.Print();
            Console.ResetColor();
        }
    }
    public static void PrintCircles(Shape[] shapes)
    {
        foreach (Shape shape in shapes) (shape as Circle)?.Print();
    }
}
class Circle : Shape
{
    public double Radius { get; set; }
    public Circle(double radius) => Radius = radius;
    public Circle(double radius, ConsoleColor color) : this(radius) => this.color = color;
    public override double Area { get => Radius * Radius * Math.PI; }
    public override double Circumference { get => Radius * 2 * Math.PI; }
    public override string ToString() => $"A circle with radius {Radius}";
}
class Square : Shape
{
    public double Side { get; set; }
    public Square(double side) => Side = side;
    public Square(double side, ConsoleColor color) : this(side) => this.color = color;
    public override double Area => Side * Side;
    public override double Circumference => Side * 4;
    public override string ToString() => $"A square with side {Side}";
}