using RandomUserConsumer.Domain.Types;

namespace RandomUserConsumer.Domain.Entities;

public class User : EntityBase
{
    public string Name { get; set; } = string.Empty;
    public DateTime Birthday { get; set; } = DateTime.MinValue;
    public GenderType Gender { get; set; } = GenderType.Other;
    public string Nationality { get; set; } = string.Empty;
    public string PictureUrl { get; set; } = string.Empty;
    
    
    public int IdAddress { get; set; }
    public virtual Address Address { get; set; }
    
    public virtual Contact Contact { get; set; }
}