using RandomUserConsumer.Domain.Interfaces.Generics.Read;

namespace RandomUserConsumer.Domain.Interfaces.Repositories.Contact;

public interface IContactReadOnlyRepository : IReadOnly<Entities.Contact, int>
{
}