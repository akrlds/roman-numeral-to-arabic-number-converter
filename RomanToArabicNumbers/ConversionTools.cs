namespace RomanToArabicNumbers
{
    public class ConversionTools
    {
        public Dictionary<char, int> romanToArabicDictionary = [];

        public ConversionTools()
        {
            romanToArabicDictionary.Add('I', 1);
            romanToArabicDictionary.Add('V', 5);
            romanToArabicDictionary.Add('X', 10);
            romanToArabicDictionary.Add('L', 50);
            romanToArabicDictionary.Add('C', 100);
            romanToArabicDictionary.Add('D', 500);
            romanToArabicDictionary.Add('M', 1000);
        }
             
        public bool CheckRepetitionIntegrityOfRomanNumber(string romanNumber)
        {
            string[] invalidRepetitions = { "IIII", "XXXX", "CCCC", "MMMM", "VV", "LL", "DD" };

            //Check for invalid repetitions
            foreach (string repetitions in invalidRepetitions)
            {
                if (romanNumber.Contains(repetitions))
                {
                    return false;
                }
            }

            return true;
        }

        public bool CheckSubtractionIntegrityOfRomanNumber(List<int> numbers)
        {
            for (int i = 0; i < numbers.Count - 1; i++)
            {
                if (numbers[i] < numbers[i + 1]) // Potential subtraction
                {
                    // Ensure it's a valid subtraction
                    if (!((numbers[i] == 1 && (numbers[i + 1] == 5 || numbers[i + 1] == 10)) ||
                          (numbers[i] == 10 && (numbers[i + 1] == 50 || numbers[i + 1] == 100)) ||
                          (numbers[i] == 100 && (numbers[i + 1] == 500 || numbers[i + 1] == 1000))))
                    {
                        return false;
                    }

                    // Ensure that the same smaller number does not appear again after a valid subtraction (for example IXI is invalid)
                    if (i + 2 < numbers.Count && numbers[i + 2] == numbers[i])
                    {
                        return false;
                    }
                }
            }
            return true;
        }
    }
}