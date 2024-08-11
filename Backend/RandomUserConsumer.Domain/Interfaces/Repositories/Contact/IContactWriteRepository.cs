using RandomUserConsumer.Domain.Interfaces.Generics.Write;

namespace RandomUserConsumer.Domain.Interfaces.Repositories.Contact;

public interface IContactWriteRepository : IWriteOnly<Entities.Contact, int>
{
}