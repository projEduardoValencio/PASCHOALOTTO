using RandomUserConsumer.Domain.Entities;

namespace RandomuserConsumer.Communication.Responses.Generics;

public class AccountResponse
{
    public int IdUser { get; set; }
    public LoginResponse Login { get; set; }
    public DateTime RegistrationDate { get; set; } = DateTime.Now;
    
    public AccountResponse(Account account, Login login)
    {
        IdUser = account.IdUser;
        RegistrationDate = account.RegistrationDate;
        Login = new LoginResponse(login);
    }
}