using Microsoft.AspNetCore.Mvc;
using TestProject.Infrastructure.Queries.ProductCategories.GetPC;
using TestProject.Infrastructure.Queries.ProductCategories.GetProducts;
using TestProject.Infrastructure.Queries.Products.DraftProductResponse;
using TestProject.Infrastructure.Queries.Products.GetAllWithPC;
using TestProject.Infrastructure.Queries.Products.GetProductById;

namespace TestProject.API.Controllers
{
    [Route("[controller]")]
    public class ProductController : ApplicationController
    {
        [HttpGet]
        public async Task<IActionResult> GetById(
                                                 [FromServices] GetByIdProductQuery handler,
                                                 [FromQuery] GetByIdProductRequest request,
                                                 CancellationToken ct)
        {
            var result = await handler.Handle(request, ct);
            if (result.IsFailure) 
            {
                return BadRequest(result.Error);
            }
            
            return Ok(result.Value); 
        }

        [HttpGet("products")]
        public async Task<IActionResult> GetProductsByPC(
                                                    [FromServices] GetPCProductsQuery handler,
                                                    [FromQuery] GetPCProductsRequest request,
                                                    CancellationToken ct)
        {
            var result = await handler.Handle(request, ct);

            if (result.IsFailure)
            {
                return BadRequest(result.Error);
            }
            return Ok(result.Value);

        }


        [HttpGet("all_products_with_pc")]

        public async Task<IActionResult> GetAll(
                                                [FromServices] GetAllWithPCQuery handler,
                                                CancellationToken ct)
        {
            var result = await handler.Handle(ct);

            if (result.IsFailure) 
            {
              return BadRequest(result.Error);
            }

            return Ok(result.Value);
        }


        // draft methods

        [HttpGet("products_draft")]
        public async Task<IActionResult> GetProductsDraft (
                                                           [FromServices] DraftQuery draftHandler)
        {
            var result = draftHandler.DraftHandle();
            return Ok(result);
        }

      
    }

}
