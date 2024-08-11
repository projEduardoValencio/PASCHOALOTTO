using RandomUserConsumer.Domain.Entities;

namespace RandomuserConsumer.Communication.Responses.Generics;

public class ContactResponse
{
    public string Email { get; set; } = string.Empty;
    public string PhoneNumber { get; set; } = string.Empty;
    public string CellPhone { get; set; } = string.Empty;

    public ContactResponse(Contact contact)
    {
        Email = contact.Email;
        PhoneNumber = contact.PhoneNumber;
        CellPhone = contact.CellPhone;
    }
}