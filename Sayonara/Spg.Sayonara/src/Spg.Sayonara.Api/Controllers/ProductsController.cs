using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Spg.Sayonara.DomainModel.Dtos;
using Spg.Sayonara.DomainModel.Exceptions;
using Spg.Sayonara.DomainModel.Interfaces;

namespace Spg.Sayonara.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IWritableProductService _writableProductService;

        public ProductsController(IWritableProductService writableProductService)
        {
            _writableProductService = writableProductService;
        }

        [HttpPost()]
        public IActionResult Create(CreateProductCommand command)
        {
            try
            {
                ProductDto newProduct = _writableProductService.Create(command);
                return Created($"api/products/{newProduct.Name}", newProduct);
            }
            catch (ProductServiceCreateException ex)
            {
                return StatusCode(500);
            }
            catch (ProductServiceValidationException ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpPut()]
        public IActionResult Update(UpdateProductCommand command)
        {
            // TODO: Implementation
            return Ok();
        }

        [HttpPatch()]
        public IActionResult UpdateName(UpdateProductNameCommand command)
        {
            // TODO: Implementation
            return Ok();
        }
    }
}