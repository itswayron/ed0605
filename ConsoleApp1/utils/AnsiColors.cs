namespace aps01
{
    public static class AnsiColors
    {
        // Reset
        public const string Reset = "\u001b[0m";

        // Text colors
        public const string Black = "\u001b[30m";
        public const string Red = "\u001b[31m";
        public const string Green = "\u001b[32m";
        public const string Yellow = "\u001b[33m";
        public const string Blue = "\u001b[34m";
        public const string Magenta = "\u001b[35m";
        public const string Cyan = "\u001b[36m";
        public const string White = "\u001b[37m";

        public static void WriteLine(string text, string color = null)
        {
            string output = "";

            if (!string.IsNullOrEmpty(color))
                output += color;

            output += text + Reset;

            Console.WriteLine(output);
        }

        public static void Write(string text, string color = null)
        {
            string output = "";
            if (!string.IsNullOrEmpty(color))
                output += color;
            output += text + Reset;
            Console.Write(output);
        }

        public static void PrintMenu(List<string> options, string header = null)
        {
            if (header != null)
            {
                WriteLine($"======= {header} =======", Cyan);
            }

            WriteLine("0. Sair.", Red);

            for (int i = 0; i < options.Count; i++)
            {
                Console.WriteLine($"{Yellow}{i + 1}.{Reset} {Green}{options[i]}{Reset}");
            }
        }
    }
}