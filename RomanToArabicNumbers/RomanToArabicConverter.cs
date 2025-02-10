namespace RomanToArabicNumbers
{
    public static class RomanToArabicConverter
    {
        public static ResultDto<int> Convert(string? input)
        {
            //Check null or empty
            if (String.IsNullOrEmpty(input))
            {
                return new ResultDto<int>($"Invalid input: {input}");
            }

            input = input.Trim().ToUpper();

            //Check repetition validity
            var checkRepetitionValidity = CheckRepetitionValidity(input);

            if (!checkRepetitionValidity.Status)
            {
                return new ResultDto<int>($"{checkRepetitionValidity.Error}: {input}");
            }

            //Get numbers from the numeral
            var getNumbersList = GetNumbersFromNumberal(input);

            List<int>? numbers;

            if (getNumbersList.Status)
            {
                numbers = getNumbersList.Data;
            }
            else
            {
                return new ResultDto<int>($"{getNumbersList.Error}: {input}");
            }

            //Check subtraction validity
            var checkSubtractionValidity = CheckSubtractionValidity(numbers);

            if (!checkSubtractionValidity.Status)
            {
                return new ResultDto<int>($"{checkSubtractionValidity.Error}: {input}");
            }

            //Get the total
            var getTotal = GetTotal(numbers);

            if (!getTotal.Status)
            {
                return new ResultDto<int>($"{getTotal.Error}: {input}");
            }

            return new ResultDto<int>(getTotal.Data);
        }

        private static Dictionary<char, int> RomanToArabicDictionary { get; } = new Dictionary<char, int> {
                        {'I', 1},
                        {'V', 5},
                        {'X', 10},
                        {'L', 50},
                        {'C', 100},
                        {'D', 500},
                        {'M', 1000},
                    };

        private static ResultDto<bool> CheckRepetitionValidity(string romanNumber)
        {
            //Check repetition validity
            string[] invalidRepetitions = ["IIII", "XXXX", "CCCC", "MMMM", "VV", "LL", "DD"];

            if (invalidRepetitions.Any(romanNumber.Contains))
            {
                return new ResultDto<bool>("Invalid repetitions found");
            }

            return new ResultDto<bool>(true);
        }

        private static ResultDto<bool> CheckSubtractionValidity(List<int>? numbers)
        {
            if (numbers == null)
            {
                return new ResultDto<bool>("Generic error");
            }
            //Check subtraction validity
            for (int i = 0; i < numbers.Count - 1; i++)
            {
                if (numbers[i] < numbers[i + 1] && // Potential subtraction
                    !((numbers[i] == 1 && (numbers[i + 1] == 5 || numbers[i + 1] == 10)) ||
                      (numbers[i] == 10 && (numbers[i + 1] == 50 || numbers[i + 1] == 100)) ||
                      (numbers[i] == 100 && (numbers[i + 1] == 500 || numbers[i + 1] == 1000))))
                {
                    return new ResultDto<bool>("Invalid subtractions found");
                }
            }
            return new ResultDto<bool>(true);
        }

        private static ResultDto<List<int>> GetNumbersFromNumberal(string input)
        {
            //Extract numbers from the numeral
            var numbers = new List<int>();

            foreach (var character in input)
            {
                if (RomanToArabicDictionary.TryGetValue(character, out int value))
                {
                    numbers.Add(value);
                }
                else
                {
                    return new ResultDto<List<int>>("Invalid characters found");
                }
            }

            return new ResultDto<List<int>>(numbers);
        }

        private static ResultDto<int> GetTotal(List<int>? numbers)
        {
            //Get the total
            if (numbers == null)
            {
                return new ResultDto<int>("Generic error");
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

            return new ResultDto<int>(total);
        }
    }
}