using RandomUserConsumer.Domain.Interfaces.Generics.Write;

namespace RandomUserConsumer.Domain.Interfaces.Repositories.Address;

public interface IAddressWriteRepository : IWriteOnly<Entities.Address, int>
{
}