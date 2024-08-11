using RandomUserConsumer.Domain.Interfaces.Generics.Write;

namespace RandomUserConsumer.Domain.Interfaces.Repositories.Login;

public interface ILoginWriteRepository : IWriteOnly<Entities.Login, int>
{
}