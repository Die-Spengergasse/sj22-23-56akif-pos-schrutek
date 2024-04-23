using MassTransit;
using Spg.RabbitMqDemo.DomainModel.Dtos.BookingApi;
using Spg.RabbitMqDemo.DomainModel.Interfaces;

namespace Spg.RabbitMqDemo.BookingApi.Consumers
{
    public class FlightConsumer : IConsumer<IFlightCreation>
    {
        private readonly IAvailableFlightService _flightService;

        public FlightConsumer(IAvailableFlightService flightService)
        {
            _flightService = flightService;
        }

        public Task Consume(ConsumeContext<IFlightCreation> context)
        {
            IFlightCreation newFlight = context.Message;

            Console.WriteLine($"ID:   {newFlight.Identifier}");
            Console.WriteLine($"FROM: {newFlight.FromDestination.CityName}");
            Console.WriteLine($"TO:   {newFlight.ToDestination.CityName}");
            Console.WriteLine($"DEP:  {newFlight.Departure}");

            _flightService.PersistReceivedFlight(context.Message);

            return Task.CompletedTask;
        }
    }
}
