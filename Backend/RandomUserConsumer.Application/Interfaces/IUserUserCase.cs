using RandomuserConsumer.Communication.Responses.User;

namespace RandomUserConsumer.Application.Interfaces;

public interface IUserUserCase
{
    public Task<List<ResponseUserItemList>> ListUsers(int page, int pageSize, string? search);
    public Task<ResponseUserGenerated> GenerateUser();
}