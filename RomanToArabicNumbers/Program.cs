namespace RomanToArabicNumbers
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            while (true)
            {
                //Read user input
                Console.WriteLine("Please write a Roman Numeral to convert to an Arabic Numeral or write \"exit\" to exit:");

                var input = Console.ReadLine();

                //Exit
                if (!string.IsNullOrEmpty(input) && input.Equals("exit", StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine("Bye bye!");
                    break;
                }

                //Convert
                var result = RomanToArabicConverter.Convert(input);

                if (!result.Status)
                {
                    Console.WriteLine(result.Error);
                    continue;
                }

                //Respond
                Console.WriteLine($"The Arabic numberal for {input} is: {result.Data}");
            }
        }
    }
}