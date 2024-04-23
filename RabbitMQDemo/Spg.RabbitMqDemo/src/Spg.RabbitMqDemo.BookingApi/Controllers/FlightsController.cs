using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Spg.RabbitMqDemo.DomainModel.Interfaces;
using Spg.RabbitMqDemo.Repository;

namespace Spg.RabbitMqDemo.BookingApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FlightsController : ControllerBase
    {
        private readonly IAvailableFlightService _flightService;

        public FlightsController(IAvailableFlightService flightService)
        {
            _flightService = flightService;
        }

        [HttpGet()]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult GetAll()
        {
            return Ok(_flightService.GetAll());
        }
    }
}
