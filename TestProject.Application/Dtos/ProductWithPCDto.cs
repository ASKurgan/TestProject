using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject.Application.Dtos
{
    public class ProductWithPCDto
    {
       public Guid ProductId { get; init; }
       public Guid ProductCategoryId { get; init; }
       public string ProductName { get; init; } = string.Empty;
       public string PCName { get; init; } = string.Empty;
       public string ProductDescription { get; init; } = string.Empty;
       public string PCDescrption { get; init; } = string.Empty;
       public string ProducPrice { get; init; } = string.Empty;
       public DateTimeOffset ProductDateCreate { get; init; }
       public DateTimeOffset ProductExpirationDate { get; init; }
       public long ProductAmount { get; init; }

    }
}
