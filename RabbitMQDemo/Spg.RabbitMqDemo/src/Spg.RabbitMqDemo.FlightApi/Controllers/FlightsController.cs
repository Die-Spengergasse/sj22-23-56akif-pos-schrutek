using Microsoft.AspNetCore.Mvc;
using Spg.RabbitMqDemo.DomainModel.Dtos;
using Spg.RabbitMqDemo.DomainModel.Interfaces;
using Spg.RabbitMqDemo.DomainModel.Model.FlightApi;

namespace Spg.RabbitMqDemo.FlightApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FlightsController : ControllerBase
    {
        private readonly IDestinationLookupRepository _destinationLookupRepository;
        private readonly IFlightRepository _flightRepository;
        private readonly IRabbitMqRepository _rabbitMqRepository;
        private readonly IIdentifierService _identifierService;

        public FlightsController(
            IDestinationLookupRepository destinationLookupRepository,
            IFlightRepository flightRepository,
            IRabbitMqRepository rabbitMqRepository,
            IIdentifierService identifierService)
        {
            _destinationLookupRepository = destinationLookupRepository;
            _flightRepository = flightRepository;
            _rabbitMqRepository = rabbitMqRepository;
            _identifierService = identifierService;
        }

        [HttpPost()]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult CreateFlight(CreateFlightCommand command)
        {
            try
            {
                // Validation
                DestinationLookup from = _destinationLookupRepository.GetDestinationByCity(command.FromCity);
                DestinationLookup to = _destinationLookupRepository.GetDestinationByCity(command.ToCity);
                string id = _identifierService.GetIdentifier();

                // DB-Stuff
                Flight newFlight = new Flight(
                    id,
                    from,
                    to,
                    command.Departure,
                    command.CheckIn);
                _flightRepository.Create(newFlight);

                // Publish message
                _rabbitMqRepository.PostFlightCreation(newFlight);

                return Created($"api/Flights/{id}", command);
            }
            catch (ArgumentException)
            {
                return NotFound();
            }
            catch (InvalidOperationException)
            {
                return StatusCode(500);
            }
        }

        [HttpGet()]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public IActionResult Get()
        {
            // TODO: Implementation
            return NoContent();
        }
    }
}