using RandomUserConsumer.Application.Interfaces;
using RandomUserConsumer.Application.Provider;
using RandomuserConsumer.Communication.Responses.RandomUserApi;
using RandomuserConsumer.Communication.Responses.User;
using RandomUserConsumer.Domain.Interfaces.Repositories.Address;
using RandomUserConsumer.Domain.Interfaces.Repositories.User;
using RandomUserConsumer.Domain.Types;

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

    public async Task<ResponseUserGenerated> GenerateUser()
    {
        ResponseRandomUserGereted generatedUser = await RandomUserApiProvider.GetRandomUser<ResponseRandomUserGereted>();
        Domain.Entities.User entityUser = new Domain.Entities.User()
        {
            Name = generatedUser.Results.First().Name.Title.ToUpper(),
            Birthday = generatedUser.Results.First().Dob.Date,
            Gender = new GenderType(generatedUser.Results.First().Gender),
            Nationality = generatedUser.Results.First().Nat.ToUpper(),
            PictureUrl = generatedUser.Results.First().Picture.Large,
        };
        
        entityUser.IdAddress = 1;
        
        entityUser = await _writeRepository.Add(entityUser);
        
        return new ResponseUserGenerated(entityUser);
    }

    public async Task<List<ResponseUserItemList>> ListUsers(int count, int page, string? search)
    {
        List<Domain.Entities.User> result = await _readOnlyRepository.Search(count, page, search);
        return result.Select(user => new ResponseUserItemList(user, user.Address)).ToList();
    }
}