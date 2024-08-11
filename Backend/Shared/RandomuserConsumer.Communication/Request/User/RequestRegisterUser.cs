namespace RandomuserConsumer.Communication.Request.User;

public class RequestRegisterUser
{
    public string Name { get; set; }
    public string Gender { get; set; }
    public string Nationality { get; set; }
    public string PictureUrl { get; set; }
    public DateTime Birthday { get; set; }
    public UserContact Contact { get; set; }
    public UserAccount Account { get; set; }
    public UserAddress Address { get; set; }

    public class UserContact
    {
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string CellPhone { get; set; }
    }

    public class UserLogin
    {
        public string Uuid { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Salt { get; set; }
    }

    public class UserAccount
    {
        public UserLogin Login { get; set; }
        public DateTime RegistrationDate { get; set; }
    }

    public class UserAddress
    {
        public string Street { get; set; }
        public int Number { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
        public string Country { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        
    }
}