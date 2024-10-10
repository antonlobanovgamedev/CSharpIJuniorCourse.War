namespace CarService
{
    internal static class Colorizer
    {
        public static void WriteWithColor(string text, ConsoleColor color, bool isNewLine = true)
        {
            ConsoleColor currentColor = Console.ForegroundColor;
            Console.ForegroundColor = color;

            if(isNewLine)
                Console.WriteLine(text);
            else
                Console.Write(text);

            Console.ForegroundColor = currentColor;
        }
    }
}
