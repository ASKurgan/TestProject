using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject.Application.Dtos
{
    public record PCByIdDto(
    Guid Id,
    string Name,
    string Description,
    IReadOnlyList<ProductNameDto> Products);
}
