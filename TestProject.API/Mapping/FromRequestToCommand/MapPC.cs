using TestProject.API.Requests.ProductCategory;

using TestProject.Application.Features.ProductCategoryFolder;
using TestProject.Domain.Base;

namespace TestProject.API.Mapping.FromRequestToCommand
{
    public class MapPC
    {
        public static Result<PCCommand> GetPCCommand(PCRequest pCRequest, CancellationToken ct) 
        {
            return new PCCommand(pCRequest.Name, pCRequest.Description);
        }
    }

}
