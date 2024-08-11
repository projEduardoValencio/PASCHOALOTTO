using RandomuserConsumer.Communication.Responses.Generics;
using RandomUserConsumer.Domain.Entities;

namespace RandomuserConsumer.Communication.Responses.User;

public class ResponseUserItemList : ResponseUser
{
    public ResponseUserItemList(RandomUserConsumer.Domain.Entities.User user) : base(user)
    {
    }

    public ResponseUserItemList(RandomUserConsumer.Domain.Entities.User user, Address address) : base(user, address)
    {
    }
}