namespace Core.Utilities.Results
{
    public interface IResult<T>
    {
        T Data { get; }
    }
}
