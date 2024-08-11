using RandomuserConsumer.Communication.Responses.RandomUserApi;
using RandomUserConsumer.Domain.Entities;
using RandomUserConsumer.Domain.Interfaces.Repositories.Account;

namespace RandomUserConsumer.Application.Services;

public class AccountService
{
    private readonly IAccountWriteRepository _accountWriteRepository;
    
    public AccountService(IAccountWriteRepository addressWriteRepository)
    {
        _accountWriteRepository = addressWriteRepository;
    }
    
    public async Task<Account> rigisterAccount(int idUser, int idLogin, ResponseRandomUserGereted userGereted)
    {
        Account entityAccount = new Account()
        {
            IdUser = idUser,
            IdLogin = idLogin,
            RegistrationDate = userGereted.Results.First().Registered.Date,
        };
        
        return await _accountWriteRepository.Add(entityAccount);
    }
}