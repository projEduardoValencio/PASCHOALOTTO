namespace RandomUserConsumer.Domain.Entities;

public class Contact : EntityBase
{
    public string Email { get; set; } = string.Empty;
    public string PhoneNumber { get; set; } = string.Empty;
    public string CellPhone { get; set; } = string.Empty;
    
    public int IdUser { get; set; }
    public virtual User User { get; set; }
}