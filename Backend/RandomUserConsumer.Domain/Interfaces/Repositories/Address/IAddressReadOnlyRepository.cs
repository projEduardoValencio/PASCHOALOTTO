using RandomUserConsumer.Domain.Interfaces.Generics.Read;

namespace RandomUserConsumer.Domain.Interfaces.Repositories.Address;

public interface IAddressReadOnlyRepository : IReadOnly<Entities.Address, int>
{
}