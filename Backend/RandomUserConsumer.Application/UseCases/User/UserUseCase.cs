using RandomUserConsumer.Application.Interfaces;
using RandomuserConsumer.Communication.Responses.User;
using RandomUserConsumer.Domain.Repositories;

namespace RandomUserConsumer.Application.UseCases.User;

public class UserUseCase : IUserUserCase
{
    private readonly IUserWriteRepository _writeRepository;
    private readonly IUserReadOnlyRepository _readOnlyRepository;

    public UserUseCase(IUserWriteRepository writeRepository, IUserReadOnlyRepository readOnlyRepository)
    {
        _writeRepository = writeRepository;
        _readOnlyRepository = readOnlyRepository;
    }

    public string GenerateUser()
    {
        return "User generated";
    }

    public async Task<List<ResponseUserItemList>> ListUsers(int count, int page, string? search)
    {
        List<Domain.Entities.User> result = await _readOnlyRepository.ListUsers(count, page, search);
        return result.Select(user => new ResponseUserItemList(user, user.Address)).ToList();
    }
}