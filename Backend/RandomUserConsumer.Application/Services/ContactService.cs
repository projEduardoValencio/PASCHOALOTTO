using RandomuserConsumer.Communication.Request.User;
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
    
    public async Task<Contact> RigisterContact(int idUser, ResponseRandomUserGereted userGereted)
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
    
    public async Task<Contact> RigisterContact(int idUser, RequestRegisterUser dto)
    {
        Contact entityContact = new Contact()
        {
            Email = dto.Contact.Email,
            PhoneNumber = dto.Contact.PhoneNumber,
            CellPhone = dto.Contact.CellPhone,
            IdUser = idUser,
        };
        
        return await _contactWriteRepository.Add(entityContact);
    }
    
    public async Task<Contact> UpdateContact(int idContact, int idUser, RequestUpdateUser dto)
    {
        Contact entityContact = new Contact()
        {
            Email = dto.Contact.Email,
            PhoneNumber = dto.Contact.PhoneNumber,
            CellPhone = dto.Contact.CellPhone,
            IdUser = idUser,
            Id = idContact
        };
        
        return await _contactWriteRepository.Update(idContact,entityContact);
    }
}