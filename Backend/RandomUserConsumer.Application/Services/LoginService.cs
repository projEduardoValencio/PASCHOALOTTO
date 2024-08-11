using RandomUserConsumer.Application.Enums;
using RandomUserConsumer.Application.UseCases.User;
using RandomuserConsumer.Communication.Request.User;
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
    
    public async Task<Login> RigisterLogin(int idUser, ResponseRandomUserGereted userGereted)
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
    
    public async Task<Login> RigisterLogin(int idUser, RequestRegisterUser dto)
    {
        if (String.IsNullOrWhiteSpace(dto.Account.Login.Uuid))
        {
            // TODO: Gerar o uuid se nao tiver
        }

        string md5 = PasswordEncryption.HashPassword(dto.Account.Login.Password, dto.Account.Login.Salt,
            EncryptionTypeEnum.MD5);
        string sha1 = PasswordEncryption.HashPassword(dto.Account.Login.Password, dto.Account.Login.Salt,
            EncryptionTypeEnum.SHA1);
        string sha256 = PasswordEncryption.HashPassword(dto.Account.Login.Password, dto.Account.Login.Salt,
            EncryptionTypeEnum.SHA256);
        Login entityLogin = new Login()
        {
            Uuid = dto.Account.Login.Uuid,
            Username = dto.Account.Login.Username,
            Password = dto.Account.Login.Password,
            Salt = dto.Account.Login.Salt,
            Md5 = md5,
            Sha1 = sha1,
            Sha256 = sha256,
            IdUser = idUser,
        };
        
        return await _loginWriteRepository.Add(entityLogin);
    }
}