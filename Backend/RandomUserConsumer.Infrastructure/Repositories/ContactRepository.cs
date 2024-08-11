using RandomUserConsumer.Domain.Entities;
using RandomUserConsumer.Domain.Interfaces.Repositories.Contact;
using RandomUserConsumer.Infrastructure.DataAccess;

namespace RandomUserConsumer.Infrastructure.Repositories;

public class ContactRepository : RepositoryBase<Contact, int>, IContactWriteRepository, IContactReadOnlyRepository
{
    public ContactRepository(RandomUserConsumerDbContext context) : base(context) { }
    
    public override Task<List<Contact>> Search(int page, int pageSize, string search)
    {
        throw new NotImplementedException();
    }

    public override Task<int> Count(string? search)
    {
        throw new NotImplementedException();
    }
}