namespace SpeedyAir.Entities;

public class Order
{
    public int OrderId { get; set; }

    public string DepartureAirport { get; set; }

    public string ArrivalAirport { get; set; }

    public int FlightId { get; set; }

    public bool IsLoaded { get; set; }

    public Order(int id, string origin, string destination, int? flightId)
    {
        OrderId = id;
        DepartureAirport = origin;
        ArrivalAirport = destination;
        FlightId = flightId.HasValue ? FlightId : 0;
        IsLoaded = FlightId > 0;
    }
}