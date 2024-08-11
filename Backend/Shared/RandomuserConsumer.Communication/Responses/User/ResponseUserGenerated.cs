using RandomuserConsumer.Communication.Responses.Generics;
using RandomUserConsumer.Domain.Entities;
using RandomUserConsumer.Domain.Types;

namespace RandomuserConsumer.Communication.Responses.User;

public class ResponseUserGenerated : ResponseUser
{
    public ContactResponse Contact { get; set; }
    public AccountResponse Account { get; set; }
    
    public ResponseUserGenerated(
        RandomUserConsumer.Domain.Entities.User user,
        Address address,
        Contact contact,
        Login login,
        Account account
    ) : base(user, address)
    {
        Contact = new ContactResponse(contact);
        Account = new AccountResponse(account, login);
    }
}