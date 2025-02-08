namespace RomanToArabicNumbers
{
    public static class RomanToArabicConverter
    {
        private static readonly ConversionTools _conversionTools = new();

        public static ResultDTO Convert(string? input)
        {
            if (String.IsNullOrEmpty(input))
            {
                return new ResultDTO("Invalid input: cannot be empty or null");
            }

            input = input.Trim().ToUpper();

            if (!_conversionTools.CheckRepetitionIntegrityOfRomanNumber(input))
            {
                return new ResultDTO($"Invalid repetitions in Roman Number: {input}");
            }

            var numbers = new List<int>();

            foreach (var character in input)
            {
                if (_conversionTools.romanToArabicDictionary.ContainsKey(character))
                {
                    numbers.Add(_conversionTools.romanToArabicDictionary[character]);
                }
                else
                {
                    return new ResultDTO($"Invalid character found in Roman Number: {input}");
                }
            }

            if (!_conversionTools.CheckSubtractionIntegrityOfRomanNumber(numbers))
            {
                return new ResultDTO($"Invalid subtraction in Roman Number: {input}");
            }

            var total = 0;
            for (int i = 0; i < numbers.Count; i++)
            {
                if (i < numbers.Count - 1 && numbers[i] < numbers[i + 1])
                {
                    total += numbers[i + 1] - numbers[i];
                    i++;
                }
                else
                {
                    total += numbers[i];
                }
            }

            return new ResultDTO(total);
        }
    }
}