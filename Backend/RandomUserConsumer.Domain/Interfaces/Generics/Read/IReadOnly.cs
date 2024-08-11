namespace RandomUserConsumer.Domain.Interfaces.Generics.Read;

public interface IReadOnly<T, TI> : IReadFindable<T, TI>, IReadSearchable<T>
{
    
}