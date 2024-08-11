namespace RandomUserConsumer.Domain.Interfaces.Generics.Write;

public interface IWriteInsertable<T>
{
    Task<T> Add(T entity);
}