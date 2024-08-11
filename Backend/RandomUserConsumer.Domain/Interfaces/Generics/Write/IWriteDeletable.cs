namespace RandomUserConsumer.Domain.Interfaces.Generics.Write;

public interface IWriteDeletable<T, IT>
{
    Task<T> Delete(IT id);
}