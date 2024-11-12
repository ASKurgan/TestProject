using TestProject.API.Requests.ProductCategory;
using TestProject.API.Requests.PublishProduct;
using TestProject.Application.Features.ProductCategoryFolder.PublishProduct;
using TestProject.Domain.Base;

namespace TestProject.API.Mapping.FromRequestToCommand
{
    public class MapPublishProduct
    {
        public static Result<PublishProductCommand> GetPublishProductCommand(PublishProductRequest request,
                                                                               CancellationToken ct)
        {
            return new PublishProductCommand(request.PCName,
                                             request.Name,
                                             request.Description,
                                             request.ExpirationDate,
                                             request.Price,
                                             request.Amount,
                                             request.DateCreate);
        }
    }

    
}
