using RandomUserConsumer.Domain.Entities;

namespace RandomuserConsumer.Communication.Responses.Generics;

public class LoginResponse
{
    public string Uuid { get; set; } = string.Empty;
    public string Username { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;

    public LoginResponse(Login login)
    {
        Uuid = login.Uuid;
        Username = login.Username;
        Password = login.Password;
    }
}