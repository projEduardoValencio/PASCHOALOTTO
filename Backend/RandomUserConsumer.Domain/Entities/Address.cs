namespace RandomUserConsumer.Domain.Entities;

public class Address : EntityBase
{
    public string Street { get; set; } = string.Empty;
    public int Number { get; set; }
    public string City { get; set; } = string.Empty;
    public string State { get; set; } = string.Empty;
    public string ZipCode { get; set; } = string.Empty;
    public string Country { get; set; } = string.Empty;
    
    public virtual Coordinate Coordinate { get; set; }
    public virtual User User { get; set; }
}