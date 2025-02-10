namespace RomanToArabicNumeralConverter.Common
{
    public sealed class Result<T>
    {
        public readonly bool Status;
        public readonly T? Data;
        public readonly string Error;

        private Result(T data)
        {
            Status = true;
            Data = data;
            Error = string.Empty;
        }

        private Result(string error)
        {
            Status = false;
            Data = default;
            Error = error;
        }

        public static Result<T> Success(T data) => new(data);
        public static Result<T> Failure(string error) => new(error);
    }
}