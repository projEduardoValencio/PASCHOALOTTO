using RandomUserConsumer.Domain.Entities;
using RandomUserConsumer.Domain.Interfaces.Repositories.Coordinate;
using RandomUserConsumer.Infrastructure.DataAccess;

namespace RandomUserConsumer.Infrastructure.Repositories;

public class CoordinateRepository : RepositoryBase<Coordinate, int>, ICoordinateWriteRepository, ICoordinateReadOnlyRepository
{
    private readonly RandomUserConsumerDbContext _context;

    public CoordinateRepository(RandomUserConsumerDbContext context) : base(context)
    {
        _context = context;
    }

    public override Task<List<Coordinate>> Search(int page, int pageSize, string search)
    {
        throw new NotImplementedException();
    }
}