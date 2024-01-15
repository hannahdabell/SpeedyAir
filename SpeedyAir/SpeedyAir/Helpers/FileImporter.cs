using System.Text.Json;
using Newtonsoft.Json.Linq;
using SpeedyAir.Entities;

namespace SpeedyAir.Helpers;

public interface IFileImporter
{
    IEnumerable<Order> ImportOrderFile(string fileLocation);
}

internal class FileImporter : IFileImporter
{
    public IEnumerable<Order> ImportOrderFile(string fileLocation)
    {
        if (!File.Exists(fileLocation))
        {
            return new List<Order>();
        }

        var orders = new List<Order>(); 
        var jsonDocumentOrders = JsonDocument.Parse(File.ReadAllText(fileLocation));
        var enumeratedOrderDocument = jsonDocumentOrders.RootElement.EnumerateObject();
        foreach (var element in enumeratedOrderDocument)
        {
            var destination = JObject.Parse(element.Value.ToString())["destination"].ToString();
            var id = element.Name.Replace("order-", "");
            orders.Add(new Order(Int32.Parse(id), "YUL", destination, null));
        }
        
        return orders;
    }
}