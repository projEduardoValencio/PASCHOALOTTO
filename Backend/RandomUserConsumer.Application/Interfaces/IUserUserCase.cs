using RandomuserConsumer.Communication.Request.User;
using RandomuserConsumer.Communication.Responses.User;

namespace RandomUserConsumer.Application.Interfaces;

public interface IUserUserCase
{
    public Task<List<ResponseUserItemList>> ListUsers(int page, int pageSize, string? search);
    public Task<ResponseUserGenerated> GenerateUser();
    public Task<ResponseUserRequested> FindUser(int id);
    public Task<int> CountUsers(string? search);
    Task<ResponseUserGenerated> RegisterUser(RequestRegisterUser dto);
    Task<ResponseUserRequested> UpdateUser(RequestUpdateUser dto);
    Task<ResponseUserRequested> DeleteUser(int id);
    Task<List<ResponseUserRequested>> Report();
}