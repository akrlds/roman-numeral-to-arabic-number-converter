namespace RomanToArabicNumbers
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Please write a Roman Numeral to convert to an Arabic Number or write \"exit\" to exit:");
                var input = Console.ReadLine();

                if (!string.IsNullOrEmpty(input) && input.Equals("exit", StringComparison.OrdinalIgnoreCase))
                {
                    break;
                }

                var result = RomanToArabicConverter.Convert(input);

                if (result.Status)
                {
                    Console.WriteLine($"The Arabic number for {input} is: {result.Data}");
                }
                else
                {
                    Console.WriteLine(result.Error);
                }
            }
        }
    }
}