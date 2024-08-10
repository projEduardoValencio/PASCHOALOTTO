using RandomuserConsumer.Communication.Responses.RandomUserApi;

namespace RandomUserConsumer.Application.Interfaces;

public interface IUserUserCase
{
    public Task<List<ResponseUserItemList>> ListUsers(int count, int page, string? search);
}