using RandomUserConsumer.Application.Interfaces;
using RandomUserConsumer.Application.Provider;
using RandomUserConsumer.Application.Services;
using RandomuserConsumer.Communication.Responses.RandomUserApi;
using RandomuserConsumer.Communication.Responses.User;
using RandomUserConsumer.Domain.Entities;
using RandomUserConsumer.Domain.Interfaces.Repositories.User;
using RandomUserConsumer.Domain.Types;

namespace RandomUserConsumer.Application.UseCases.User;

public class UserUseCase : IUserUserCase
{
    private readonly IUserWriteRepository _writeRepository;
    private readonly IUserReadOnlyRepository _readOnlyRepository;
    private readonly AddressService _addressService;
    private readonly AccountService _accountService;
    private readonly LoginService _loginService;
    private readonly CoordinateService _coordinateService;
    private readonly ContactService _contactService;
    

    public UserUseCase(
        IUserWriteRepository writeRepository,
        IUserReadOnlyRepository readOnlyRepository,
        AddressService addressService,
        AccountService accountService,
        LoginService loginService,
        CoordinateService coordinateService,
        ContactService contactService
    )
    {
        _writeRepository = writeRepository;
        _readOnlyRepository = readOnlyRepository;
        _addressService = addressService;
        _accountService = accountService;
        _loginService = loginService;
        _coordinateService = coordinateService;
        _contactService = contactService;
    }

    public async Task<ResponseUserGenerated> GenerateUser()
    {
        ResponseRandomUserGereted generatedUser =
            await RandomUserApiProvider.GetRandomUser<ResponseRandomUserGereted>();
        
        Address address = await _addressService.rigisterAddress(generatedUser);
        
        await _coordinateService.rigisterCoordinate(address.Id, generatedUser);

        string userName = generatedUser.Results.First().Name.First.ToUpper()
                          + " "
                          + generatedUser.Results.First().Name.Last.ToUpper();
        Domain.Entities.User user = await _writeRepository.Add(new Domain.Entities.User()
        {
            Name = userName,
            Birthday = generatedUser.Results.First().Dob.Date,
            Gender = new GenderType(generatedUser.Results.First().Gender),
            Nationality = generatedUser.Results.First().Nat.ToUpper(),
            PictureUrl = generatedUser.Results.First().Picture.Large,
            IdAddress = address.Id
        });
        
        Contact contact = await _contactService.rigisterContact(user.Id, generatedUser);
        
        Login login = await _loginService.rigisterLogin(user.Id, generatedUser);
        
        Account account = await _accountService.rigisterAccount(user.Id, login.Id, generatedUser);
        
        return new ResponseUserGenerated(user, address, contact, login, account);
    }

    public async Task<int> CountUsers(string? search)
    {
        return await _readOnlyRepository.Count(search);
    }

    public async Task<List<ResponseUserItemList>> ListUsers(int page, int pageSize, string? search)
    {
        List<Domain.Entities.User> result = await _readOnlyRepository.Search(page, pageSize, search);
        return result.Select(user => new ResponseUserItemList(user, user.Address)).ToList();
    }
}