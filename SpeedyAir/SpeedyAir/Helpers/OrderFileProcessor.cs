using SpeedyAir.Entities;
using SpeedyAir.Outputs;

namespace SpeedyAir.Helpers;

public interface IOrderFileProcessor
{
    public void ProcessFile(List<Flight> flights);
}

internal class OrderFileProcessor : IOrderFileProcessor
{
    private readonly IFileImporter _importer;
    private readonly IOrderAllocationOutput _output;

    static readonly string OrderFileLocation = "C:/Users/hdabell/Downloads/coding-assigment-orders.json";

    public OrderFileProcessor(IFileImporter importer, IOrderAllocationOutput output)
    {
        _importer = importer;
        _output  = output;
    }

    public void ProcessFile(List<Flight> flights)
    {
        var importedOrders = _importer.ImportOrderFile(OrderFileLocation);
        var allocatedOrders = AllocateOrders(flights, importedOrders.ToList());
        _output.OutputAllocatedOrders(allocatedOrders.ToList(), flights);
    }

    private IEnumerable<Order> AllocateOrders(List<Flight> flights, List<Order> orders)
    {
        foreach (var order in orders)
        {
            var flightToAssign = flights
                .Where(x => x.ArrivalAirport.Equals(order.ArrivalAirport))
                .Where(x => x.DepartureAirport.Equals(order.DepartureAirport)).FirstOrDefault(x => x.IsFull.Equals(false));

            if (flightToAssign is null)
            {
                continue;
            }

            order.FlightId = flightToAssign.FlightId;
            order.IsLoaded = true;
            flightToAssign.AssignedOrders.Add(order);
            flightToAssign.IsFull = (flightToAssign.AssignedOrders.Count == flightToAssign.Capacity);
        }

        return orders;
    }
}