namespace RandomUserConsumer.Domain.Entities;

public class Login : EntityBase
{
    public string Uuid { get; set; } = string.Empty;
    public string Username { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    public string Salt { get; set; } = string.Empty;
    public string Md5 { get; set; } = string.Empty;
    public string Sha1 { get; set; } = string.Empty;
    public string Sha256 { get; set; } = string.Empty;
    
    public int IdUser { get; set; }
    public virtual User User { get; set; }
    
    public virtual Account Account { get; set; }
}