using RomanToArabicNumeralConverter.Common;

namespace RomanToArabicNumeralConverter
{
    internal static class Program
    {
        public static void Main(string[] args)
        {
            while (true)
            {
                // Read user input
                Console.WriteLine("Enter a Roman numeral to convert to an Arabic one, or type \"exit\" to quit:");

                var input = Console.ReadLine();

                // Exit
                if (!string.IsNullOrEmpty(input) && input.Equals("exit", StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine("Bye bye!");
                    break;
                }

                // Convert
                var result = input.ConvertToArabicNumeral();

                if (!result.Status)
                {
                    Console.WriteLine(result.Error);
                    continue;
                }

                // Respond
                Console.WriteLine($"The Arabic numeral for {input} is: {result.Data}");
            }
        }
    }
}