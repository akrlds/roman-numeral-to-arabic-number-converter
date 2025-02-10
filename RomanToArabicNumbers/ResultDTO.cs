namespace RomanToArabicNumbers
{
    public class ResultDto<T>
    {
        public readonly bool Status;
        public readonly T? Data;
        public readonly string Error;

        public ResultDto(T data)
        {
            Status = true;
            Data = data;
            Error = string.Empty;
        }

        public ResultDto(string error)
        {
            Status = false;
            Error = error;
        }
    }
}