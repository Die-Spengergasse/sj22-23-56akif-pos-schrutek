using MediatR;
using Microsoft.AspNetCore.Mvc;
using Spg.Sayonara.Api.ActionFilter;
using Spg.Sayonara.Application.UseCases.Shop.Queries;
using Spg.Sayonara.DomainModel.Dtos;

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
        [HttpGet()]
        [LoggingActions()]
        [BasicAuthentication("admin", WhateverZeug = "whatever")]
        public IActionResult GetShops([FromQuery()] GetShopsFilteredQuery query)
        {
            GetShopsFilteredModel model = new GetShopsFilteredModel(query);
            List<ShopDto> data = _mediator.Send(model).Result.ToList();

            return Ok(data);
        }
    }
}
