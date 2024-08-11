using RandomuserConsumer.Communication.Responses.RandomUserApi;
using RandomUserConsumer.Domain.Entities;
using RandomUserConsumer.Domain.Interfaces.Repositories.Contact;

namespace RandomUserConsumer.Application.Services;

public class ContactService
{
    private readonly IContactWriteRepository _contactWriteRepository;
    
    public ContactService(IContactWriteRepository addressWriteRepository)
    {
        _contactWriteRepository = addressWriteRepository;
    }
    
    public async Task<Contact> rigisterContact(int idUser, ResponseRandomUserGereted userGereted)
    {
        Contact entityContact = new Contact()
        {
            Email = userGereted.Results.First().Email,
            PhoneNumber = userGereted.Results.First().Phone,
            CellPhone = userGereted.Results.First().Cell,
            IdUser = idUser,
        };
        
        return await _contactWriteRepository.Add(entityContact);
    }
}