using RandomUserConsumer.Domain.Interfaces.Generics.Read;

namespace RandomUserConsumer.Domain.Interfaces.Repositories.Coordinate;

public interface ICoordinateReadOnlyRepository : IReadOnly<Entities.Coordinate, int>
{
}