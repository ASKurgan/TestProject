using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject.Application.Dtos
{
    public record PCDto(
     Guid Id,
     string Name,
     string Description,
     IReadOnlyList<ProductDto> Products);
}
