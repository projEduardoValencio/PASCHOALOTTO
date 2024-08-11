namespace RandomUserConsumer.Domain.Interfaces.Generics.Write;

public interface IWriteUpdatable<T, IT>
{
    Task<T> Update(IT id, T entity);
}