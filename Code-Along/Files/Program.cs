string path = string.Empty;

path = Path.Combine("c:", "users", "linder", "source", "repos", "NET24-Csharp-Exercises", "Code-Along", "Files", "rick.bmp");
FileformatCheck(path);

path = Path.Combine("c:", "users", "linder", "source", "repos", "NET24-Csharp-Exercises", "Code-Along", "Files", "rick.png");
FileformatCheck(path);

path = Path.Combine("c:", "users", "linder", "source", "repos", "NET24-Csharp-Exercises", "Code-Along", "Files", "wow.bmp");
FileformatCheck(path);

path = Path.Combine("c:", "users", "linder", "source", "repos", "NET24-Csharp-Exercises", "Code-Along", "Files", "wow.png");
FileformatCheck(path);

path = Path.Combine("c:", "users", "linder", "source", "repos", "NET24-Csharp-Exercises", "Code-Along", "Files", "wow");
FileformatCheck(path);

path = Path.Combine("c:", "users", "linder", "source", "repos", "NET24-Csharp-Exercises", "Code-Along", "Files", "Program.cs");
FileformatCheck(path);

Console.WriteLine("\n");

static void FileformatCheck(string path)
{
    try
    {
        using (FileStream stream = File.OpenRead(path))
        {
            byte[] data = new byte[stream.Length];
            stream.Read(data);

            string firstChunk = BitConverter.ToString(data, 0, 4);

            if (firstChunk == "89-50-4E-47") // PNG
            {
                int length = 4; // Chunk - length
                int startIndex = 16; // startIndex of resolution data

                // PNG använder big-endian och BitConverter läser little-endian
                // så skapar nya arrayer med 4-byte chunken vi vill kolla i
                // Och sen vänder på arrayen för att få rätt värde

                byte[] widthSrc = new byte[length];
                byte[] heightSrc = new byte[length];

                Array.Copy(data, startIndex, widthSrc, 0, length);
                Array.Copy(data, startIndex + length, heightSrc, 0, length);

                Array.Reverse(widthSrc);
                Array.Reverse(heightSrc);

                int width = BitConverter.ToInt32(widthSrc, 0);
                int height = BitConverter.ToInt32(heightSrc, 0);

                Console.WriteLine($"This is a .png image. Resolution: {width}x{height} pixels.");
            }
            else if (firstChunk.Contains("42-4D")) // BMP
            {
                // https://www.ece.ualberta.ca/~elliott/ee552/studentAppNotes/2003_w/misc/bmp_file_format/bmp_file_format.htm

                // Byte  0 -  1 = BMP signature -> 42-4D hex -> B M ascii
                // Byte 18 - 21 = Width
                // Byte 22 - 25 = Heigth

                // BMP använder little-endian så BitConverter fungerar direkt.

                int width = BitConverter.ToInt32(data, 18);
                int height = BitConverter.ToInt32(data, 22);

                Console.WriteLine($"This is a .bmp image. Resolution: {width}x{height} pixels.");
            }
            else
            {
                Console.WriteLine("This is not a valid .bmp or .png file!");
            }    
        }
    }
    catch (FileNotFoundException ex)
    {
        Console.WriteLine("File not found.");
    }
}