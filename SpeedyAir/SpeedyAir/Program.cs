// See https://aka.ms/new-console-template for more information

using Castle.Windsor;
using SpeedyAir.Entities;
using SpeedyAir.Helpers;
using SpeedyAir.Outputs;
using SpeedyAir.Setup;

var container = new WindsorContainer();
var flights = new List<Flight>();
CastleSetup();
OutputFlightDetails();
ImportAndAssignOrders();

void CastleSetup()
{
    container.Install(new SpeedyAirInstaller());
}

void OutputFlightDetails()
{
    var output = container.Resolve<IFlightDetailsOutput>();
    var provider = container.Resolve<IDataProvider>();
    flights = provider.PopulateFlightDetails();
    output.OutputFlightSchedule(flights);
}

void ImportAndAssignOrders()
{
    var processor = container.Resolve<IOrderFileProcessor>();
    processor.ProcessFile(flights);
}