using RandomuserConsumer.Communication.Responses.RandomUserApi;
using RandomUserConsumer.Domain.Entities;
using RandomUserConsumer.Domain.Interfaces.Repositories.Login;

namespace RandomUserConsumer.Application.Services;

public class LoginService
{
    private readonly ILoginWriteRepository _loginWriteRepository;
    
    public LoginService(ILoginWriteRepository loginWriteRepository)
    {
        _loginWriteRepository = loginWriteRepository;
    }
    
    public async Task<Login> rigisterLogin(int idUser, ResponseRandomUserGereted userGereted)
    {
        Login entityLogin = new Login()
        {
            Uuid = userGereted.Results.First().Login.Uuid,
            Username = userGereted.Results.First().Login.Username,
            Password = userGereted.Results.First().Login.Password,
            Salt = userGereted.Results.First().Login.Salt,
            Md5 = userGereted.Results.First().Login.Md5,
            Sha1 = userGereted.Results.First().Login.Sha1,
            IdUser = idUser,
        };
        
        return await _loginWriteRepository.Add(entityLogin);
    }
}