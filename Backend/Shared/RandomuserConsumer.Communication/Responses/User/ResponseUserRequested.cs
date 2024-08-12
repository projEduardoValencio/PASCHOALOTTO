using RandomuserConsumer.Communication.Responses.Generics;
using RandomUserConsumer.Domain.Entities;

namespace RandomuserConsumer.Communication.Responses.User;

public class ResponseUserRequested : ResponseUser
{
    public AccountResponse Account { get; set; }
    public ContactResponse Contact { get; set; }
    public LoginResponse Login { get; set; }
    
    public ResponseUserRequested(RandomUserConsumer.Domain.Entities.User user) : base(user)
    {
        Account = new AccountResponse(user.Account, user.Login);
        Contact = new ContactResponse(user.Contact);
        Login = new LoginResponse(user.Login);
        Address = new ResponseAddress(user.Address);
    }

    public ResponseUserRequested(RandomUserConsumer.Domain.Entities.User user, Address address) : base(user, address)
    {
    }
}