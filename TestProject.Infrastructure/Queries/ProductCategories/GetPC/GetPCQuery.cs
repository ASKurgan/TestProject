using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestProject.Application.Dtos;
using TestProject.Domain.Base;
using TestProject.Infrastructure.DbContexts;
using static TestProject.Domain.Base.Error;

namespace TestProject.Infrastructure.Queries.ProductCategories.GetPC
{
    public class GetPCQuery
    {
        private readonly ReadDbContext _dbContext;

        public GetPCQuery(ReadDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Result<GetPCResponse>> Handle(GetPCRequest request,
                                                        CancellationToken ct)
        {
            var productCategory = await _dbContext.PCReadModels
                                         .Include(pc => pc.Products)
                                         .FirstOrDefaultAsync(pc => pc.Id == request.ProductCategoryId, ct);

            if (productCategory == null)
            {
                return Errors.General.NotFound(request.ProductCategoryId);
            }

            var pcByIdDto = new PCByIdDto(
              productCategory.Id,
              productCategory.Name,
              productCategory.Description,
              productCategory.Products.Select(p => new ProductNameDto(p.Name)).ToList());

            return new GetPCResponse(pcByIdDto);
        }
    }
}
