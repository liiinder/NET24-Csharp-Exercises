namespace _241002_ClassLib
{
    public static class StringExtensions
    {
        public static int WordCount(this string s) => s.Split(' ').Length;
        public static string Encapsulate(this string s, string a) => a + s + a;
        public static string Encapsulate(this string s, string a, string b) => a + s + b;
    }
}