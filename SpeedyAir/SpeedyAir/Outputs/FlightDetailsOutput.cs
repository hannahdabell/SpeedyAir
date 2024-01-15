using SpeedyAir.Entities;

namespace SpeedyAir.Outputs;

public interface IFlightDetailsOutput
{
    public void OutputFlightSchedule(IEnumerable<Flight> flights);

    public void OutputFlightLoadingDetails(IEnumerable<Flight> flights);
}

internal class FlightDetailsOutput : IFlightDetailsOutput
{
    public void OutputFlightSchedule(IEnumerable<Flight> flights)
    {
        foreach (Flight flight in flights)
        {
            Console.WriteLine("Flight " + flight.FlightId + ", Departure: " + flight.DepartureAirport + ", Arrival: " +
                              flight.ArrivalAirport + ", Day: " + flight.Date);
        }
    }

    public void OutputFlightLoadingDetails(IEnumerable<Flight> flights)
    {
        foreach (Flight flight in flights)
        {
            Console.WriteLine("Flight " + flight.FlightId + ", Departure: " + flight.DepartureAirport + ", Arrival: " +
                              flight.ArrivalAirport + ", Day: " + flight.Date + ". Full : " + flight.IsFull + ". Packages loaded : " + flight.AssignedOrders.Count);
        }
        Console.WriteLine("Total packages loaded: " + flights.Sum(x => x.AssignedOrders.Count));
    }
}