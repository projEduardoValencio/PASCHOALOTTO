namespace RandomUserConsumer.Domain.Interfaces.Generics.Read;

public interface IReadCountable<T>
{
    Task<int> Count(string? search);
}