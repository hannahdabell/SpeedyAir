using SpeedyAir.Entities;

namespace SpeedyAir.Outputs;

public interface IOrderAllocationOutput
{
    public void OutputAllocatedOrders(List<Order> orders, List<Flight> flights);
}

public class OrderAllocationOutput : IOrderAllocationOutput
{
    private readonly IFlightDetailsOutput _flightOutput;
    
    private static string NoAssignedFlight = "NotScheduled";

    public OrderAllocationOutput(IFlightDetailsOutput flightOutput)
    {
        _flightOutput = flightOutput;
    }

    public void OutputAllocatedOrders(List<Order> orders, List<Flight> flights)
    {
        var notLoadedOrders = new List<Order>();
        foreach (var order in orders)
        {
            if (order.IsLoaded == false)
            {
                Console.WriteLine($"Order: order-" + order.OrderId + " flightNumber: " + NoAssignedFlight);
                notLoadedOrders.Add(order);
                continue;
            }
            var flight = flights.First(x => x.FlightId == order.FlightId);
            Console.WriteLine("Order: order-" + order.OrderId + " flightNumber: " + order.FlightId + " departure: " + order.DepartureAirport + " arrival: "  + order.ArrivalAirport + " day: " + flight.Date);
        }
        
        Console.WriteLine("Total orders in file: " + orders.Count);
        Console.WriteLine("Packages not loaded: " + notLoadedOrders.Count);
        foreach (var order in notLoadedOrders)
        {
            Console.WriteLine("Order: order-" + order.OrderId + " departure: " + order.DepartureAirport + " arrival: "  + order.ArrivalAirport );
        }

        _flightOutput.OutputFlightLoadingDetails(flights);
    }
}