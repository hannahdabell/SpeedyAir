namespace SpeedyAir.Entities;

public class Flight
{
    public int FlightId { get; set; }
    
    public string DepartureAirport { get; set; }

    public string ArrivalAirport { get; set; }

    public int Date { get; set; } //this would normally be a DateTime but the flight list has int so left as this for now.

    public int Capacity { get; set; }

    public List<Order> AssignedOrders { get; set; }

    public bool IsFull { get; set;  }

    public Flight(int flightId, string departure, string arrival, int date, int capacity)
    {
        FlightId = flightId;
        DepartureAirport = departure;
        ArrivalAirport = arrival;
        Date = date;
        Capacity = capacity;
        AssignedOrders = new List<Order>();
        IsFull = false;
    }
}