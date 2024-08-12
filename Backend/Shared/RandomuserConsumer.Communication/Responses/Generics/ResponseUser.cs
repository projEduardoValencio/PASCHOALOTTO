using RandomUserConsumer.Domain.Entities;
using RandomUserConsumer.Domain.Types;

namespace RandomuserConsumer.Communication.Responses.Generics;

public class ResponseUser
{
    private GenderType _gender = GenderType.Other;
    
    public int Id { get; set; } = 0;
    public string Name { get; set; } = String.Empty;
    public DateTime Birthday { get; set; } = DateTime.MinValue;
    public string Gender { get => _gender.ToString(); set => _gender = new GenderType(value); }
    public string Nationality { get; set; } = string.Empty;
    public string PictureUrl { get; set; } = string.Empty;

    public ResponseAddress Address { get; set; }
    public ContactResponse Contact { get; set; }
    
    public ResponseUser(RandomUserConsumer.Domain.Entities.User user)
    {
        Id = user.Id;
        Name = user.Name;
        Birthday = user.Birthday;
        _gender = user.Gender;
        Nationality = user.Nationality;
        PictureUrl = user.PictureUrl;
    }
    
    public ResponseUser(RandomUserConsumer.Domain.Entities.User user, Address address) : this(user)
    {
        Address = new ResponseAddress(address);
        Contact = new ContactResponse(user.Contact);
    }
}