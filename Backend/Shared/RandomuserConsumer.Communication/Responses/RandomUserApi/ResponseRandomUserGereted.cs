namespace RandomuserConsumer.Communication.Responses.RandomUserApi;

public class ResponseRandomUserGereted
{
    public Name _name { get; set; }
    public class Name
    {
        public string Title { get; set; } = String.Empty;
        public string First { get; set; } = String.Empty;
        public string Last { get; set; } = String.Empty;
    }

    public class Street
    {
        public int Number { get; set; }
        public string Name { get; set; } = String.Empty;
    }

    public class Coordinates
    {
        public string Latitude { get; set; } = String.Empty;
        public string Longitude { get; set; } = String.Empty;
    }

    public class Timezone
    {
        public string Offset { get; set; } = String.Empty;
        public string Description { get; set; } = String.Empty;
    }

    public class Location
    {
        public Street Street { get; set; }
        public string City { get; set; } = String.Empty;
        public string State { get; set; } = String.Empty;
        public string Country { get; set; } = String.Empty;
        public int Postcode { get; set; }
        public Coordinates Coordinates { get; set; }
        public Timezone Timezone { get; set; }
    }

    public class Login
    {
        public string Uuid { get; set; } = String.Empty;
        public string Username { get; set; } = String.Empty;
        public string Password { get; set; } = String.Empty;
        public string Salt { get; set; } = String.Empty;
        public string Md5 { get; set; } = String.Empty;
        public string Sha1 { get; set; } = String.Empty;
        public string Sha256 { get; set; } = String.Empty;
    }

    public class Dob
    {
        public DateTime Date { get; set; }
        public int Age { get; set; }
    }

    public class Registered
    {
        public DateTime Date { get; set; }
        public int Age { get; set; }
    }

    public class Id
    {
        public string Name { get; set; } = String.Empty;
        public string Value { get; set; } = String.Empty;
    }

    public class Picture
    {
        public string Large { get; set; } = String.Empty;
        public string Medium { get; set; } = String.Empty;
        public string Thumbnail { get; set; } = String.Empty;
    }

    public class Result
    {
        public string Gender { get; set; } = String.Empty;
        public Name Name { get; set; }
        public Location Location { get; set; }
        public string Email { get; set; } = String.Empty;
        public Login Login { get; set; }
        public Dob Dob { get; set; }
        public Registered Registered { get; set; }
        public string Phone { get; set; } = String.Empty;
        public string Cell { get; set; } = String.Empty;
        public Id Id { get; set; }
        public Picture Picture { get; set; }
        public string Nat { get; set; } = String.Empty;
    }

    public class Info
    {
        public string Seed { get; set; } = String.Empty;
        public int Results { get; set; }
        public int Page { get; set; }
        public string Version { get; set; } = String.Empty;
    }

    public class Root
    {
        public List<Result> Results { get; set; }
        public Info Info { get; set; }
    }

    public ResponseRandomUserGereted()
    {
    }
}