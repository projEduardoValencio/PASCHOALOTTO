using RandomUserConsumer.Domain.Entities;
using RandomUserConsumer.Domain.Interfaces.Repositories.Address;
using RandomUserConsumer.Infrastructure.DataAccess;

namespace RandomUserConsumer.Infrastructure.Repositories;

public class AddressRepository : RepositoryBase<Address, int>, IAddressWriteRepository, IAddressReadOnlyRepository
{
    public AddressRepository(RandomUserConsumerDbContext context) : base(context) { }

    public override Task<List<Address>> Search(int page, int pageSize, string search)
    {
        throw new NotImplementedException();
    }

    public override Task<int> Count(string? search)
    {
        throw new NotImplementedException();
    }
}