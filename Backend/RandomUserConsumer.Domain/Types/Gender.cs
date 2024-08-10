namespace RandomUserConsumer.Domain.Types;

public class GenderType
{
    public string Gender {get; private set; }
    
    public static GenderType Male => new GenderType("male");
    public static GenderType Female => new GenderType("female");
    public static GenderType Other => new GenderType("other");
    
    public GenderType(string gender)
    {
        this.Gender = gender;
    }
    
    public override string ToString()
    {
        return Gender;
    }
}