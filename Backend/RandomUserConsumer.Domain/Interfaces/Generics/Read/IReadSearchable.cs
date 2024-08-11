namespace RandomUserConsumer.Domain.Interfaces.Generics.Read;

public interface IReadSearchable<T>
{
    Task<List<T>> Search(int page, int pageSize, string search);
}