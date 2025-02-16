﻿namespace RomanToArabicNumeralConverter.Common
{
    public static class Converter
    {
        public static Result<int> ConvertToArabicNumeral(this string? romanNumeral)
        {
            // Check null or empty
            if (string.IsNullOrEmpty(romanNumeral))
            {
                return Result<int>.Failure($"Invalid input: {romanNumeral}");
            }

            romanNumeral = romanNumeral.Trim().ToUpper();

            // Check repetition validity
            var checkRepetitionValidity = CheckRepetitionValidity(romanNumeral);

            if (!checkRepetitionValidity.Status)
            {
                return Result<int>.Failure($"{checkRepetitionValidity.Error}: {romanNumeral}");
            }

            // Get numbers from the numeral
            var getNumbersList = GetNumbersFromNumeral(romanNumeral);

            List<int>? numbers;

            if (getNumbersList.Status)
            {
                numbers = getNumbersList.Data;
            }
            else
            {
                return Result<int>.Failure($"{getNumbersList.Error}: {romanNumeral}");
            }

            // Check subtraction validity
            var checkSubtractionValidity = CheckSubtractionValidity(numbers);

            if (!checkSubtractionValidity.Status)
            {
                return Result<int>.Failure($"{checkSubtractionValidity.Error}: {romanNumeral}");
            }

            // Get the total
            var getTotal = GetTotal(numbers);

            if (!getTotal.Status)
            {
                return Result<int>.Failure($"{getTotal.Error}: {romanNumeral}");
            }

            return Result<int>.Success(getTotal.Data);
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

        private static Result<bool> CheckRepetitionValidity(string romanNumeral)
        {
            // Check repetition validity
            string[] invalidRepetitions = ["IIII", "XXXX", "CCCC", "MMMM", "VV", "LL", "DD"];

            if (invalidRepetitions.Any(romanNumeral.Contains))
            {
                return Result<bool>.Failure("Invalid repetitions found");
            }

            return Result<bool>.Success(true);
        }

        private static Result<bool> CheckSubtractionValidity(List<int>? numbers)
        {
            // Null check
            if (numbers == null)
            {
                return Result<bool>.Failure("Generic error");
            }
            // Check subtraction validity
            for (int i = 0; i < numbers.Count - 1; i++)
            {
                if (numbers[i] < numbers[i + 1] && // Potential subtraction
                    !(numbers[i] == 1 && (numbers[i + 1] == 5 || numbers[i + 1] == 10) ||
                      numbers[i] == 10 && (numbers[i + 1] == 50 || numbers[i + 1] == 100) ||
                      numbers[i] == 100 && (numbers[i + 1] == 500 || numbers[i + 1] == 1000)))
                {
                    return Result<bool>.Failure("Invalid subtractions found");
                }
            }
            return Result<bool>.Success(true);
        }

        private static Result<List<int>> GetNumbersFromNumeral(string romanNumeral)
        {
            // Extract numbers from the numeral
            var numbers = new List<int>();

            foreach (var character in romanNumeral)
            {
                if (RomanToArabicDictionary.TryGetValue(character, out int value))
                {
                    numbers.Add(value);
                }
                else
                {
                    return Result<List<int>>.Failure("Invalid characters found");
                }
            }

            return Result<List<int>>.Success(numbers);
        }

        private static Result<int> GetTotal(List<int>? numbers)
        {
            // Null check
            if (numbers == null)
            {
                return Result<int>.Failure("Generic error");
            }

            // Get the total
            var total = 0;

            for (int i = 0; i < numbers.Count; i++)
            {
                if (i < numbers.Count - 1 && numbers[i] < numbers[i + 1])
                {
                    total += numbers[i + 1] - numbers[i];
                    i++; // Skip next number since it is already counted in the subtraction
                }
                else
                {
                    total += numbers[i];
                }
            }

            return Result<int>.Success(total);
        }
    }
}