using _241002_ClassLib;

Console.WriteLine("Hello World! We are ready to rumble".WordCount());
Console.WriteLine("Hello World!".Encapsulate("***"));
Console.WriteLine("Hello World!".Encapsulate("<<<", ">>>"));

//static class StringExtensions
//{
//    public static int WordCount(this string s) => s.Split(' ').Length;
//    public static string Encapsulate(this string s, string a) => a + s + a;
//    public static string Encapsulate(this string s, string a, string b) => a + s + b;
//}