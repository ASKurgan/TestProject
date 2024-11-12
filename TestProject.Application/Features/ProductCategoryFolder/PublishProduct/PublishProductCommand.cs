using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject.Application.Features.ProductCategoryFolder.PublishProduct
{
    public record PublishProductCommand(string PCName, 
                                        string Name,
                                        string Description,
                                        DateTimeOffset ExpirationDate,
                                        decimal Price,
                                        long Amount,
                                        DateTimeOffset DateCreate);
}
