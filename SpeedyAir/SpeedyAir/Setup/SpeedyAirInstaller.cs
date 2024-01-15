using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using SpeedyAir.Helpers;
using SpeedyAir.Outputs;

namespace SpeedyAir.Setup;

public class SpeedyAirInstaller : IWindsorInstaller
{
    public void Install(IWindsorContainer container, IConfigurationStore store)
    {
        container.Register(Component.For<IDataProvider>().ImplementedBy<DataProvider>());
        container.Register(Component.For<IFlightDetailsOutput>().ImplementedBy<FlightDetailsOutput>());
        container.Register(Component.For<IOrderAllocationOutput>().ImplementedBy<OrderAllocationOutput>());
        container.Register(Component.For<IOrderFileProcessor>().ImplementedBy<OrderFileProcessor>());
        container.Register(Component.For<IFileImporter>().ImplementedBy<FileImporter>());
        
    }
}