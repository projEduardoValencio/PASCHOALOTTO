namespace RandomUserConsumer.Domain.Interfaces.Generics.Read;

public interface IReadFindable<T, ID>
{
    Task<T> Find(ID id);
}