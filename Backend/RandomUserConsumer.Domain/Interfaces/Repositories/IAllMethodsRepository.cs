using RandomUserConsumer.Domain.Interfaces.Generics.Read;
using RandomUserConsumer.Domain.Interfaces.Generics.Write;

namespace RandomUserConsumer.Domain.Interfaces.Repositories;

internal interface IAllMethodsRepository<T,IT> : 
    IReadOnly<T, IT>
{
}