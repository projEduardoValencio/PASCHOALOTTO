namespace RandomUserConsumer.Domain.Entities;

public class Account : EntityBase
{
    public DateTime RegistrationDate { get; set; } = DateTime.Now;
    
    public int IdUser { get; set; }
    public virtual User User { get; set; }
    
    public int IdLogin { get; set; }
    public virtual Login Login { get; set; }
}