namespace RandomUserConsumer.Domain.Entities;

public class Coordinate : EntityBase
{
    public double Latitude { get; set; }
    public double Longitude { get; set; }
    
    public int IdAddress { get; set; }
    public virtual Address Address { get; set; }
}