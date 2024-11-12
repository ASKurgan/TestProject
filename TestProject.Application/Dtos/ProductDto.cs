using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject.Application.Dtos
{
    public record ProductDto( Guid Id,
                              string Name,
                              string PCName,
                              string Description,
                              decimal Price,
                              long Amount,
                              DateTimeOffset DateCreate,
                              DateTimeOffset ExpirationDate);
}
