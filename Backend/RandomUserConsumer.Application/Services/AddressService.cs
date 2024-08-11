using RandomuserConsumer.Communication.Responses.RandomUserApi;
using RandomUserConsumer.Domain.Entities;
using RandomUserConsumer.Domain.Interfaces.Repositories.Address;

namespace RandomUserConsumer.Application.Services;

public class AddressService
{
    private readonly IAddressWriteRepository _addressWriteRepository;
    
    public AddressService(IAddressWriteRepository addressWriteRepository)
    {
        _addressWriteRepository = addressWriteRepository;
    }
    
    public async Task<Address> rigisterAddress(ResponseRandomUserGereted generatedUser)
    {
        Address entityAddress = new Address()
        {
            Street = generatedUser.Results.First().Location.Street.Name,
            City = generatedUser.Results.First().Location.City,
            State = generatedUser.Results.First().Location.State,
            ZipCode = generatedUser.Results.First().Location.getPostCode(),
            Country = generatedUser.Results.First().Location.Country,
        };
        
        return await _addressWriteRepository.Add(entityAddress);
    }
}