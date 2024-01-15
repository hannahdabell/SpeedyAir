using SpeedyAir.Entities;

namespace SpeedyAir.Helpers;

public interface IDataProvider
{
    public List<Airport> PopulateAirportDetails();

    public List<Flight> PopulateFlightDetails();
}

internal class DataProvider : IDataProvider
{
    public List<Airport> PopulateAirportDetails()
    {
        return  new List<Airport>
        {
            new Airport(1, "YUL", "Montreal"),
            new Airport(2, "YYZ", "Toronto"),
            new Airport(3, "YYC", "Calgary"),
            new Airport(4, "YYE", "Northern Rockies Regional"),
            new Airport(5, "YVR", "Vancouver")
        };
    }

    public List<Flight> PopulateFlightDetails()
    {
        return new List<Flight>
        {
            new Flight (1, "YUL", "YYZ", 1, 20),
            new Flight (2, "YUL", "YYC", 1, 20),
            new Flight (3, "YUL", "YVR", 1, 20),
            new Flight (4, "YUL", "YYZ", 2, 20),
            new Flight (5, "YUL", "YYC", 2, 20),
            new Flight (6, "YUL", "YVR", 2, 20)
        };
    }
}