using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject.Infrastructure.Queries.ProductCategories.GetProducts
{
    public record GetPCProductsRequest(Guid ProductCategoryId, int Size = 9, int Page = 1);
}
