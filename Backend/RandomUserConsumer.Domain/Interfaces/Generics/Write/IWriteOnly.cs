namespace RandomUserConsumer.Domain.Interfaces.Generics.Write;

public interface IWriteOnly<T, IT> : IWriteInsertable<T>, IWriteDeletable<T,IT>, IWriteUpdatable<T, IT>
{
}