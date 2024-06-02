using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Spg.Sayonara.Application.UseCases.Shop.Queries;
using Spg.Sayonara.DomainModel.Dtos;
using System.Reflection.Metadata.Ecma335;

namespace Spg.Sayonara.Api.Controllers
{
    [Route("api/shopscqs")]
    [ApiController]
    public class ShopsCqsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ShopsCqsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // api/shops?filter=name sw x&orderby=name asc,description desc&page=5&size=10
        [HttpGet]
        public IActionResult GetShops([FromQuery()] GetShopsFilteredQuery query)
        {
            string role = "user";

            role = HttpContext.Request.Headers["authorisation"];

            if (role == "admin")
            {
                GetShopsFilteredModel model = new GetShopsFilteredModel(query);
                List<ShopDto> data = _mediator.Send(model).Result.ToList();

                return Ok(data);
            }
            return Forbid();
        }
    }
}
