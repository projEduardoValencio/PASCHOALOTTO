using RandomUserConsumer.Domain.Entities;

namespace RandomuserConsumer.Communication.Responses.Generics;

public class ResponseAddress
{
    public string Street { get; set; } = string.Empty;
    public int Number { get; set; }
    public string City { get; set; } = string.Empty;
    public string State { get; set; } = string.Empty;
    public string ZipCode { get; set; } = string.Empty;
    public string Country { get; set; } = string.Empty;
    
    public ResponseAddress(Address address)
    {
        Street = address.Street;
        Number = address.Number;
        City = address.City;
        State = address.State;
        ZipCode = address.ZipCode;
        Country = address.Country;
    }
}