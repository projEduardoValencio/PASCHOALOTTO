using RandomUserConsumer.Domain.Entities;
using RandomUserConsumer.Domain.Interfaces.Repositories.Address;
using RandomUserConsumer.Infrastructure.DataAccess;

namespace RandomUserConsumer.Infrastructure.Repositories;

public class AddressRepository : RepositoryBase<Address, int>, IAddressWriteRepository, IAddressReadOnlyRepository
{
    private readonly RandomUserConsumerDbContext _context;

    public AddressRepository(RandomUserConsumerDbContext context) : base(context)
    {
        _context = context;
    }

    public override Task<List<Address>> Search(int page, int pageSize, string search)
    {
        throw new NotImplementedException();
    }
}