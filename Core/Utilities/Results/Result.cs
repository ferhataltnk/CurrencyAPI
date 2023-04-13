namespace Core.Utilities.Results
{
    public class Result<T> : IResult<T>
    {
        public T Data { get; }
        public string Message { get; }
        public bool Success { get; }

        public Result(T data, string message, bool success)
        {
            Data = data;
            Message = message;
            Success = success;
        }
    }
}
