using System.Net;
using RandomUserConsumer.Application.Interfaces;
using RandomUserConsumer.Application.Provider;
using RandomUserConsumer.Application.Services;
using RandomuserConsumer.Communication.Request.User;
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
        _writeRepository.BeginTransaction();

        try
        {
            ResponseRandomUserGereted generatedUser =
                await RandomUserApiProvider.GetRandomUser<ResponseRandomUserGereted>();

            Address address = await _addressService.RigisterAddress(generatedUser);

            await _coordinateService.RigisterCoordinate(address.Id, generatedUser);

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

            Contact contact = await _contactService.RigisterContact(user.Id, generatedUser);

            Login login = await _loginService.RigisterLogin(user.Id, generatedUser);

            Account account = await _accountService.RigisterAccount(user.Id, login.Id, generatedUser);

            _writeRepository.CommitTrasaction();
            return new ResponseUserGenerated(user, address, contact, login, account);
        }
        catch (Exception e)
        {
            _writeRepository.RollbackTransaction();
            throw new Exception($"Error generating user: {e.Message}");
        }
    }

    public async Task<ResponseUserRequested> FindUser(int id)
    {
        return new ResponseUserRequested(await _readOnlyRepository.Find(id));
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

    public async Task<ResponseUserGenerated> RegisterUser(RequestRegisterUser dto)
    {
        _writeRepository.BeginTransaction();
        try
        {
            Address address = await _addressService.RigisterAddress(dto);

            await _coordinateService.RigisterCoordinate(address.Id, dto);

            Domain.Entities.User user = await _writeRepository.Add(new Domain.Entities.User()
            {
                Name = dto.Name,
                Birthday = dto.Birthday,
                Gender = new GenderType(dto.Gender),
                Nationality = dto.Nationality,
                PictureUrl = dto.PictureUrl,
                IdAddress = address.Id
            });

            Contact contact = await _contactService.RigisterContact(user.Id, dto);

            Login login = await _loginService.RigisterLogin(user.Id, dto);

            Account account = await _accountService.RigisterAccount(user.Id, login.Id, dto);

            _writeRepository.CommitTrasaction();
            return new ResponseUserGenerated(user, address, contact, login, account);
        }
        catch (Exception e)
        {
            _writeRepository.RollbackTransaction();
            throw new Exception($"Error register user: {e.Message}");
        }
    }

    public async Task<object?> UpdateUser(RequestUpdateUser dto)
    {
        _writeRepository.BeginTransaction();
        try
        {
            Domain.Entities.User user = await _readOnlyRepository.Find(dto.Id);
            await _addressService.UpdateAddress(user.IdAddress, dto);
            await _accountService.UpdateAccount(user.Account.Id, user.Id, user.Login.Id, dto);
            await _contactService.UpdateContact(user.Contact.Id, user.Id, dto);
            await _loginService.UpdateLogin(user.Login.Id, user.Id, dto);
            
            Domain.Entities.User updatedUser = new Domain.Entities.User()
            {
                Id = user.Id,
                Name = dto.Name,
                Birthday = dto.Birthday,
                Gender = new GenderType(dto.Gender),
                Nationality = dto.Nationality,
                PictureUrl = dto.PictureUrl,
                IdAddress = user.IdAddress,
                Contact = user.Contact,
                Login = user.Login,
                Account = user.Account,
                Address = user.Address,
                CreatedAt = user.CreatedAt,
            };

            user = await _writeRepository.Update(user.Id, updatedUser);
            _writeRepository.CommitTrasaction();
            return new ResponseUserRequested(user);
        }
        catch (Exception e)
        {
            _writeRepository.RollbackTransaction();
            throw new Exception($"Error updating user: {e.Message}");
        }
    }
}