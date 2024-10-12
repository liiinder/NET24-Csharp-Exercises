
// Använd generiska delegat ( Func (retur). Action (inget retur) ...
//Func<in T1, in T2, out TResult>
//Action<in T1, in T2...>

using System.Xml.Linq;

static void SumOf(int a, int b) { Console.WriteLine(a + b); }
static string Chars(char c, int n) => new string(c, n);

Console.WriteLine("\n--- Uppgift 1 ---");
Action<int, int> printSum = SumOf;
printSum(1, 5);

Console.WriteLine("\n--- Uppgift 2 ---");
Func<char, int, string> printChar = Chars;
Console.WriteLine(printChar('c', 5));

Console.WriteLine("\n--- First, First or default ---");
int[] numbers = { 9, 34, 65, 92, 87, 435, 3, 54,
                    83, 23, 87, 435, 67, 12, 19 };

int first = numbers.First(number => number > 80);
int second = numbers.FirstOrDefault(number => number < 0);


Console.WriteLine(first);
Console.WriteLine(second);

Console.WriteLine("\n--- Event ---");

Publisher publisher = new();
Subscriber subs1 = new("Kalle");
Subscriber subs2 = new("Pelle");
Subscriber subs3 = new("Olle");

publisher.Message += subs1.OnMessageRecieved;
publisher.Message += subs2.OnMessageRecieved;
publisher.Message += subs3.OnMessageRecieved;

publisher.SendMessage("Hello everyone!");
// ta bort...
publisher.Message -= subs2.OnMessageRecieved;

Console.WriteLine();
publisher.SendMessage("Bye!");