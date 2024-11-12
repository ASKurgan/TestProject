using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestProject.Application.Dtos;

namespace TestProject.Infrastructure.Queries.Products.GetAllWithPC
{
    public record GetAllWithPCResponse(List<ProductWithPCDto> ProductsWithPCDto);
}
