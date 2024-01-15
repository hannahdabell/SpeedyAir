namespace SpeedyAir.Entities;

public class Airport
{
    public int AirportId { get; set; }
    
    public string IataCode { get; set; }

    public string AirportName { get; set; }

    public Airport(int id, string iata, string name)
    {
        AirportId = id;
        IataCode = iata;
        AirportName = name;
    }
}