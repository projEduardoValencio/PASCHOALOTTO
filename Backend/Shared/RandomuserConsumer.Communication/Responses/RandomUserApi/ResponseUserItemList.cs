using RandomuserConsumer.Communication.Responses.Generics;
using RandomUserConsumer.Domain.Entities;
using RandomUserConsumer.Domain.Types;

namespace RandomuserConsumer.Communication.Responses.RandomUserApi;

public class ResponseUserItemList
{
    
    private GenderType _gender = GenderType.Other;
    
    public string Name { get; set; } = String.Empty;
    public DateTime Birthday { get; set; } = DateTime.MinValue;
    public string Gender { get => _gender.ToString(); set => _gender = new GenderType(value); }
    public string Nationality { get; set; } = string.Empty;
    public string PictureUrl { get; set; } = string.Empty;

    public ResponseAddress Address { get; set; }

    public ResponseUserItemList(User user)
    {
        Name = user.Name;
        Birthday = user.Birthday;
        _gender = user.Gender;
        Nationality = user.Nationality;
        PictureUrl = user.PictureUrl;
    }
    
    public ResponseUserItemList(User user, Address address) : this(user)
    {
        Address = new ResponseAddress(address);
    }
}