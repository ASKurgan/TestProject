using Microsoft.AspNetCore.Mvc;
using TestProject.API.Mapping.FromRequestToCommand;
using TestProject.API.Requests.ProductCategory;
using TestProject.API.Requests.PublishProduct;
using TestProject.Application.Features.ProductCategoryFolder;
using TestProject.Application.Features.ProductCategoryFolder.PublishProduct;
using TestProject.Infrastructure.Queries.ProductCategories.GetPC;

namespace TestProject.API.Controllers
{
    [Route("[controller]")]
    public class PCController : ApplicationController
    {
        [HttpPost("product_category")]
        public async Task<IActionResult> Create([FromServices] PCHandler handler,
                                                [FromBody] PCRequest pCRequest,
                                                CancellationToken ct)
        {
            var pcCommandResult = MapPC.GetPCCommand(pCRequest, ct);

            if (pcCommandResult.IsFailure)
            {
                return BadRequest(pcCommandResult.Error);
            }

            var pcCommand = pcCommandResult.Value;

            var response = await handler.Handle(pcCommand, ct);

            if (response.IsFailure)
                return BadRequest(response.Error);

            return Ok(response.Value);

        }

        [HttpPost("product")]

        public async Task<IActionResult> PublishProduct([FromServices] PublishProductHandler handler,
                                                        [FromForm] PublishProductRequest productRequest,
                                                        CancellationToken ct)
        {
            var productCommandResult = MapPublishProduct.GetPublishProductCommand(productRequest, ct);

            if (productCommandResult.IsFailure)
            {
                return BadRequest(productCommandResult.Error);
            }

            var productCommand = productCommandResult.Value;

            var response = await handler.Handle(productCommand, ct);

            if (response.IsFailure)
                return BadRequest(response.Error);

            return Ok(response.Value);
        }

        [HttpGet("GetById")]

        public async Task<IActionResult> GetById([FromServices] GetPCQuery handler,
                                                 [FromQuery] GetPCRequest request,
                                                 CancellationToken ct)
        {
            var pcResult = await handler.Handle(request, ct);

            if (pcResult.IsFailure)
            {
                return BadRequest (pcResult.Error);
            }

            var pcResponse = pcResult.Value;

            return Ok(pcResponse);         
        }

     }

}
