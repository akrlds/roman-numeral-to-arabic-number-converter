namespace RomanToArabicNumbers
{
    public class ResultDTO
    {
        public readonly bool Status;
        public readonly int Data;
        public readonly string Error;

        public ResultDTO(int data)
        {
            Status = true;
            Data = data;
            Error = string.Empty;
        }

        public ResultDTO(string error)
        {
            Status = false;
            Data = 0;
            Error = error;
        }
    }
}