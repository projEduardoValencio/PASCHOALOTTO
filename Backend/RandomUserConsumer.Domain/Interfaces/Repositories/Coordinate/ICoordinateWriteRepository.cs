using RandomUserConsumer.Domain.Interfaces.Generics.Write;

namespace RandomUserConsumer.Domain.Interfaces.Repositories.Coordinate;

public interface ICoordinateWriteRepository : IWriteOnly<Entities.Coordinate, int>
{
}