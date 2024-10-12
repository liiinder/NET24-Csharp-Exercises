foreach (ConsoleColor c in Enum.GetValues(typeof(ConsoleColor)))
{
    string s = c.ToString();
    int w = 15;
    int p = w - s.Length;
    s = s.PadLeft((p / 2) + s.Length).PadRight(w);
    Console.ForegroundColor = ConsoleColor.Gray;
    Console.BackgroundColor = c;
    Console.Write(s);
    Console.BackgroundColor = ConsoleColor.Black;
    Console.ForegroundColor = c;
    Console.Write(s);
    Console.BackgroundColor = c;
    Console.Write(s + "\n");
}
Console.ResetColor();

Console.WriteLine(DateTime.Now);

//Console.ReadKey(true);
//Console.WriteLine(Console.BufferWidth + "height" + Console.BufferHeight);
//Console.WriteLine(new string('?', Console.BufferWidth));
////Console.ReadKey(true);
//Console.WriteLine(Console.BufferWidth + "height" + Console.BufferHeight);
//Console.WriteLine(new string('?', Console.BufferWidth));

string[] dices = {
" ",
"xxxxx x*xxx xxx*x x*x*x x*x*x x*x*x",
"xx*xx xxxxx xx*xx xxxxx xx*xx x*x*x",
"xxxxx xxx*x x*xxx x*x*x x*x*x x*x*x",
" ",
"xxxxx x2xxx xxx3x x4x4x x5x5x x6x6x",
"xx1xx xxxxx xx3xx xxxxx xx5xx x6x6x",
"xxxxx xxx2x x3xxx x4x4x x5x5x x6x6x",
" ",
"xxx xxx xxx xxx xxx xxx",
"x1x x2x x3x x4x x5x x6x",
"xxx xxx xxx xxx xxx xxx"
};

foreach (string row in dices)
{
    foreach (char c in row)
    {
        if (c == ' ') Console.BackgroundColor = ConsoleColor.Black;
        else Console.BackgroundColor = ConsoleColor.Yellow;

        if (char.IsAsciiDigit(c) || c == '*') Console.ForegroundColor = ConsoleColor.Red;
        else Console.ForegroundColor = ConsoleColor.Yellow;
        Console.Write(c);
    }
    Console.WriteLine();
}

Console.ResetColor();