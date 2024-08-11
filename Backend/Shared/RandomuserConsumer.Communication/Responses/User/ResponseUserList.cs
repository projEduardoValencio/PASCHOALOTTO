using RandomuserConsumer.Communication.Responses.Generics;

namespace RandomuserConsumer.Communication.Responses.User;

public class ResponseUserList : ResponseList<ResponseUserItemList>
{
    public ResponseUserList(List<ResponseUserItemList> list, int page, int pageSize, int totalCount, string search) :
        base(list, page, pageSize, totalCount, search)
    {
    }
}