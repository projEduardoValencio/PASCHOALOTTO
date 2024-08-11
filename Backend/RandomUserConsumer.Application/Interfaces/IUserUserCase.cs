using RandomuserConsumer.Communication.Responses.User;

namespace RandomUserConsumer.Application.Interfaces;

public interface IUserUserCase
{
    public Task<List<ResponseUserItemList>> ListUsers(int count, int page, string? search);
    public Task<ResponseUserGenerated> GenerateUser();
}