
namespace TMP.domain.commons.response.result
{
    public class Result<T>
    {
        public bool IsSuccess { get;}
        public string ErrorMessage { get; }

        public int CodeStatusOperation { get; }
        public T Value { get;}

        protected Result(bool isSuccess, string errorMessage, T value, int codeStatusOperation)
        {
            IsSuccess = isSuccess;
            ErrorMessage = errorMessage;
            Value = value;
            CodeStatusOperation = codeStatusOperation;
        }

        public static Result<T> Success(T value) => new Result<T>(true, string.Empty, value, 100);
        public static Result<T> Failure(string errorMessage, int codeError) => new Result<T>(false, errorMessage, default(T), codeError);
    }
}
